using HippieGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TwoDPlatformer.Entities
{
    public class Player : DrawableGameComponent
    {
        private Animation animBlink, animIdle, animJump, animRun, animCurrent;
        private SpriteBatch spriteBatch;
        private Vector2 position;
        public Player(Game game) : base(game)
        {
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            
            var content = Game.Content;
            var basePath = "Assets/Sprites/Player/";
            
            animCurrent = animIdle = new Animation(content.Load<Texture2D>(basePath + "Idle"));
            //animIdle.AddFrame();
            
            animBlink = new Animation(content.Load<Texture2D>(basePath + "Blink"));
            animJump = new Animation(content.Load<Texture2D>(basePath + "Jump"));
            animRun = new Animation(content.Load<Texture2D>(basePath + "Run"));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            animCurrent.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(animCurrent.SpriteSheet, position, animCurrent.CurrentRectangle, Color.White);

            base.Draw(gameTime);
        }
    }
}