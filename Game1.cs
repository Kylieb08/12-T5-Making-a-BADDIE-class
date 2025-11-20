using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace _12_T5_Making_a_BADDIE_class
{
    public enum Screen
    {
        Title,
        House,
        End
    }

    public class Game1 : Game
    {
        Random generator;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window, marioRect;
        Screen screen;
        Ghost ghost1;
        List<Texture2D> ghostTextures;
        Texture2D backgroudTexture, marioTexture, titleTexture, endTexture;
        MouseState mouseState;
        KeyboardState keyboardState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Title;
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            ghostTextures = new List<Texture2D>();

            marioRect = new Rectangle(0, 0, 30, 30);

            base.Initialize();

            this.IsMouseVisible = false;
            ghost1 = new Ghost(ghostTextures, new Rectangle(150, 250, 40, 40));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            marioTexture = Content.Load<Texture2D>("Images/mario");
            backgroudTexture = Content.Load<Texture2D>("Images/haunted-background");
            titleTexture = Content.Load<Texture2D>("Images/haunted-title");
            endTexture = Content.Load<Texture2D>("Images/haunted-end-screen");
            ghostTextures.Add(Content.Load<Texture2D>("Images/boo-stopped"));
            for (int i = 1; i <= 8;  i++)
            {
                ghostTextures.Add(Content.Load<Texture2D>($"Images/boo-move-{i}"));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            marioRect.Location = mouseState.Position;

            if (screen == Screen.Title)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                    screen = Screen.House;
            }

            else if (screen == Screen.House)
            {
                ghost1.Update(gameTime, mouseState);
                if (ghost1.Contains(mouseState.Position))
                    screen = Screen.End;
            }

                

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Title)
                _spriteBatch.Draw(titleTexture, window, Color.White);

            else if (screen == Screen.House)
            {
                _spriteBatch.Draw(backgroudTexture, window, Color.White);
                ghost1.Draw(_spriteBatch);
            }

            else
                _spriteBatch.Draw(endTexture, window, Color.White);

            _spriteBatch.Draw(marioTexture, marioRect, Color.White);

                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
