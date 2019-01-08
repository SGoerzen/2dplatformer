using System;
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
            
            animIdle = new Animation(content.Load<Texture2D>(basePath + "Idle"));

            int lastX = 24;
            for (int i = 0, width = 81; i < 6; i++, lastX += i*width)
                animIdle.AddFrame(new Rectangle(lastX, 26, width, 74), .25f);
            for (int i = 6, width = 80; i < 12; i++, lastX += i*width)
                animIdle.AddFrame(new Rectangle( lastX,26,width,74), .25f);
            
            animBlink = new Animation(content.Load<Texture2D>(basePath + "Blink"));
            animJump = new Animation(content.Load<Texture2D>(basePath + "Jump"));
            animRun = new Animation(content.Load<Texture2D>(basePath + "Run"));

            animCurrent = animIdle;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            animCurrent.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(animCurrent.SpriteSheet, position, animCurrent.CurrentRectangle, Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}