using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class DecalCircle : Object
    {
        private float t;
        private float vsp;
        public DecalCircle(float x, float y)
        {
            this.x = x;
            this.y = y;
            Sprite = Game1.texDecalCircle;
            frameCount = 4;
            xoff = Sprite.Width / frameCount / 2;
            yoff = Sprite.Height / 2;

            depth = 0.9f;

            t = 0;
            vsp = 0;

            color = new Color(255, 255, 255, 32);
        }
        public override void Update()
        {
            base.Update();
            vsp -= 0.01f;
            y += vsp;
            t += 0.5f;
            float s = (float)(((Math.Sin(Math.PI * t / 30) + 1) / 2) * Math.Sin(Math.PI * t / 300)) * 3;
            xscale = s;
            yscale = s;
            angle += (float)Math.Sin(t);
            if (t >= 300)
            {
                Remove();
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            //Game1.graphicsDevice.SetRenderTarget(Game1.hRoomCont.gameHandler.rtCircles);
            base.Draw(sb);
            //Game1.graphicsDevice.SetRenderTarget(null);
        }
    }
}
