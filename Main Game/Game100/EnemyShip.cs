using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game100
{
    class EnemyShip : Sprite
    {
        public Vector2 enemyPos = new Vector2(-200, -200);
        public Vector2 enemyDir;
        public float enemySpeed = 4.0f;
        protected Texture2D enemyTexture;
        public bool visible = true;
        public Rectangle enemyHitbox;

        public void setVisible(bool b)
        {
            this.visible = b;
        }

        public void LoadContent(ContentManager theContentManager)
        {
            enemyTexture = theContentManager.Load<Texture2D>("ship");
        }
        public void spawn(Vector2 startPosition, Vector2 direction)
        {
            enemyPos = startPosition;
            enemyDir = direction;

        }

        public void delete()
        {
            enemyPos = new Vector2(-100, -100);
        }

        public void Update(GameTime theGameTime)
        {
            enemyHitbox = new Rectangle((int)enemyPos.X, (int)enemyPos.Y, 21, 20);


            if (visible)
            {
                var bulletDelta = Vector2.Zero;
                enemyPos += enemySpeed * enemyDir;
            }
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            if (visible)
                theSpriteBatch.Draw(enemyTexture, enemyPos, Color.White);
        }
    }
}
