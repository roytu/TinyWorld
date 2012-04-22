using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class DecalLight : Object
    {
        private int pos;
        private int h;
        
        public DecalLight(int pos)
        {
            this.pos = pos % 360;
            Sprite = Game1.texDecalLight;
            frameCount = 4;
            xoff = Sprite.Width / frameCount / 2;
            yoff = -30;

            h = 0;

            depth = 0.5f;
        }
        public override void Update()
        {
            base.Update();
            if (h < 100) { h++; }
            x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-ExtConstants.PI_TWO * pos / 360) * (150 + h);
            y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-ExtConstants.PI_TWO * pos / 360) * (150 + h);
            angle = (float)ExtConstants.PI_TWO * ((float)(pos + 90) / 360);
        }
    }
}
