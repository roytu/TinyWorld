using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Nuke : Object
    {
        private int t;
        public Nuke()
        {
            Game1.sndNuke.Play();
            Sprite = Game1.prSquare;
            xscale = Game1.VIEW_WIDTH;
            yscale = Game1.VIEW_HEIGHT;
            color = Color.White;
            color.A = 240;
            t = 0;
            depth = 0.01f;

            List<ObjEnergy> listEnergy = new List<ObjEnergy>();
            foreach (Object o in Game1.hObjCont.objectArray)
            {
                if (o is ObjEnergy)
                {
                    ObjEnergy energy = (ObjEnergy)o;
                    if (energy.owner != 0)
                    {
                        listEnergy.Add(energy);
                    }
                }
            }
            foreach (ObjEnergy e in listEnergy)
            {
                //blow up energy
                e.Break();
            }
            Game1.hObjCont.setShake(20);
        }
        public override void Update()
        {
            base.Update();
            t++;
            if (color.A > 0) { color.A--; }
            if (t <= 300)
            {
                Random rand = new Random();
                if (rand.Next((int)Math.Floor((double)t)) == 0)
                {
                    color.A = 240;
                    Game1.hObjCont.setShake(5);
                }
            }
            else
            {
                if (color.A <= 0)
                {
                    Remove();
                }
            }
        }
    }
}
