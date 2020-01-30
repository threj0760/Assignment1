using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.XNA;

namespace JThreshFinal
{
    class Background : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D backgroundTexture;

        List<Rectangle> rigidBodyList;
        public List<Rectangle> RigidBodyList { get => rigidBodyList; }

        public Background(Game game, SpriteBatch spriteBatch, Texture2D backgroundTexture) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.backgroundTexture = backgroundTexture;

            rigidBodyList = new List<Rectangle>();

            //Top
            rigidBodyList.Add(new Rectangle(0, 200, 1180, 5));
            //Bottom
            rigidBodyList.Add(new Rectangle(0, 750, 1180, 5));
            //Right Wall
            rigidBodyList.Add(new Rectangle(1240, 0, 5, 700));
            //Left Wall
            rigidBodyList.Add(new Rectangle(0, 0, 5, 700));
            //Obstacles
            rigidBodyList.Add(new Rectangle(375, 600, 5, 60));
            rigidBodyList.Add(new Rectangle(635, 699, 5, 60));
            rigidBodyList.Add(new Rectangle(610, 300, 5, 60));
            rigidBodyList.Add(new Rectangle(670, 645, 5, 60));
            rigidBodyList.Add(new Rectangle(900, 350, 5, 60));
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 1192, 701), Color.White);

            //foreach (Rectangle r in RigidBodyList)
            //spriteBatch.DrawRectangle(r, Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
