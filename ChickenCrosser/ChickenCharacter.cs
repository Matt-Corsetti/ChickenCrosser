using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace ChickenCrosser
{
    public class ChickenCharacter : DrawableGameComponent
    {
        public SpriteBatch spriteBatch;
        public Texture2D tex;
        public Vector2 position;
        public Vector2 speed;
        public String winString;
        public int attempts = 0;
        public Song fireworks;
        

        public ChickenCharacter(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex) : base(game)
        {
            ChickenCrosser chicken = (ChickenCrosser)game;
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            position = new Vector2((Shared.stage.X - tex.Width) / 2,
                Shared.stage.Y - tex.Height);
            speed = new Vector2(0, 5);
        }

        public override void Update(GameTime gameTime)
        {

            ChickenCrosser chicken = (ChickenCrosser)Game;

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position -= speed;
            }
            if (position.Y < 0)
            {
                chicken.winString.Visible = true;
                speed.Y = 0;
                this.Visible = false;
                position = new Vector2(0, -300);
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    chicken.chickenSound.Play();
                    NewGame();
                }

            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                position += speed;
                if (position.Y + tex.Height >= Shared.stage.Y)
                {
                    position.Y = Shared.stage.Y - tex.Height;
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }

        public void NewGame()
        {
            ChickenCrosser chicken = (ChickenCrosser)Game;
            position = new Vector2((Shared.stage.X - tex.Width) / 2,
            Shared.stage.Y - tex.Height);
            speed = new Vector2(0, 5);
            chicken.winString.Visible = false;
            chicken.attempts = 1;
            this.Visible = true;

        }
 
    }
}
