using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projet_2._0
{
    class AI_moderate : Movable
    {
        public Texture2D texture;
        public Rectangle hitbox;
        public Rectangle aggro;
        bool casperIsIntersecting = false;


        public AI_moderate(Texture2D texture, Rectangle hitbox)
            : base(texture, hitbox)
        {
            this.texture = texture;
            this.hitbox = hitbox;
            aggro = new Rectangle(hitbox.X - Res.gI().ScaleX(350) / 2, hitbox.Y - Res.gI().ScaleY(350)/2, Res.gI().ScaleX(500), Res.gI().ScaleY(500));
            Direction = new Vector2(0, 0);
            Velocity = new Vector2(2.5f,2.5f);
            Position = new Vector2(0, 0);
        }

        public void update(GameTime gametime, Casper casper)
        {
            if (aggro.Intersects(casper.Hitbox))
            {
                if (!casperIsIntersecting)
                {
                    SoundManager.alert.Play();
                    casperIsIntersecting = true;
                }
                if (!hitbox.Intersects(casper.Hitbox))
                {
                    Direction = new Vector2(casper.Position.X - hitbox.X, casper.Position.Y - hitbox.Y);
                    Direction.Normalize();
                    Position.X = hitbox.X;
                    Position.Y = hitbox.Y;
                    Position += Direction * Velocity;
                    hitbox.X = (int)Position.X;
                    hitbox.Y = (int)Position.Y;

                }
            }
            aggro.X = hitbox.X - Res.gI().ScaleX(500) / 2;
            aggro.Y = hitbox.Y - Res.gI().ScaleY(500) / 2;
            if (!aggro.Intersects(casper.Hitbox))
            {
                casperIsIntersecting = false;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            //spritebatch.Draw(texture, aggro, Color.Black);
            spritebatch.Draw(texture, hitbox, Color.White);
            
        }
    }
}
