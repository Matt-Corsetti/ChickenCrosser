using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ChickenCrosser
{
    public class WolfCharacter : DrawableGameComponent
    {
        public SpriteBatch spriteBatch;
        public Texture2D tex;
        public Vector2 position;
        public Vector2 speed;
        public SoundEffect wolSound;
        public WolfCharacter(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.speed = speed;
            position = new Vector2((Shared.stage.X - tex.Width),
                Shared.stage.Y - tex.Height);

           
        }
        public override void Update(GameTime gameTime)
        {
            ChickenCrosser chicken = (ChickenCrosser)Game;
            KeyboardState keyboardState = Keyboard.GetState();

            position += speed;
           
            if (position.Y <= 0)
            {
                speed.Y = Math.Abs(speed.Y);
                //chicken.wolfSound.Play();
            }
            if (position.X + tex.Width >= Shared.stage.X)
            {
                speed.X = -Math.Abs(speed.X);
                
            }
            if (position.X <= 0)
            {
                speed.X = Math.Abs(speed.X);
                
            }
            if (position.Y + tex.Height >= Shared.stage.Y)
            {
                speed.Y = -Math.Abs(speed.Y);
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
       
    }
}
