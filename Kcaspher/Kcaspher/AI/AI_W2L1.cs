using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projet_2._0;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kcaspher.AI
{
    class AI_W2L1
    {

        public List<AI_moderate> AI_w2l1 = new List<AI_moderate>();
        public List<Rectangle> ListHitbox;

        public AI_W2L1()
        {
            AI_w2l1.Add(new AI_moderate(Content_Manager.getInstance().Textures["enemy1"], new Rectangle(100, 180, 40, 40)));
            AI_w2l1.Add(new AI_moderate(Content_Manager.getInstance().Textures["enemy1"], new Rectangle(300, 180, 40, 40)));
            AI_w2l1.Add(new AI_moderate(Content_Manager.getInstance().Textures["enemy1"], new Rectangle(1300, 900, 40, 40)));
            AI_w2l1.Add(new AI_moderate(Content_Manager.getInstance().Textures["enemy1"], new Rectangle(1470, 900, 40, 40)));
            AI_w2l1.Add(new AI_moderate(Content_Manager.getInstance().Textures["enemy1"], new Rectangle(2270, 217, 40, 40)));
            AI_w2l1.Add(new AI_moderate(Content_Manager.getInstance().Textures["enemy1"], new Rectangle(2270, 436, 40, 40)));
        }

        public void update(GameTime gametime, Casper casper)
        {
            foreach (AI_moderate AI in AI_w2l1)
            {
                AI.update(gametime,casper);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (AI_moderate AI in AI_w2l1)
            {
                AI.Draw(spritebatch);
            }
        }
        public List<Rectangle> getListRectangle() 
        {
            ListHitbox = new List<Rectangle>();
            foreach (AI_moderate AI in AI_w2l1)
	        {
                ListHitbox.Add(AI.hitbox);
	        }
            return ListHitbox;
        }


    }
}
