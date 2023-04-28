using Microsoft.Xna.Framework;

namespace Graphics
{
    public class ScreenDisplay
    {
        public ScreenDisplay(GraphicsDeviceManager graphicsDevice, uint gameWidth, uint gameHeight)
        {
            this.graphicsDevice = graphicsDevice;
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;

            detectResolutions();
        }

        private readonly GraphicsDeviceManager graphicsDevice;
        private readonly uint gameWidth;
        private readonly uint gameHeight;
        private uint zoom = 1;
        private bool pillarBoxed = false; // set to true when pillarboxing is necessary.
        private int? pillarboxOffsetX = null;
        private int? pillarboxOffsetY = null;

        private void detectResolutions()
        {
            if (graphicsDevice.GraphicsDevice is null)
            {
                graphicsDevice.DeviceCreated += GraphicsDevice_DeviceCreated;
            }
            else
            {
                GraphicsDevice_DeviceCreated(this, null!);
            }

        }

        private void GraphicsDevice_DeviceCreated(object? sender, EventArgs e)
        {
            // should only care to hear about this the once.
            graphicsDevice.DeviceCreated -= GraphicsDevice_DeviceCreated;

            // TODO: Generate a resolution selector + full screen option?

            var gameAspectRatio = (float)gameWidth / gameHeight;

            var resolutionsMatchingAspectRatio = graphicsDevice.GraphicsDevice.Adapter.SupportedDisplayModes
                                                    .Where(r => r.AspectRatio == gameAspectRatio)
                                                    .ToList();

            if (resolutionsMatchingAspectRatio.Any())
            {
                var matchingResolution = resolutionsMatchingAspectRatio.FirstOrDefault(r =>
                                            r.Width == gameWidth
                                            && r.Height == gameHeight);

                if (matchingResolution is not null)
                {
                    // we have an exact match and can set the preferred back-buffer width / height to match.
                    return;
                }

                if (matchingResolution is null)
                    matchingResolution = resolutionsMatchingAspectRatio.FirstOrDefault(r =>
                                            r.Width % gameWidth == 0
                                            && r.Width % gameHeight == 0);

                if (matchingResolution is null)
                {
                    // the aspect ratio(s) available might match, but no exact resolution or multiple of the resolution.
                    // in this case, we want to PILLAR-BOX
                    pillarBoxResolution();
                }
                else
                {
                    // we have an exact aspect ratio match, and need to set the zoom to an exact number

                    return;
                }
            }
            else
            {
                // we don't have an aspect ratio match?  This means we have to PILLAR-BOX
                pillarBoxResolution();
            }

            //foreach (var mode in graphicsDevice.GraphicsDevice.Adapter.SupportedDisplayModes)
            //{
            //    // wow!  Graphics card at work only supports ONE resolution!  (1080p) // SM: whilst in RDP?
            //}
        }

        private void pillarBoxResolution()
        {
            // 1.  is there a resolution that matches the height (or multiple of) and is greater than the width?

            // 2.  Is there a resolution that matches the width (or multiple of), and is greater than the height?

            // 3.  last option to lump to...
            //     the first available resolution that is greater than the width and height.
        }
    }
}
