using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class ObjBaby : Object
    {
        private int pos;
        private int owner;
        private int action;

        private float angleInc;

        private int h;

        private const int SPEED = 2;
        
        public ObjBaby(int pos, int owner, int action)
        {
            this.pos = pos % 360;
            this.owner = owner;
            this.action = action;

            Sprite = Game1.texObjBaby;
            frameCount = 3;
            frameSpeed = 0.2f;
            xoff = Sprite.Width / frameCount / 2;
            yoff = Sprite.Height / 2;

            x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-pos * Math.PI / 180) * 120;
            y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-pos * Math.PI / 180) * 120;

            angle = (float)ExtConstants.PI_TWO * ((float)(pos + 90) / 360);
            angleInc = 0;
            h = 0;

            Random rand = new Random();

            switch (action)
            {
                case 0: //thrown
                    angleInc = (float)(rand.Next(3) + 3) / 10;
                    break;
                case 1: //dropped

                    break;
            }
        }
        public override void Update()
        {
            base.Update();
            h += SPEED;
            angle += angleInc;
            switch (action)
            {
                case 0: //thrown
                    x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-pos * Math.PI / 180) * h;
                    y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-pos * Math.PI / 180) * h;

                    List<ObjEnergy> listEnergy = new List<ObjEnergy>();
                    foreach(Object o in Game1.hObjCont.objectArray)
                    {
                        if (o is ObjEnergy)
                        {
                            ObjEnergy energy = (ObjEnergy)o;
                            if (energy.owner != owner && h > energy.h && Math.Abs(pos - energy.pos) % 360 < 8)
                            {
                                listEnergy.Add(energy);
                            }
                        }
                    }
                    foreach (ObjEnergy e in listEnergy)
                    {
                        //blow up energy
                        e.Remove();
                    }
                    if (listEnergy.Count > 0)
                    {
                        Remove();
                    }
                    break;
                case 1: //dropped
                    break;
            }
        }
    }
}
