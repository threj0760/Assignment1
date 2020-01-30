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
    public class PlayScreen : GameScreens
    {
        private SpriteBatch spriteBatch;

        public PlayScreen (Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;

            Texture2D backGroundTexture = g.Content.Load<Texture2D>("gameBackground");
            Background b = new Background(game, spriteBatch, backGroundTexture);
            Components.Add(b);

            Texture2D portalTexture = g.Content.Load<Texture2D>("portalSheet");
            Portal por = new Portal(game, spriteBatch, portalTexture);
            Components.Add(por);

            Texture2D playerTexture = g.Content.Load<Texture2D>("playerCharacter");
            Player p = new Player(game, spriteBatch, playerTexture, b);
            Components.Add(p);  
        }

        public override void Update(GameTime gameTime)
        {          
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
