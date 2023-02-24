using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameTest_3_8_1
{
    public class Game1 : Game
    {
        const int wide = 640;
        const int high = 480;
        const int numPixels = wide * high;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // TURN OFF FULL SCREEN by commenting out, or setting to false.
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 480;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var currentPath = System.IO.Directory.GetCurrentDirectory();
            this.sprite = Texture2D.FromFile(_graphics.GraphicsDevice, "..\\..\\..\\Icon.bmp");

            this.screen = new Texture2D(_graphics.GraphicsDevice, wide, high);

            base.Initialize();
        }

        Texture2D sprite;
        Texture2D screen;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        
        UInt32[] screenData = new UInt32[numPixels];
        Random random = new Random();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for (var i = 0; i < numPixels; i++)
                screenData[i] = ((uint)(random.Next(0xffffff)) | 0xff000000);

            screen.SetData<UInt32>(screenData);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(screen, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(sprite, new Vector2(100,100), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}