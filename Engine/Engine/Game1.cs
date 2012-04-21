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

namespace Engine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Color bkgColor;

        public const int VIEW_WIDTH = 800;
        public const int VIEW_HEIGHT = 600;

        private static RoomCont roomCont;
        public static RoomCont hRoomCont
        {
            get
            {
                return roomCont;
            }
            set
            {
                roomCont = value;
            }
        }
        private static ObjCont objCont;
        public static ObjCont hObjCont
        {
            get
            {
                return objCont;
            }
            set
            {
                objCont = value;
            }
        }

        public static GraphicsDevice graphicsDevice;
        public static MouseState prevMouseState;
        public static MouseState currentMouseState;
        public static Texture2D prSquare;

        public static Texture2D texWorld;
        public static Texture2D texPlayer;
        public static Texture2D texFaceNeutral;
        public static Texture2D texHudButton;
        public static Texture2D texHudButtonText;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = VIEW_WIDTH;
            graphics.PreferredBackBufferHeight = VIEW_HEIGHT;
            Content.RootDirectory = "Content";

            IsFixedTimeStep = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            bkgColor = new Color(153, 125, 182);
            IsMouseVisible = true;
            // TODO: Add your initialization logic here
            base.Initialize();

            graphicsDevice = GraphicsDevice;

            roomCont = new RoomCont();
            objCont = new ObjCont();

            roomCont.Init();
            objCont.Init();

            prevMouseState = Mouse.GetState();
            currentMouseState = Mouse.GetState();
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
            prSquare = new Texture2D(GraphicsDevice, 1, 1);
            prSquare.SetData<Color>(new Color[1] { Color.White });

            texWorld = Content.Load<Texture2D>("texWorld");
            texPlayer = Content.Load<Texture2D>("texPlayer");
            texFaceNeutral = Content.Load<Texture2D>("texFaceNeutral");
            texHudButton = Content.Load<Texture2D>("texHudButton");
            texHudButtonText = Content.Load<Texture2D>("texHudButtonText");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            prSquare.Dispose();
            prSquare = null;

            texWorld.Dispose();
            texWorld = null;

            texPlayer.Dispose();
            texPlayer = null;

            texFaceNeutral.Dispose();
            texFaceNeutral = null;

            texHudButton.Dispose();
            texHudButton = null;

            texHudButtonText.Dispose();
            texHudButtonText = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            currentMouseState = Mouse.GetState();

            roomCont.Update();
            objCont.Update();

            prevMouseState = Mouse.GetState();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bkgColor);

            // TODO: Add your drawing code here
            objCont.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}