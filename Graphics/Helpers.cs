namespace Graphics
{
    public class Helpers
    {
        /// <summary>
        /// Finds every pixel in the <paramref name="bitmap"/> 
        /// matching the <paramref name="findColour"/>
        /// and replaces it with <paramref name="replaceColour"/>
        /// </summary>
        public static void ReplaceColour(UInt32[] bitmap, UInt32 findColour, UInt32 replaceColour)
        {
            var len = bitmap.Length;
            for(int i=0; i< len; i++)
            {
                if (bitmap[i] == findColour)
                    bitmap[i] = replaceColour;
            }
        }
    }
}