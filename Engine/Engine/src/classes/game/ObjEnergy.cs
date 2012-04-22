using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class ObjEnergy : Object
    {
        public int pos;
        public int h;
        private DecalLight light;
        public int owner;
        
        public ObjEnergy(int pos, int owner)
        {
            this.pos = pos % 360;
            this.owner = owner;
            Sprite = Game1.texObjEnergy;
            frameCount = 3;
            frameSpeed = 0.2f;
            xoff = Sprite.Width / frameCount / 2;
            yoff = Sprite.Height / 2;

            h = 0;

            light = new DecalLight(pos);
        }
        public override void Update()
        {
            base.Update();
            if (h < 100) { h++; }
            x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-ExtConstants.PI_TWO * pos / 360) * (150 + h);
            y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-ExtConstants.PI_TWO * pos / 360) * (150 + h);
            angle = (float)ExtConstants.PI_TWO * ((float)(pos + 90) / 360);

            Player ply = Game1.hRoomCont.gameHandler.player;
            if (owner == 0)
            {
                if ((ply.pos % 360) > pos && ((ply.pos - ply.speed) % 360 <= pos) && (ply.pos-ply.speed-pos>180))
                {
                    ply.speed += 0.02f;
                }
                if(Math.Abs((ply.pos%360)-(pos%360))<=8)
                {
                    light.frame=2;
                }
                else
                {
                    light.frame=0;
                }
            }
        }
    }
}
