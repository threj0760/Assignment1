using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PROG2370CollisionLibrary;
using Microsoft.Xna.Framework.Audio;
using C3.XNA;
using Point = Microsoft.Xna.Framework.Point;
using Microsoft.Xna.Framework.Content;
//Prog2370
//Josh Thresh
//6484240


namespace JThreshFinal
{
    class Player : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D playerTexture;
        Background background;

        SoundEffect winSound;    

        const int FRAMEWIDTH = 171;
        const int FRAMEHEIGHT = 177;
        const float SCALE = 1.3f;

        //Consts for animation
        const int STANDFRAME = 0;
        const int IDLEFRAMES = 9;
        const int FIRSTWALKFRAMERIGHT = 10;
        const int FIRSTWALKFRAMELEFT = 20;
        const int FIRSTWALKFRAMEDOWN = 30;
        const int FIRSTWALKFRAMEUP = 40;
        const int WALKFRAMESRIGHT = 19;
        const int WALKFRAMESLEFT = 29;
        const int WALKFRAMESDOWN = 39;
        const int WALKFRAMESUP = 49;

        private int currentFrame = STANDFRAME; //initial frame on start-up
        List<Rectangle> playerFrames;

        const int FRAMEDELAYMAXCOUNT = 3;
        int currentFrameDelayCount = 0;

        const float SPEED = 2.5f;
        Vector2 velocity;

        Rectangle player;
        Rectangle winBox;

        protected override void LoadContent()
        {
            winSound = Game.Content.Load<SoundEffect>("winSound.wav");

            base.LoadContent();
        }

        public Player(Game game, SpriteBatch spriteBatch, Texture2D playerTexture, Background background) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.playerTexture = playerTexture;
            this.background = background; 

            player = new Rectangle(80, 400, (int)(SCALE * FRAMEWIDTH), (int)(SCALE * FRAMEHEIGHT));
            winBox = new Rectangle(1150, 520, 30,30);
            velocity = new Vector2(0);

            playerFrames = new List<Rectangle>();

            //add stand frame/idle
            playerFrames.Add(new Rectangle(0, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(0, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(354, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(531, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(708, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(885, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1062, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1239, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1416, 1368, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1593, 1368, FRAMEWIDTH, FRAMEHEIGHT));

            //add player walk frames right
            playerFrames.Add(new Rectangle(0, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(176, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(354, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(531, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(708, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(885, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1062, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1239, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1416, 513, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1593, 513, FRAMEWIDTH, FRAMEHEIGHT));

            // add player walk frames left
            playerFrames.Add(new Rectangle(0, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(176, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(354, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(531, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(708, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(885, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1062, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1239, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1416, 342, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1593, 342, FRAMEWIDTH, FRAMEHEIGHT));

            // add player walk frames down
            playerFrames.Add(new Rectangle(0, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(176, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(354, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(531, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(708, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(885, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1062, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1239, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1416, 0, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1593, 0, FRAMEWIDTH, FRAMEHEIGHT));

            // add player walk frames up
            playerFrames.Add(new Rectangle(0, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(176, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(354, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(531, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(708, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(885, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1062, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1239, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1416, 171, FRAMEWIDTH, FRAMEHEIGHT));
            playerFrames.Add(new Rectangle(1593, 171, FRAMEWIDTH, FRAMEHEIGHT));
        }         

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture, player, playerFrames.ElementAt<Rectangle>(currentFrame), Color.White);
            //spriteBatch.DrawRectangle(player, Color.Yellow);
            //spriteBatch.DrawRectangle(winBox, Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);         
        }

        public override void Update(GameTime gameTime)
        {
            //stops movement on release of key
            velocity.X = 0;
            velocity.Y = 0;

            //get input
            KeyboardState keyState = Keyboard.GetState();
          
            if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            {
                velocity.X = SPEED;
            }
            else if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            {
                velocity.X = -SPEED;
            }
            else if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            {
                velocity.Y = SPEED;
            }
            else if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            {
                velocity.Y = -SPEED;
            }

            // our new location becomes the "proposed" location
            Rectangle proposedLocation = new Rectangle(player.X + (int)velocity.X, player.Y + (int)velocity.Y, player.Width, player.Height);

            // check if move is ok
            Sides collisionSides = proposedLocation.CheckCollisions(background.RigidBodyList);

            if ((collisionSides & Sides.RIGHT) == Sides.RIGHT)
                if (velocity.X > 0)
                    velocity.X = 0;

            if ((collisionSides & Sides.LEFT) == Sides.LEFT)
                if (velocity.X < 0)
                    velocity.X = 0;

            if ((collisionSides & Sides.BOTTOM) == Sides.BOTTOM)
            {
                if (velocity.Y > 0)
                    velocity.Y = 0;
            }

            if ((collisionSides & Sides.TOP) == Sides.TOP)
            {
                if (velocity.Y < 0)
                    velocity.Y = 0;
            }

            //Movement
            player.X = player.X + (int)velocity.X;
            player.Y = player.Y + (int)velocity.Y;
            
            //Standing/ilde
            if (velocity.X == 0 && velocity.Y == 0)
            {
                currentFrameDelayCount++;
                if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
                {
                    currentFrameDelayCount = 0;
                    currentFrame++;  //advance to the next frame
                }
                if (currentFrame > IDLEFRAMES)
                    currentFrame = STANDFRAME;
            }
            //walking
            //Right
            else if(velocity.X > 0)
            {
                if (currentFrame < FIRSTWALKFRAMERIGHT && currentFrame > STANDFRAME)
                {
                    currentFrame = FIRSTWALKFRAMELEFT;
                }               
                currentFrameDelayCount++;
                if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
                {
                    currentFrameDelayCount = 0;
                    currentFrame++;  //advance to the next frame
                }
                if (currentFrame > WALKFRAMESRIGHT)
                    currentFrame = FIRSTWALKFRAMERIGHT;
            }
            //Left
            else if (velocity.X < 0)
            {       
                if(currentFrame < FIRSTWALKFRAMELEFT && currentFrame > FIRSTWALKFRAMERIGHT || currentFrame < FIRSTWALKFRAMELEFT && currentFrame > STANDFRAME)
                {
                    currentFrame = FIRSTWALKFRAMELEFT;
                }
                currentFrameDelayCount++;
                if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
                {
                    currentFrameDelayCount = 0;
                    currentFrame++;  //advance to the next frame
                }
                if (currentFrame > WALKFRAMESLEFT)
                    currentFrame = FIRSTWALKFRAMELEFT;
            }
            //Down
            else if (velocity.Y > 0)
            {         
                if (currentFrame < FIRSTWALKFRAMEDOWN && currentFrame > FIRSTWALKFRAMEUP || currentFrame < FIRSTWALKFRAMEDOWN && currentFrame > STANDFRAME)
                {
                    currentFrame = FIRSTWALKFRAMEDOWN;
                }
                currentFrameDelayCount++;
                if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
                {
                    currentFrameDelayCount = 0;
                    currentFrame++;  //advance to the next frame  
                    //player gets larger when approaching camera
                    player.Height++;
                    player.Width++;
                }
                if (currentFrame > WALKFRAMESDOWN)
                    currentFrame = FIRSTWALKFRAMEDOWN;
            }
            //Up
            else if (velocity.Y < 0)
            {          
                if (currentFrame < FIRSTWALKFRAMEUP && currentFrame > FIRSTWALKFRAMEDOWN || currentFrame < FIRSTWALKFRAMEUP && currentFrame > STANDFRAME)
                {
                    currentFrame = FIRSTWALKFRAMEUP;
                }
                currentFrameDelayCount++;
                if (currentFrameDelayCount > FRAMEDELAYMAXCOUNT)
                {
                    currentFrameDelayCount = 0;
                    currentFrame++;  //advance to the next frame  
                    //Player gets smaller as the move from camera
                    player.Height--;
                    player.Width--;
                }
                if (currentFrame > WALKFRAMESUP)
                    currentFrame = FIRSTWALKFRAMEUP;
            }
            if(player.Right == winBox.Right)
            {
                player.Location = new Point(80, 400);
                //winSound.Play();
            }
        
            base.Update(gameTime);
        }
    }
}
