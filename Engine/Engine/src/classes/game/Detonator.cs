using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Detonator : Object
    {
        private int t;
        public Detonator()
        {
            Sprite = Game1.texDetonatorCircle;
            xoff = width / 2;
            yoff = height / 2;
            depth = 0.02f;
            t = 0;
        }
        public override void Update()
        {
            base.Update();
            MouseState m = Mouse.GetState();
            x = m.X;
            y = m.Y;
            t++;
            color.A = (byte)(Math.Cos(ExtConstants.PI_TWO * t / 60) * 0xFF);
            if (t > 300)
            {
                Remove();
            }
        }
        public override void LeftClicked(int mouseX, int mouseY)
        {
            base.LeftClicked(mouseX, mouseY);
            if (t > 1)
            {
                List<ObjEnergy> listEnergy = new List<ObjEnergy>();
                foreach (Object o in Game1.hObjCont.objectArray)
                {
                    if (!(o is ObjEnergy)) { continue; }
                    else
                    {
                        ObjEnergy energy = (ObjEnergy)o;
                        float dx = energy.x - x;
                        float dy = energy.y - y;
                        if (Math.Sqrt(dx * dx + dy * dy) <= 50)
                        {
                            listEnergy.Add(energy);
                        }
                    }
                }
                foreach (ObjEnergy e in listEnergy)
                {
                    e.Break();
                }
                Remove();
                Game1.sndMakeEnergy.Play();
            }
        }
    }
}
