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
    public class StartScreen : GameScreens
    {
        public MenuComponent Menu { get; set; }

        private SpriteBatch spriteBatch;
        string[] menuItems = { "Start Game", "Help", "Credits", "Quit" };
        public StartScreen(Game game): base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g.spriteBatch;
            SpriteFont regularFont = g.Content.Load<SpriteFont>("regularFont");
            SpriteFont hilightFont = game.Content.Load<SpriteFont>("hilightFont");

            Texture2D backGroundTexture = g.Content.Load<Texture2D>("backgroundsingle");
            Background b = new Background(game, spriteBatch, backGroundTexture);
            Components.Add(b);

            Menu = new MenuComponent(game, spriteBatch, regularFont, hilightFont, menuItems);
            this.Components.Add(Menu);
        }

    }
}