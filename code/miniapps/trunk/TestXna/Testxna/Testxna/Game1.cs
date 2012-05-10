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

namespace Testxna
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        readonly GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private Texture2D _texture;

        // Set the coordinates to draw the sprite at.
        Vector2[] _spritePositions;

        // Store some information about the sprite's motion.
        Vector2[] _spriteSpeeds;
        private int _maxX;
        private int _minX;
        private int _maxY;
        private int _minY;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
                {
                    PreferredBackBufferWidth = 1680 * 3,
                    PreferredBackBufferHeight = 1050 * 3
                };
            _graphics.ToggleFullScreen();
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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // Hier laden wir unsere Grafik und weisen sie unserem Texture2D-Objekt zu
            _texture = Content.Load<Texture2D>("MyCoolImage");


            _maxX = _graphics.GraphicsDevice.Viewport.Width - _texture.Width;
            _minX = 0;
            _maxY = _graphics.GraphicsDevice.Viewport.Height - _texture.Height;
            _minY = 0;


            var r = new Random();

            const int amount = 200;
            _spritePositions = new Vector2[amount];
            _spriteSpeeds = new Vector2[amount];
            for (var i = 0; i < amount; ++i)
            {
                _spritePositions[i] = (new Vector2(r.Next(_maxX), r.Next(_maxY)));
                var spd = 180.0f + r.Next(150); //((r.Next(1) * 2) - 1);
                _spriteSpeeds[i] = new Vector2(spd * ((r.Next(2) * 2) - 1), spd * ((r.Next(2) * 2) - 1));
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            for (int i = 0; i < _spritePositions.Length; i++)
            {
                var spritePosition = _spritePositions[i];
                _spritePositions[i] += _spriteSpeeds[i] * (float)gameTime.ElapsedGameTime.TotalSeconds;

                // Check for bounce.
                if (_spritePositions[i].X > _maxX)
                {
                    _spriteSpeeds[i].X *= -1;
                    _spritePositions[i].X = _maxX;
                }

                else if (_spritePositions[i].X < _minX)
                {
                    _spriteSpeeds[i].X *= -1;
                    _spritePositions[i].X = _minX;
                }

                if (_spritePositions[i].Y > _maxY)
                {
                    _spriteSpeeds[i].Y *= -1;
                    _spritePositions[i].Y = _maxY;
                }

                else if (_spritePositions[i].Y < _minY)
                {
                    _spriteSpeeds[i].Y *= -1;
                    _spritePositions[i].Y = _minY;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            _spriteBatch.Begin();

            foreach (var spritePosition in _spritePositions)
            {
                _spriteBatch.Draw(_texture, spritePosition, Color.White);
            }

            /*
            var widthAndHeigth = 80;
            const int width = 1500;
            const int height = 800;

            var positionX = (gameTime.TotalGameTime.TotalMilliseconds % (width * 2));
            if (positionX > width) positionX = width * 2 - positionX;

            var positionY = (gameTime.TotalGameTime.TotalMilliseconds % (height * 2));
            if (positionY > height) positionY = height * 2 - positionY;

            spriteBatch.Draw(texture, new Rectangle((int)positionX, (int) positionY, 80, 80), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)positionX / 2, (int)positionY + 50, 80, 80), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)positionX / 3, (int)positionY + 100, 80, 80), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)positionX / 4, (int)positionY + 150, 80, 80), Color.White);
            spriteBatch.Draw(texture, new Rectangle((int)positionX / 5, (int)positionY + 250, 80, 80), Color.White);*/
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
