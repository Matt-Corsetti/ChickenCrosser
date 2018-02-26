using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace ChickenCrosser
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ChickenCrosser : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        // Declaring all the scenes
        private StartScene startScene;
        private ActionScene actionScene;
        private HelpScene helpScene;
        private AboutScene aboutScene;
        private HowToPlayScene howToPlayScene;
        SpriteFont font;
        SpriteFont tryFont;
        public String attemptString;
        public String tryAgain;
        public String winString;
        
        public int attempts = 1;

        public SoundEffect wolfSound;
        public SoundEffect chickenSound;


      
        public ChickenCrosser()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        private void hideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            // TODO: use this.Content to load your game content here

            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);

            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);

            howToPlayScene = new HowToPlayScene(this);
            this.Components.Add(howToPlayScene);

            font = this.Content.Load<SpriteFont>("Fonts/AttemptFont");
            Vector2 stringPos = new Vector2(750, 600);
            attemptString = new String(this, spriteBatch, font, stringPos, "Attempts: " + attempts
                , Color.LightBlue);

            this.Components.Add(attemptString);

            tryFont = this.Content.Load<SpriteFont>("Fonts/TryFont");
            Vector2 tryAgainPos = new Vector2(600, 600);
            tryAgain = new String(this, spriteBatch, tryFont, tryAgainPos, "Oh no! The Wolf got you! Press enter to try again."
                , Color.Black);

            this.Components.Add(tryAgain);

            tryFont = this.Content.Load<SpriteFont>("Fonts/TryFont");
            Vector2 winStringPos = new Vector2(600, 600);
            winString = new String(this, spriteBatch, tryFont, winStringPos, 
                "Congrats! You escaped the wolf in " + attempts + " " + "attempts!" +
                "Hit enter to play again, or escape to go back to the main menu."
                , Color.Black);

            this.Components.Add(winString);

            wolfSound = this.Content.Load<SoundEffect>("Music/WolfSound");

            chickenSound = this.Content.Load<SoundEffect>("Music/ChickenSound");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            string attemptMessage = "Attempt: " + attempts;
            attemptString.Message = attemptMessage;
            Vector2 dimension = font.MeasureString(attemptMessage);
            Vector2 strPos = new Vector2(750, 20);
            attemptString.Position = strPos;

            string tryAgainString = "Oh no! The Wolf got you! Hit enter to try again";
            tryAgain.Message = tryAgainString;
            Vector2 tryDimension = font.MeasureString(tryAgainString);
            Vector2 tryStrPos = new Vector2(300, 300);
            tryAgain.Position = tryStrPos;

            tryAgain.Visible = false;

            string winningString = "Congrats! You escaped the wolf in " 
                + attempts + " " + "attempts!" + "\n" + "Hit enter to play again, or escape to " + "\n" +
                "go back to the main menu.";
            winString.Message = winningString;
            Vector2 winDimension = font.MeasureString(winningString);
            Vector2 winStrPos = new Vector2(150, 150);
            winString.Position = winStrPos;

            winString.Visible = false;

            int selectedIndex = 0;

            KeyboardState keyboardState = Keyboard.GetState();

            if (startScene.Enabled)
            {
                attemptString.Visible = false;
                selectedIndex = startScene.Menu.SelectedIndex;
                if (selectedIndex == 0 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    actionScene.show();
                    attemptString.Visible = true;
                }
                else if (selectedIndex == 1 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    howToPlayScene.show();
                    attemptString.Visible = false;
                }
                else if (selectedIndex == 2 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                    attemptString.Visible = false;
                }
                else if (selectedIndex == 3 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScene.show();
                    attemptString.Visible = false;
                }
                else if (selectedIndex == 4 && keyboardState.IsKeyDown(Keys.Enter))
                {
                    Exit();
                }
            }

            if (actionScene.Enabled || helpScene.Enabled || aboutScene.Enabled || howToPlayScene.Enabled)
            {
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();
                }
            }
           

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
