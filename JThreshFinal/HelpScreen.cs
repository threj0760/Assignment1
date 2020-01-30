using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JThreshFinal
{
    class HelpScreen : GameScreens
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpBackground;
        public HelpScreen(Game game) : base(game)
        {
        Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            helpBackground = g.Content.Load<Texture2D>("helpBackground");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpBackground, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
