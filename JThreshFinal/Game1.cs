using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//Prog2370
//Josh Thresh
//6484240

namespace JThreshFinal
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        private StartScreen startScreen;
        private PlayScreen playScreen;
        private HelpScreen helpScreen;
        private CreditScreen creditScreen;

        Song menuMusic;
        Song gameMusic;
        private bool wasGame;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Screen Size
            graphics.PreferredBackBufferWidth = 1180;
            graphics.PreferredBackBufferHeight = 700;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        private void hideAllScenes()
        {
            GameScreens gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScreens)
                {
                    gs = (GameScreens)item;
                    gs.hide();
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //Plays song on repeat
            menuMusic = Content.Load<Microsoft.Xna.Framework.Media.Song>("menus");
            gameMusic = Content.Load<Microsoft.Xna.Framework.Media.Song>("bossLoop");
            MediaPlayer.Volume = 0.8f;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(menuMusic);

            startScreen = new StartScreen(this);
            this.Components.Add(startScreen);
            startScreen.show();

            playScreen = new PlayScreen(this);
            this.Components.Add(playScreen);

            helpScreen = new HelpScreen(this);
            this.Components.Add(helpScreen);

            creditScreen = new CreditScreen(this);
            this.Components.Add(creditScreen);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            int selectedIndex = 0;

            KeyboardState ks = Keyboard.GetState();

            if (startScreen.Enabled)
            {
                //MediaPlayer.Stop();  //presently no sound menu
                selectedIndex = startScreen.Menu.SelectedIndex;
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    MediaPlayer.Play(gameMusic);
                    playScreen.show();
                }
                else if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScreen.show();
                }
                else if(selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    creditScreen.show();
                }
                else if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (playScreen.Enabled)
            {
                wasGame = true;
                if (ks.IsKeyDown(Keys.Escape))
                {
                    BackToMenu();
                }
            }
            else if (helpScreen.Enabled || creditScreen.Enabled)
            {
                wasGame = false;
                if(ks.IsKeyDown(Keys.Escape))
                {
                    BackToMenu();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void BackToMenu()
        {
            hideAllScenes();
            startScreen.show();
            if(wasGame == true)
                MediaPlayer.Play(menuMusic);
        }
    }
}
