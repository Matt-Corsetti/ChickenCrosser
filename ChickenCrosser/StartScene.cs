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
    public class StartScene : GameScene
    {
        public MenuComponent Menu { get; set; }


        private Texture2D startTex;
        private SpriteBatch spriteBatch;
        string[] menuItems = {"Start Game","How to Play", "Help", "About", "Quit"};
        private SoundEffect menuSound;
        public Song startSong;

        public StartScene(Game game) : base(game)
        {
            ChickenCrosser chickenCrosser = (ChickenCrosser)game;

            this.spriteBatch = chickenCrosser.spriteBatch;
            SpriteFont regularFont = chickenCrosser.Content.Load<SpriteFont>("Fonts/regularFont");
            SpriteFont highlightFont = chickenCrosser.Content.Load<SpriteFont>("Fonts/highlightFont");
            startTex = chickenCrosser.Content.Load<Texture2D>("Images/Start");
            menuSound = chickenCrosser.Content.Load<SoundEffect>("Music/MenuSelect");

            startSong = chickenCrosser.Content.Load<Song>("Music/StartSong");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(startSong);

            Menu = new MenuComponent(chickenCrosser, spriteBatch, regularFont, highlightFont, menuItems, menuSound);
            this.Components.Add(Menu);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);  
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(startTex, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);    
        }
    }
}
