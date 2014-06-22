using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Projet_2._0;

namespace Kcaspher
{
    public class Bullet
    {
        public Vector2 Direction, Position, Velocity, Origin;
        public Rectangle Hitbox;

        public Bullet(Vector2 Origin, Vector2 Direction)
        {
            this.Origin = Origin;
            this.Position = Origin;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, 15, 15);
            Velocity = new Vector2(6f, 6f);
            this.Direction = Direction - Origin;
            this.Direction.Normalize();
        }

        public void update()
        {
            Position += Velocity * Direction;
            Hitbox.X = (int)Position.X;
            Hitbox.Y = (int)Position.Y;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Content_Manager.getInstance().Textures["enemy1"], Hitbox, Color.White);
        }
    }
}
