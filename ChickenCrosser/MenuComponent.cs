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
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont, highlightFont;
        private List<string> menuItems;

        public int SelectedIndex { get; set; }
        private Vector2 position;
        private Color regularColor = Color.Black;
        private Color highlightColor = Color.Red;

        private KeyboardState oldState;

        private SoundEffect menuSound;

        public MenuComponent(Game game,
                SpriteBatch spriteBatch,
                SpriteFont regularFont,
                SpriteFont highlightFont,
                string[] menus,
                SoundEffect menuSound) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.highlightFont = highlightFont;
            menuItems = menus.ToList();
            position = new Vector2(350, 140);
            this.menuSound = menuSound;
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                menuSound.Play();
                SelectedIndex++;
                if (SelectedIndex == menuItems.Count)
                {
                    SelectedIndex = 0;
                }
            }
            if (keyboardState.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                menuSound.Play();
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = menuItems.Count - 1;
                }
            }
            oldState = keyboardState;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (SelectedIndex == i)
                {
                    spriteBatch.DrawString(highlightFont, menuItems[i],
                        tempPos, highlightColor);
                    tempPos.Y += highlightFont.LineSpacing;
                }
                else
                {
                    spriteBatch.DrawString(regularFont, menuItems[i],
                        tempPos, regularColor);
                    tempPos.Y += regularFont.LineSpacing;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);    
        }
    }
}
