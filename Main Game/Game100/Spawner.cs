using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Game100
{
    class Spawner<ObjectS>
    {
        int spawnTimer = 0;
        const int TIME_TO_WAIT = 90;
        public static List<ObjectS> ObjectList = new List<ObjectS>();
        Random random = new Random();
        public void LoadContent(ContentManager theContentManager)
        {
            foreach (ObjectS objectS in ObjectList)
            {
                if (objectS.visible)
                    objectS.LoadContent(theContentManager);
            }
        }
        public void spawn()
        {
                    Sprite newObject = new Sprite();
                    newObject.spawn(new Vector2(random.Next(20, 730), -28), Vector2.UnitY);
                    ObjectList.Add(newObject);

        }
        public void Update(GameTime theGameTime)
        {
            if (spawnTimer >= TIME_TO_WAIT)
            {
                spawn();
                spawnTimer = 0;
            }
            foreach (Sprite objectS in ObjectList)
            {
                objectS.Update(theGameTime);
            }
            spawnTimer++;
        }
        public void Draw(SpriteBatch theSpriteBatch)
        {
            foreach (Sprite objectS in ObjectList)
            {
                if (objectS.visible)
                    objectS.Draw(theSpriteBatch);
            }
        }
    }
}
