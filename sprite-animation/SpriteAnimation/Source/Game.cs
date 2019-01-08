using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TwoDPlatformer
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphicsDevice;
        public SpriteBatch spriteBatch;

        private Texture2D body;
        
        public Game()
        {
            graphicsDevice = new GraphicsDeviceManager(this)
            {
                PreferMultiSampling = true
            };
           
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Content.RootDirectory = "Assets";

            body = Content.Load<Texture2D>("Sprites/Body");
        }

        protected override void UnloadContent()
        {
        }

        private Vector2 position = Vector2.Zero;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X--;
            } else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X++;
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            
            spriteBatch.Draw(body, position, Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}