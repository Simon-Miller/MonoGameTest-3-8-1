using System.Text;

namespace Graphics
{
    public class Drawing
    {
        public Drawing(UInt32[] bitmap, uint wide, uint high)
        {
            this.bitmap = bitmap;
            this.wide = wide;
            this.high = high;

            clipper = new CohenSutherlandAlgorithm(xmin: 0, xmax: wide - 1, ymin: 0, ymax: high - 1);
        }

        private readonly UInt32[] bitmap;
        private readonly uint wide;
        private readonly uint high;

        private readonly CohenSutherlandAlgorithm clipper;

        public void RectangleUnClipped(uint x, uint y, uint width, uint height, UInt32 colour, bool fill = true)
        {
            if (fill)
            {
                var lastY = y + height - 1;
                for (var yy = y; yy <= lastY; yy++)
                    HorizontalLineUnClipped(x, yy, width, colour);
            }
            else
            {
                HorizontalLineUnClipped(x, y, width, colour);
                HorizontalLineUnClipped(x, (y + height - 1), width, colour);

                var yp1 = y + 1;
                var hm2 = height - 2;
                VerticalLineUnClipped(x, yp1, hm2, colour);
                VerticalLineUnClipped((x + width - 1), yp1, hm2, colour);
            }
        }

        public void HorizontalLineUnClipped(uint x, uint y, uint width, UInt32 colour)
        {
            var offset = (y * wide) + x;
            var last = offset + width;

            for (var i = offset; i < last; i++)
                bitmap[i] = colour;
        }

        public void VerticalLineUnClipped(uint x, uint y, uint height, UInt32 colour)
        {
            var offset = (y * wide) + x;
            var last = offset + (height * wide);

            for (var i = offset; i < last; i += wide)
                bitmap[i] = colour;
        }

        public void HorizontalLine(uint x, uint y, uint width, UInt32 colour)
        {
            double x1 = x, y1 = y, x2 = (x + width - 1), y2 = y;
            var insideOfWindow = clipper.LineClip(ref x1, ref y1, ref x2, ref y2);
            if (insideOfWindow)
            {
                x = (uint)x1;
                y = (uint)y1;
                width = (uint)((x2 - x1) + 1);
                HorizontalLineUnClipped(x, y, width, colour);
            }
        }

        public void VerticalLine(uint x, uint y, uint height, UInt32 colour)
        {
            double x1 = x, y1 = y, x2 = x, y2 = (y + height - 1);
            var insideOfWindow = clipper.LineClip(ref x1, ref y1, ref x2, ref y2);
            if (insideOfWindow)
            {
                x = (uint)x1;
                y = (uint)y1;
                height = (uint)((y2 - y1) + 1);
                VerticalLineUnClipped(x, y, height, colour);
            }
        }

        public void Plot(uint x, uint y, uint colour)
        {
            var offset = (y * wide) + x;
            bitmap[offset] = colour;
        }

        public void Line(uint x, uint y, uint x2, uint y2, uint colour)
        {
            double cx = x, cy = y, cx2 = x2, cy2 = y2;

            // swap vectors if CX is not to the left of CX2.
            if (cx > cx2)
            {
                var temp = cx;
                cx = cx2;
                cx2 = temp;

                temp = cy;
                cy = cy2;
                cy2 = temp;
            }

            var insideOfWindow = clipper.LineClip(ref cx, ref cy, ref cx2, ref cy2);
            if (insideOfWindow)
            {
                // now!  let's draw a line!

                // I remember once seeing a paper about this, where the pint of the pixel is mathematically the centre of a box,
                // and not the top-left corner.  Therefore, we need to add half a pixel to all coordinates to compensate.
                cx += 0.5;
                cy += 0.5;
                cx2 += 0.5;
                cy2 += 0.5;

                // what's the ratio of width to height?  For every 1 pixel we move horizontally, how many vertically?

                // as we know cx < cx2
                var width = (cx2 - cx);
                var height = (cy < cy2)
                    ? (cy2 - cy)
                    : (cy2 - cy); // negative height.

                // If horizontal is longer than vertical, then we want to draw the line along the LONGER length, one pixel at a time.
                if (width > Math.Abs(height))
                {
                    // horizontal length is longer.
                    double plotY = cy, yRatio = height / width;

                    for (var plotX = cx; plotX <= cx2; plotX++)
                    {
                        // calculate offset pixel in array.
                        var px = (int)plotX;
                        var py = (int)plotY;

                        var offset = (py * this.wide) + px;

                        this.bitmap[offset] = colour; // DRAW A PIXEL OF GIVEN COLOUR

                        plotY += yRatio;
                    }
                }
                else
                {
                    // vertical length is longer.
                    double plotX = cx, xRatio = (height >= 0)? width / height : width / (0.0 - height);

                    if (cy < cy2)
                    {
                        // drawing direction is DOWN
                        for (var plotY = cy; plotY <= cy2; plotY++)
                        {
                            // calculate offset pixel in array.
                            var px = (int)plotX;
                            var py = (int)plotY;

                            var offset = (py * this.wide) + px;

                            this.bitmap[offset] = colour; // DRAW A PIXEL OF GIVEN COLOUR

                            plotX += xRatio;
                        }
                    }
                    else
                    {
                        // drawing direction is UP
                        for (var plotY = cy; plotY >= cy2; plotY--)
                        {
                            // calculate offset pixel in array.
                            var px = (int)plotX;
                            var py = (int)plotY;

                            var offset = (py * this.wide) + px;

                            this.bitmap[offset] = colour; // DRAW A PIXEL OF GIVEN COLOUR

                            plotX += xRatio;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// designed for use with Draw() but can be used independently.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="direction">1=up, 2= upRight, 3= right, 4= downRight, 5= down, 6= downLeft, 7= left, 8= upLeft</param>
        /// <param name="length"></param>
        /// <param name="colour"></param>
        public void Line(ref int X, ref int Y, byte direction, uint length, uint colour)
        {
            // idiot check as we go, means less code but slower performance.  Still fast as hell, unless you want thousands of lines like this.

            // direction: 1 = up, 2 = upRight, 3 = right, 4 = downRight, 5 = down, 6= downLeft, 7=Left, 8= upLeft
            var count = 0;
            bool done = false;

            switch (direction)
            {
                // up
                case 1:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        Y--;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (Y < 0) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // upRight
                case 2:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        Y--;
                        X++;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (Y < 0) done = true;
                        if (X >= this.wide) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // right
                case 3:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        X++;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (X >= this.wide) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // downRight
                case 4:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        X++;
                        Y++;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (X >= this.wide) done = true;
                        if (Y >= this.high) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // down
                case 5:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        Y++;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (Y >= this.high) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // downLeft
                case 6:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        Y++;
                        X--;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (Y >= this.high) done = true;
                        if (X < 0) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // left
                case 7:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        X--;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (X < 0) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                // upLeft
                case 8:
                    do
                    {
                        var debug = debugHelper(bitmap, 7);

                        X--;
                        Y--;
                        var offset = (Y * this.wide) + X;
                        this.bitmap[offset] = colour;
                        
                        count++;
                        if (X < 0) done = true;
                        if (Y < 0) done = true;
                        if (count > length) done = true;
                    }
                    while (!done);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Assumes the colour you are painting if the 'blocking' colour.  So the shape will fill with this colour,
        /// and lines etc that surround the shape will block the fill from bleeding outside.
        /// </summary>
        public void Fill(uint x, uint y, uint colour)
        {
            // add starting pixel to queue to be painted, and checked for additional paint points.
            var checks = new Queue<(int x, int y)>();
            checks.Enqueue(((int)x, (int)y));

            void check(int x, int y)
            {
                // ensure point is inside the clip window.
                if (x >= 0 && y >= 0 && x < this.wide && y < this.high)
                {
                    var offset = (y * this.wide) + x;

                    if (y > 0 && this.bitmap[offset - this.wide] != colour)
                        checks!.Enqueue((x, y - 1));

                    if (y < this.high - 1 && this.bitmap[offset + this.wide] != colour)
                        checks!.Enqueue((x, y + 1));

                    if (x < this.wide - 1 && this.bitmap[offset + 1] != colour)
                        checks!.Enqueue((x + 1, y));

                    if (x > 0 && this.bitmap[offset - 1] != colour)
                        checks!.Enqueue((x - 1, y));
                }
            }

            while (checks.TryDequeue(out var point))
            {
                var offset = (point.y * this.wide) + x;
                this.bitmap[offset] = colour; // paint a pixel

                check(point.x, point.y);
            }
        }

        /// <summary>
        /// a string the breaks down by character and digits.  Where characters are commands :u,d,l,r,e,f,g,h.
        /// the digits are a decimal number representing a length in pixels for a line in a given direction.
        /// the commands ARE the directions.  Each line command has no separator.  So a digit follows a character, and
        /// a character follows a digit.  For example 'u5r5d5l5' makes a square of 5 pixels in length on each side.
        /// <code>
        /// u = up
        /// d = down
        /// l = left
        /// r = right
        /// e = Up+Right
        /// f = Down+Right
        /// g = Down+Left
        /// h = Up+Left
        /// </code>
        /// </summary>
        /// <param name="x">starting x coordinate of drawing operation</param>
        /// <param name="y">starting y coordinate of drawing operation</param>
        /// <param name="commands"></param>
        /// <param name="colour"></param>
        public void Draw(uint x, uint y, string commands, uint colour)
        {
            // u5r5d5l5 == square.   u == up,      r == right,     d == down,     l == left,  5 == number of pixels in direction.
            // e5f5g5h5 == diamond.  e == upRight, f == downRight, g == downLeft, h = upLeft

            int X = (int)x, Y = (int)y;

            var directions = processCommands();

            Plot(x, y, colour); // starting pixel.

            foreach (var direction in directions)
            {
                Line(ref X, ref Y, direction.direction, direction.length, colour);
            }

            List<(byte direction, uint length)> processCommands()
            {
                var list = new List<(byte direction, uint length)>();

                bool gotDirection = false;
                byte direction = 0;
                uint number = 0;

                for (int i = 0; i <= commands.Length; i++)
                {
                    char chr = 'x'; // beyond last character means we assume a char that does not exist.  Should cause last Add to list.
                    if(i < commands.Length) chr = commands[i];

                    if (!gotDirection)
                    {
                        switch (chr)
                        {
                            case 'u': direction = 1; break;
                            case 'd': direction = 5; break;
                            case 'l': direction = 7; break;
                            case 'r': direction = 3; break;
                            case 'e': direction = 2; break;
                            case 'f': direction = 4; break;
                            case 'g': direction = 6; break;
                            case 'h': direction = 8; break;
                            case 'x': break;    // beyond last char.  Need to eXit.
                            default:
                                throw new NotImplementedException();
                        }

                        gotDirection = true;
                    }
                    else
                    {
                        if (char.IsDigit(chr))
                        {
                            number *= 10;
                            var cNum = (int)chr;
                            cNum -= '0'; // since when was this valid in C# ??  love it!
                            number += (uint)cNum;
                        }
                        else
                        {
                            list.Add((direction, number));
                            number = 0;
                            gotDirection = false;
                            i--; // read char again in next loop, but as a command.
                        }
                    }
                }

                return list;
            }
        }

        /// <summary>
        /// call this during debug sessions to make a string we can visualize from a bitmap.
        /// </summary>
        private string debugHelper(UInt32[] bitmap, int wide)
        {
            var sb = new StringBuilder();

            var col = 0;

            for(int i=0; i< bitmap.Length; i++)
            {
                sb.Append( (char)(((int)'0') + bitmap[i]));
                col++;

                if(col >= wide)
                {
                    col = 0;
                    sb.Append("\r\n");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Cohen%E2%80%93Sutherland_algorithm
        /// </summary>
        internal class CohenSutherlandAlgorithm
        {
            public CohenSutherlandAlgorithm(double xmin, double xmax, double ymin, double ymax)
            {
                this.xmin = xmin;
                this.xmax = xmax;
                this.ymin = ymin;
                this.ymax = ymax;
            }

            private readonly double xmin;
            private readonly double xmax;
            private readonly double ymin;
            private readonly double ymax;
            private const long INSIDE = 0; // 0000
            private const long LEFT = 1;   // 0001
            private const long RIGHT = 2;  // 0010
            private const long BOTTOM = 4; // 0100
            private const long TOP = 8;    // 1000

            /// <summary>
            /// Compute the bit code for a point (x, y) using the clip rectangle
            /// bounded diagonally by (xmin, ymin), and (xmax, ymax)
            /// </summary>
            private long computeOutCode(double x, double y)
            {
                var code = INSIDE;

                if (x < xmin)           // to the left of clip window
                    code |= LEFT;
                else if (x > xmax)      // to the right of clip window
                    code |= RIGHT;
                if (y < ymin)           // below the clip window
                    code |= BOTTOM;
                else if (y > ymax)      // above the clip window
                    code |= TOP;

                return code;
            }

            /// <summary>
            /// Cohen–Sutherland clipping algorithm clips a line from
            /// P0 = (x0, y0) to P1 = (x1, y1) against a rectangle with
            /// diagonal from (xmin, ymin) to (xmax, ymax).
            /// <para>
            /// returns FALSE when both points are outside clip window, and the intersection is still outside the window?
            /// </para>
            /// </summary>
            public bool LineClip(ref double x0, ref double y0, ref double x1, ref double y1)
            {
                // compute outcodes for P0, P1, and whatever point lies outside the clip rectangle
                var outcode0 = computeOutCode(x0, y0);
                var outcode1 = computeOutCode(x1, y1);
                bool accept = false;

                while (true)
                {
                    if ((outcode0 | outcode1) == 0)
                    {
                        // bitwise OR is 0: both points inside window; trivially accept and exit loop
                        accept = true;
                        break;
                    }
                    else if ((outcode0 & outcode1) > 0)
                    {
                        // bitwise AND is not 0: both points share an outside zone (LEFT, RIGHT, TOP,
                        // or BOTTOM), so both must be outside window; exit loop (accept is false)
                        break;
                    }
                    else
                    {
                        // failed both tests, so calculate the line segment to clip
                        // from an outside point to an intersection with clip edge
                        double x = 0, y = 0;

                        // At least one endpoint is outside the clip rectangle; pick it.
                        var outcodeOut = (outcode1 > outcode0) ? outcode1 : outcode0;

                        // Now find the intersection point;
                        // use formulas:
                        //   slope = (y1 - y0) / (x1 - x0)
                        //   x = x0 + (1 / slope) * (ym - y0), where ym is ymin or ymax
                        //   y = y0 + slope * (xm - x0), where xm is xmin or xmax
                        // No need to worry about divide-by-zero because, in each case, the
                        // outcode bit being tested guarantees the denominator is non-zero
                        if ((outcodeOut & TOP) > 0)
                        {
                            // point is above the clip window
                            x = x0 + (x1 - x0) * (ymax - y0) / (y1 - y0);
                            y = ymax;
                        }
                        else if ((outcodeOut & BOTTOM) > 0)
                        {
                            // point is below the clip window
                            x = x0 + (x1 - x0) * (ymin - y0) / (y1 - y0);
                            y = ymin;
                        }
                        else if ((outcodeOut & RIGHT) > 0)
                        {
                            // point is to the right of clip window
                            y = y0 + (y1 - y0) * (xmax - x0) / (x1 - x0);
                            x = xmax;
                        }
                        else if ((outcodeOut & LEFT) > 0)
                        {
                            // point is to the left of clip window
                            y = y0 + (y1 - y0) * (xmin - x0) / (x1 - x0);
                            x = xmin;
                        }

                        // Now we move outside point to intersection point to clip
                        // and get ready for next pass.
                        if (outcodeOut == outcode0)
                        {
                            x0 = x;
                            y0 = y;
                            outcode0 = computeOutCode(x0, y0);
                        }
                        else
                        {
                            x1 = x;
                            y1 = y;
                            outcode1 = computeOutCode(x1, y1);
                        }
                    }
                }

                return accept;
            }
        }
    }
}
