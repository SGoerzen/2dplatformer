using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TwoDPlatformer.Entities;

namespace TwoDPlatformer
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphicsDevice;
        public SpriteBatch spriteBatch;

        private Player player;        
        public Game()
        {
            graphicsDevice = new GraphicsDeviceManager(this)
            {
                PreferMultiSampling = true
            };

        }

        protected override void Initialize()
        {
            Components.Add(new Player(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Content.RootDirectory = "Assets";
            base.LoadContent();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
            {
                Exit();
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}