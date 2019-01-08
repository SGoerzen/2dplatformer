using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HippieGame.Core
{
    public struct AnimationFrame
    {
        public Rectangle SourceRect;
        public TimeSpan Duration;
    }
    public class Animation
    {
        public Texture2D SpriteSheet { get; private set; }
        private List<AnimationFrame> Frames;
        
        public TimeSpan Duration { get; private set; }
        private TimeSpan timeIntoAnimation;
        
        public Rectangle CurrentRectangle
        {
            get
            {
                AnimationFrame? currentFrame = null;

                // See if we can find the frame
                TimeSpan accumulatedTime;
                foreach(var frame in Frames)
                {
                    if (accumulatedTime + frame.Duration >= timeIntoAnimation)
                    {
                        currentFrame = frame;
                        break;
                    }
                    accumulatedTime += frame.Duration;
                }

                // If no frame was found, then try the last frame, 
                // just in case timeIntoAnimation somehow exceeds Duration
                if (!currentFrame.HasValue)
                {
                    currentFrame = Frames.LastOrDefault ();
                }

                return currentFrame.Value.SourceRect;
            }
        }
           
        public Animation(Texture2D spriteSheet)
        {
            SpriteSheet = spriteSheet;
            Frames = new List<AnimationFrame>();
        }

        public void AddFrame(Rectangle sourceRect, float seconds)
        {
            AddFrame(sourceRect, TimeSpan.FromSeconds(seconds));
        }
        public void AddFrame(Rectangle sourceRect, TimeSpan duration)
        {
            AddFrame(new AnimationFrame()
            {
                SourceRect = sourceRect, 
                Duration = duration
            });
            Duration = Duration.Add(duration);
        }

        public void AddFrame(AnimationFrame frame)
        {
            Frames.Add(frame);
        }

        public void Update(GameTime gameTime)
        {
            double secondsIntoAnimation = timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;
            double remainder = secondsIntoAnimation % Duration.TotalSeconds;
            timeIntoAnimation = TimeSpan.FromSeconds (remainder);
        }
    }
}