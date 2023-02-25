using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameTest_3_8_1
{
    public class Game1 : Game
    {
        // ---------------------------------
        const int wide = 640;
        const int high = 480;
        const int numPixels = wide * high;
        const bool isFullScreen = false;
        // ---------------------------------

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // TURN OFF FULL SCREEN by commenting out, or setting to false.
            graphics.IsFullScreen = isFullScreen;
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var currentPath = System.IO.Directory.GetCurrentDirectory();
            this.sprite = Texture2D.FromFile(graphics.GraphicsDevice, "..\\..\\..\\Icon.bmp");

            this.screen = new Texture2D(graphics.GraphicsDevice, wide, high);

            base.Initialize();
        }

        Texture2D screen;
        Vector2 screenPosition = new Vector2(0, 0);

        Texture2D sprite;
        Vector2 spritePosition = new Vector2(100, 100);

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (keyboardState.IsKeyDown(Keys.Up)) spritePosition.Y--;
            if (keyboardState.IsKeyDown(Keys.Down)) spritePosition.Y++;
            if (keyboardState.IsKeyDown(Keys.Left)) spritePosition.X--;
            if (keyboardState.IsKeyDown(Keys.Right)) spritePosition.X++;

            base.Update(gameTime);
        }

        
        UInt32[] screenData = new UInt32[numPixels];
        Random random = new Random();
        

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            for (var i = 0; i < numPixels; i++)
                screenData[i] = ((uint)(random.Next(0xffffff)) | 0xff000000);

            screen.SetData<UInt32>(screenData);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(screen, screenPosition, Color.White);
            spriteBatch.Draw(sprite, spritePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}