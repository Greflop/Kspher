using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projet_2._0;

namespace Kcaspher
{
    public class Shots
    {
        List<Bullet> ammunition;
        int count;
        MouseState mouseState, previousmouseState;


        public Shots()
        {            
            ammunition = new List<Bullet>();
            count = 0;
        }

        public void update(Vector2 origin)
        {
            if (previousmouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                ammunition.Add(new Bullet(origin, new Vector2(mouseState.X,mouseState.Y)));
                count++;
            }
            foreach (Bullet bullet in ammunition)
                bullet.update();
            for (int i = 0; i < count; i++)
            {
                if (ammunition[i].Position.X - ammunition[i].Origin.X < Res.gI().ScaleX(500) || ammunition[i].Position.Y - ammunition[i].Origin.Y < Res.gI().ScaleY(500))
                    ammunition.RemoveAt(i);
            }
            previousmouseState = mouseState;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (ammunition.Count != 0)
            {
                foreach (Bullet bullet in ammunition)
                        bullet.Draw(spritebatch);
            }
        }
    }
}
