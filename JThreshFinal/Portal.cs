using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JThreshFinal
{
    class Portal : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D portalTexture;
        //Background background;

        const int FRAMESIZE = 31;
        const float SCALE = 2.5f;

        const int FIRSTFRAME = 0;
        const int TOTALFRAMES = 9;

        private int currentFrame = FIRSTFRAME;

        List<Rectangle> portalFrames;

        const int FRAMEDELAYMAXCOUNT = 10;
        int currentFrameDelayCount = 0;

        Rectangle portal;

        public Portal(Game game, SpriteBatch spriteBatch, Texture2D portalTexture) :base(game)
        {
            this.spriteBatch = spriteBatch;
            this.portalTexture = portalTexture;
            //this.background = background;

            portal = new Rectangle(1080, 500, (int)(SCALE*FRAMESIZE), (int)(SCALE*FRAMESIZE));

            portalFrames = new List<Rectangle>();

            //portal frames
            portalFrames.Add(new Rectangle(0, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(31, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(62, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(93, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(124, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(155, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(186, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(217, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(248, 0, FRAMESIZE, FRAMESIZE));
            portalFrames.Add(new Rectangle(279, 0, FRAMESIZE, FRAMESIZE));
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(portalTexture, portal, portalFrames.ElementAt<Rectangle>(currentFrame), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            currentFrameDelayCount++;
            if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
            {
                currentFrameDelayCount = 0;
                currentFrame++;  //advance to the next frame
            }
            if (currentFrame > TOTALFRAMES)
                currentFrame = FIRSTFRAME;

            base.Update(gameTime);
        }
    }
}
