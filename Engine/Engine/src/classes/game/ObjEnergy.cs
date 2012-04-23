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
        public float h;
        private DecalLight light;
        public int owner;
        private bool isAlive;
        private float vsp;
        
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
            vsp = 0;

            light = new DecalLight(pos);
            if (owner == 1) { light.frame = 1; }

            isAlive = true;
            depth = 0.13f;
        }
        public override void Update()
        {
            base.Update();
            if (h < 100) { h++; }
            x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-ExtConstants.PI_TWO * pos / 360) * (150 + h);
            y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-ExtConstants.PI_TWO * pos / 360) * (150 + h);
            angle = (float)ExtConstants.PI_TWO * ((float)(pos + 90) / 360);

            if (isAlive)
            {
                Player ply = Game1.hRoomCont.gameHandler.player;
                Enemy ene = Game1.hRoomCont.gameHandler.enemy;
                if (owner == 0)
                {
                    if ((ply.pos % 360) > pos && ((ply.pos - ply.speed) % 360 <= pos) && (ply.pos - ply.speed - pos > 180))
                    {
                        ply.speed += 0.025f;
                        Game1.sndEnergy.Play();
                    }
                    if (Math.Abs((ply.pos % 360) - (pos % 360)) <= 8)
                    {
                        light.frame = 2;
                    }
                    else
                    {
                        light.frame = 0;
                    }
                }
                else if (owner == 1)
                {
                    if ((ene.pos % 360) > pos && ((ene.pos - ene.speed) % 360 <= pos) && (ene.pos - ene.speed - pos > 180))
                    {
                        ene.speed += 0.05f;
                        Game1.sndEnergy.Play();
                    }
                    if (Math.Abs((ene.pos % 360) - (pos % 360)) <= 8)
                    {
                        light.frame = 3;
                    }
                    else
                    {
                        light.frame = 1;
                    }
                }
            }
            else
            {
                vsp -= 0.1f;
                h += vsp;
                if (h <= 0)
                {
                    HitTargets();
                    Explode();
                    Remove();
                }
            }
        }
        public void Break()
        {
            isAlive = false;
            light.Remove();
        }
        public void Explode()
        {
            Game1.sndExplode.Play();
            new Explode();
            Game1.hObjCont.setShake(5);
        }
        private void HitTargets()
        {
            float p = (Game1.hRoomCont.gameHandler.enemy.pos % 360);
            float e = pos % 360;
            while (Math.Abs(p - e) > 180) { p -= Math.Sign(p - e) * 360; }
            if (Math.Abs(p - e) <= 30)
            {
                Game1.hRoomCont.gameHandler.enemy.speed *= 7 / 8;
                Game1.hRoomCont.gameHandler.enemy.delay += 120;
            }
        }
    }
}
