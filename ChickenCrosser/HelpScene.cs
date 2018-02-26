using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChickenCrosser
{
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D helpTex;
        public HelpScene(Game game) : base(game)
        {
            ChickenCrosser chicken = (ChickenCrosser)game;
            this.spriteBatch = chicken.spriteBatch;
            helpTex = chicken.Content.Load<Texture2D>("Images/Help");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpTex, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

       
    }
}
