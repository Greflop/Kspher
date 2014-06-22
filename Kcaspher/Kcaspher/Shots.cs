﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Projet_2._0;
using Projet_2._0.Menus;

namespace Kcaspher
{
    public class Shots
    {
        List<Bullet> ammunition;
        MouseState mouseState, previousmouseState;
        Camera camera;

        public Shots()
        {            
            ammunition = new List<Bullet>();
            camera = new Camera(Game1.GetGame().GraphicsDevice.Viewport);
            //Rectangle = new Rectangle (0,0, Res.gI().ScaleX(4200))
            //count = 0;
        }

        public void update(GameTime gametime, Vector2 origin, List<AI_moderate> AIlist)
        {
            /// camera position
            if (origin.X > Res.gI().ScaleX(840))
                camera.update(gametime, origin);
            if (origin.X > Res.gI().ScaleX(1680))
                camera.update(gametime, new Vector2(Res.gI().ScaleX(1680), 0));
            ///
            mouseState = Mouse.GetState();
            if (previousmouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                ammunition.Add(new Bullet(origin, new Vector2(mouseState.X +camera.centre.X  ,mouseState.Y)));
                SoundManager.gun.Play();
            }
            foreach (Bullet bullet in ammunition)
            {
                bullet.update();
                for (int i = 0; i < AIlist.Count; i++)
                {
                    if (AIlist[i].hitbox.Intersects(bullet.Hitbox))
                    {
                        AIlist.RemoveAt(i);
                    }
                }
            }
            if (ammunition.Count != 0)
            {

                for (int i = 0; i < ammunition.Count; i++)
                {
                    if (!(ammunition[i].Hitbox.Intersects(ammunition[i].isVisible)))
                        ammunition.RemoveAt(i);
                }
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
