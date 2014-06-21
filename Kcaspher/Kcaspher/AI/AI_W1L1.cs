using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Projet_2._0.AI
{
    class AI_W1L1
    {
        public List<AI_basic> AI_w1l1 = new List<AI_basic>();
        public List<Rectangle> ListHitbox;

        public AI_W1L1()
        {
            AI_w1l1.Add(new AI_basic(Content_Manager.getInstance().Textures["enemy1"], Content_Manager.getInstance().Textures["enemy2"], new Rectangle(Res.gI().ScaleX(222), Res.gI().ScaleY(500), Res.gI().ScaleX(40), Res.gI().ScaleY(40)), new Vector2(3, 0), 300));
            AI_w1l1.Add(new AI_basic(Content_Manager.getInstance().Textures["enemy1"], Content_Manager.getInstance().Textures["enemy2"], new Rectangle(Res.gI().ScaleX(500), Res.gI().ScaleY(700), Res.gI().ScaleX(40), Res.gI().ScaleY(40)), new Vector2(3, 0), 300));
        }

        public void update(GameTime gametime)
        {
            foreach (AI_basic AI in AI_w1l1)
            {
                AI.update(gametime);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (AI_basic AI in AI_w1l1)
            {
                AI.Draw(spritebatch);
            }
        }
        public List<Rectangle> getListRectangle() 
        {
            ListHitbox = new List<Rectangle>();
            foreach (AI_basic AI in AI_w1l1)
	        {
                ListHitbox.Add(AI.Hitbox);
	        }
            return ListHitbox;
        }
    }
}
