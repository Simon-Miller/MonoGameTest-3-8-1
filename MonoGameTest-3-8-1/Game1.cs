using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace MonoGameTest_3_8_1
{
    public class Game1 : Game
    {
        // ---------------------------------
        const int wide = 640;
        const int high = 480;
        const int numPixels = wide * high;
        const bool isFullScreen = false;
        const int BALLS = 10;
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

            this.ballSprite = Texture2D.FromFile(graphics.GraphicsDevice, "..\\..\\..\\cool-ball.png");
            

            this.setupBalls();

            base.Initialize();
        }

        Texture2D screen;
        Vector2 screenPosition = new Vector2(0, 0);

        Texture2D sprite;
        Vector2 spritePosition = new Vector2(100, 100);

        Texture2D ballSprite;

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


        Random random = new Random();

        Ball[] balls = new Ball[BALLS];


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
                var position = new Vector2(random.Next(wide - 32), random.Next(high -32));
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

        const int maxX = wide - 32;
        const int maxY = high - 32;
        private void updateBallPosition(Ball ball)
        {
            if(ball.DirectionY == -1 && ball.Position.Y < 0)
                ball.DirectionY = 1;
            
            if(ball.DirectionY == 1 && ball.Position.Y >= maxY)
                ball.DirectionY = -1;
            
            if(ball.DirectionX == -1 && ball.Position.X < 0)
                ball.DirectionX = 1;
            
            if(ball.DirectionX == 1 && ball.Position.X >= maxX)
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

    class Ball
    {
        public Vector2 Position;
        public sbyte DirectionX;
        public sbyte DirectionY;
        public int XSpeed;
        public int YSpeed;
    }
}