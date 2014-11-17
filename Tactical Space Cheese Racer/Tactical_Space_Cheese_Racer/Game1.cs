using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tactical_Space_Cheese_Racer
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Texture2D textureBackground, texturePointer;
        Rectangle MouseLocation;
        public Rectangle buttonPlay, buttonClose;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Sets width and height for the viewport and makes it fullscreen.
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            buttonPlay = new Rectangle(325, 453, (581 - 325), (579 - 453));
            buttonClose = new Rectangle(682, 451, (938 - 682), (579 - 451));
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureBackground = Content.Load<Texture2D>("Background");
            texturePointer = Content.Load<Texture2D>("Pointer");


        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //If mouse intersects left button, change to green
            MouseLocation.X = Mouse.GetState().X;
            MouseLocation.Y = Mouse.GetState().Y;
            MouseLocation.Height = 0;
            MouseLocation.Width = 0;


            if (MouseLocation.Intersects(buttonPlay))
            {
                textureBackground = Content.Load<Texture2D>("BackgroundLeftButton");
            }
            else if (MouseLocation.Intersects(buttonClose))
            {
                textureBackground = Content.Load<Texture2D>("BackgroundRightButton");
                if(Mouse.GetState().LeftButton == ButtonState.Pressed){
                    Exit();
                }
            }
            else
            {
                textureBackground = Content.Load<Texture2D>("Background");
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(textureBackground, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(texturePointer, new Vector2(MouseLocation.X,MouseLocation.Y), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
