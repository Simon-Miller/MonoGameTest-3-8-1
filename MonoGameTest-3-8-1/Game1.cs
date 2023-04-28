using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameTest_3_8_1
{
    public class Game1 : Game
    {
        // ---------------------------------
        private const int wide = 640;
        private const int high = 480;
        private const int numPixels = wide * high;
        private const bool isFullScreen = false;
        private const int BALLS = 10;
        // ---------------------------------

        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

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
            sprite = Texture2D.FromFile(graphics.GraphicsDevice, "..\\..\\..\\..\\MonoGameTest-3-8-1\\Icon.bmp");

            screen = new Texture2D(graphics.GraphicsDevice, wide, high);

            ballSprite = Texture2D.FromFile(graphics.GraphicsDevice, "..\\..\\..\\..\\MonoGameTest-3-8-1\\cool-ball.png");


            setupBalls();

            base.Initialize();
        }

        private Texture2D screen;
        private Vector2 screenPosition = new Vector2(0, 0);
        private Texture2D sprite;
        private Vector2 spritePosition = new Vector2(100, 100);
        private Texture2D ballSprite;

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

            // update balls.
            for (int i = 0; i < balls.Length; i++)
                updateBallPosition(balls[i]);

            base.Update(gameTime);
        }

        private Random random = new Random();
        private Ball[] balls = new Ball[BALLS];


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            // TODO: Add your drawing code here
            spriteBatch.Begin();


            for (int i = 0; i < balls.Length; i++)
                spriteBatch.Draw(ballSprite, balls[i].Position, Color.White);

            spriteBatch.Draw(sprite, spritePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void setupBalls()
        {
            for (int i = 0; i < balls.Length; i++)
            {
                var position = new Vector2(random.Next(wide - 32), random.Next(high - 32));
                var directionX = (sbyte)(((sbyte)random.Next(1) * 2) - 1);
                var directionY = (sbyte)(((sbyte)random.Next(1) * 2) - 1);
                var xSpeed = random.Next(10) + 1;
                var ySpeed = random.Next(10) + 1;

                balls[i] = new Ball()
                {
                    Position = position,
                    DirectionX = directionX,
                    DirectionY = directionY,
                    XSpeed = xSpeed,
                    YSpeed = ySpeed,
                };
            }
        }

        private const int maxX = wide - 32;
        private const int maxY = high - 32;
        private void updateBallPosition(Ball ball)
        {
            if (ball.DirectionY == -1 && ball.Position.Y < 0)
                ball.DirectionY = 1;

            if (ball.DirectionY == 1 && ball.Position.Y >= maxY)
                ball.DirectionY = -1;

            if (ball.DirectionX == -1 && ball.Position.X < 0)
                ball.DirectionX = 1;

            if (ball.DirectionX == 1 && ball.Position.X >= maxX)
                ball.DirectionX = -1;

            float newX = ball.Position.X;
            float newY = ball.Position.Y;

            if (ball.DirectionX == 1)
                newX += ball.XSpeed;
            else
                newX -= ball.XSpeed;

            if (ball.DirectionY == 1)
                newY += ball.YSpeed;
            else
                newY -= ball.YSpeed;

            ball.Position = new Vector2(newX, newY);
        }
    }

    internal class Ball
    {
        public Vector2 Position;
        public sbyte DirectionX;
        public sbyte DirectionY;
        public int XSpeed;
        public int YSpeed;
    }
}