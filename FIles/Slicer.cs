using System.Drawing;
using System.Drawing.Imaging;

namespace FIles
{
    public static class Slicer
    {
        /// <summary>
        /// automatically slice up an image containing sprites into an array of sprite data.
        /// This can be as simple as a crammed image with no boxes or spaces, up to a large source image from
        /// which you want to take a bounding-box to, which includes boxed sprites with spaces between each,
        /// where the space differs on the x and y.  argh!!  But this should still auto slice that lot.
        /// </summary>
        /// <param name="path">full path and file name of image (bmp / png) to load and slice.</param>
        /// <param name="spriteWidth">width of every sprite to be captured</param>
        /// <param name="spriteHeight">height of every sprite to be captured</param>
        /// <param name="offsetX">first pixel X of first sprite (top left) to be captured</param>
        /// <param name="offsetY">first pixel Y of first sprite (top left) to be captured</param>
        /// <param name="spaceBetweenX">defaults to 0.  If you have a box around each, then likely 3 pixels or more?</param>
        /// <param name="spaceBetweenY">defaults to 0.  If you have a box around each, then likely 3 pixels or more?</param>
        /// <param name="captureWidth">OffsetX is start of bounding box, and this is the width of the bounding box around all sprites.</param>
        /// <param name="captureHeight">OffsetY is start of bounding box, and this is the height of the bounding box around all sprites.</param>
        /// <returns></returns>
        public unsafe static List<SpriteData> GetSpritesFromFile(
            string path, 
            uint spriteWidth, uint spriteHeight, 
            uint offsetX = 0, uint offsetY = 0, 
            uint spaceBetweenX = 0, uint spaceBetweenY = 0,
            uint? captureWidth = null, uint? captureHeight = null) /* the width of a rectangle within the image that bounds all the sprites to capture */
        {
            var sprites = new List<SpriteData>();   

            var img = (Bitmap)Bitmap.FromFile(path);

            var lockData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            {
                // in my experience, stride is always the width, with no bytes spare.
                var ptr = (UInt32*)lockData.Scan0;

                var xInc = spriteWidth + spaceBetweenX;
                var yInc = spriteHeight + spaceBetweenY;

                var lastX = (captureWidth is null)? (uint)img.Width : offsetX + captureWidth;
                var lastY = (captureHeight is null)? (uint)img.Height: offsetY + captureHeight;

                var imageWidth = img.Width;

                for (var py = offsetY; py < lastY; py+= yInc)
                {
                    for(var px = offsetX; px < lastX; px += xInc)
                    {
                        // at this point, we've the starting point for picking up a sprite.
                        var sd = new SpriteData() { Width = spriteWidth, Height = spriteHeight, Data = new UInt32[spriteWidth, spriteHeight] };
                        var data = sd.Data;

                        for(int sy=0; sy< spriteHeight; sy++)
                        {
                            var temp = ((py + sy) * imageWidth) + px;

                            for(int sx=0; sx < spriteWidth; sx++)
                            {
                                // copy pixel to sprite's data.
                                data[sx,sy] = ptr[temp + sx];
                            }
                        }
                        sprites.Add(sd);
                    }
                }
            }
            img.UnlockBits(lockData);

            return sprites;
        }
    }

    public class SpriteData
    {
        public uint Width;
        public uint Height;

        public UInt32[,] Data;
    }
}