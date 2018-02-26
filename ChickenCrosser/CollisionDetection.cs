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
    public class CollisionDetection : GameComponent
    {
        private ChickenCharacter chicken;
        public WolfCharacter wolf;
        public int attempts;
        private SoundEffect explosion;
        private Celebration celebration;

        public CollisionDetection(Game game,
            ChickenCharacter chicken,
            WolfCharacter wolf,
            Celebration celebration,
            SoundEffect explosion) : base(game)
        {
            ChickenCrosser chickenCrosser = (ChickenCrosser)game;
 
            this.chicken = chicken;
            this.wolf = wolf;
            this.celebration = celebration;
            this.explosion = explosion;

        }
        public override void Update(GameTime gameTime)
        {
            ChickenCrosser chickenCrosser = (ChickenCrosser)Game;

            if (wolf.getBound().Intersects(chicken.getBound()))
            {
                KeyboardState keyboardState = Keyboard.GetState();
                chicken.speed.Y = 0;
                wolf.speed.Y = 0;
                wolf.speed.X = 0;
                celebration.Position = new Vector2(chicken.getBound().X - wolf.getBound().Width / 2,
                    chicken.getBound().Y - wolf.getBound().Height / 2);
                celebration.startAnimation();
                chickenCrosser.tryAgain.Visible = true;
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    ResetGame();
                    chickenCrosser.wolfSound.Play();
                    chickenCrosser.attempts++;
                }
   
            }

            base.Update(gameTime);
        }
        public void ResetGame()
        {

            chicken.position = new Vector2((Shared.stage.X - chicken.tex.Width) / 2,
            Shared.stage.Y - chicken.tex.Height);
            chicken.speed = new Vector2(0, 5);
            wolf.position = new Vector2((Shared.stage.X - wolf.tex.Width),
                Shared.stage.Y - wolf.tex.Height);

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

            wolf.speed = new Vector2(x, y);
            

        }
    }
}
