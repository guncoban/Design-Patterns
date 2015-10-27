﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;


namespace Game100
{

    public class Game1 : Game
    {
        private Texture2D asteroid;
        private Texture2D explosion;
        private Texture2D background;
        private SoundEffect backgroundMusic;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player1;
        Spawner spawner;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        Vector2 explosionPos;
        Vector2 position;
        List<Asteroid> Asteroids = new List<Asteroid>();
        List<PlayerBullet> Bullets = new List<PlayerBullet>();

        protected override void Initialize()
        {
            player1 = new Player();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player1.playerPos = new Vector2(200, 200);
            explosionPos = new Vector2(-100, -100);
            spawner = new Spawner(new Asteroid());

            position = new Vector2(graphics.GraphicsDevice.Viewport.
                       Width / 2,
                                    graphics.GraphicsDevice.Viewport.
                                    Height / 2);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            explosion = Content.Load<Texture2D>("Ultimate_Explosion");
            background = Content.Load<Texture2D>("background");
            asteroid = Content.Load<Texture2D>("asteroid.png");
            backgroundMusic = Content.Load<SoundEffect>("Episode");
            backgroundMusic.Play();
            
            base.Initialize();
        }


        protected override void LoadContent()
        {
            player1.LoadContent(this.Content);

        }




        protected override void Update(GameTime gameTime)
        {

            player1.Update(gameTime);
            player1.LoadContent(this.Content);
            spawner.Update(gameTime);
            spawner.LoadContent(this.Content);

            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            MouseState state = Mouse.GetState();

            position.X = state.X;
            position.Y = state.Y;
            foreach (Asteroid z in Spawner.Asteroids)
            {
                foreach (PlayerBullet b in Player.Bullets)
                {
                    if (b.lazerHitbox.Intersects(z.asteroidHitbox))
                    {
                        explosionPos = z.getAsteroidPos();
                        b.delete();
                        z.delete();
                    }
                }
               
            }

            base.Update(gameTime);
        }
       

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            player1.Draw(spriteBatch);
            spawner.Draw(spriteBatch);
            spriteBatch.Draw(explosion, explosionPos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}

    
