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
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private ChickenCharacter chickenCharacter;
        private WolfCharacter wolfCharacter;
        private Vector2 wolfSpeed;
        private Texture2D actionTex;
        private Texture2D chickenTex;
        private Celebration celebration;

        public ActionScene (Game game): base(game)
        {
            ChickenCrosser chicken = (ChickenCrosser)game;
            this.spriteBatch = chicken.spriteBatch;
            chickenTex = chicken.Content.Load<Texture2D>("Images/Chicken");
            actionTex = chicken.Content.Load<Texture2D>("Images/Action");

            chickenCharacter = new ChickenCharacter(game, spriteBatch, chickenTex);
            this.Components.Add(chickenCharacter);

            Texture2D celebrationTex = chicken.Content.Load<Texture2D>("Images/Celebration");
            celebration = new Celebration(chicken, spriteBatch, celebrationTex, Vector2.Zero, 5);
            this.Components.Add(celebration);


            Random randomWolfSpeed = new Random();


            int x = randomWolfSpeed.Next(8, 16);
            int y = randomWolfSpeed.Next(8, 16);
            int signX = randomWolfSpeed.Next(0, 2);
            int signY = randomWolfSpeed.Next(0, 2);

            if (signX == 1)
            {
                x = -x;
            }
            if (signY == 1)
            {
                y = -y;
            }
            wolfSpeed = new Vector2(x, y);

            Texture2D wolfTex = chicken.Content.Load<Texture2D>("Images/Wolf");
            wolfCharacter = new WolfCharacter(game, spriteBatch, wolfTex, wolfSpeed);

            SoundEffect explosion = chicken.Content.Load<SoundEffect>("Music/Explosion");

            this.Components.Add(wolfCharacter);
            CollisionDetection cd = new CollisionDetection(chicken, chickenCharacter, wolfCharacter, celebration, explosion);
            this.Components.Add(cd);

        }
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(actionTex, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
