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
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, hilightFont;
        private List<string> menuItems;
        public int SelectedIndex { get; set; }
        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color hilightColor = Color.Red;

        private KeyboardState oldState; //Used to ensure on a single keystroke is registers else it cycles per game cycle

        public MenuComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            SpriteFont hilightFont,
            string[] menus) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.hilightFont = hilightFont;
            menuItems = menus.ToList();  

        }

        public override void Update(GameTime gameTime)
        {
            //If key is pressed it will move to next item in the list
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                SelectedIndex++;
                if (SelectedIndex == menuItems.Count)
                {
                    SelectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Count - 1;
                }
            }
            oldState = ks;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {       
            //Sets position of the menu
            position = new Vector2(GraphicsDevice.Viewport.Width / (float)2.2, GraphicsDevice.Viewport.Height / 2);
            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (SelectedIndex == i)
                {
                    spriteBatch.DrawString(hilightFont, menuItems[i],
                        position, hilightColor);
                    position.Y += hilightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i],
                        position, regularColor);
                    position.Y += regularFont.LineSpacing;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
