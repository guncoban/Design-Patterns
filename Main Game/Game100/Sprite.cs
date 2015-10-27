using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;



namespace Game100
{
    class Sprite
    {
        public void LoadContent(ContentManager theContentManager)    {}
        public void Update(GameTime theGameTime) {}
        public void Draw(SpriteBatch theSpriteBatch) {}
        public bool visible;
        public void spawn(Vector2 startPosition, Vector2 direction) {}
    }
}
