using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class HudButtonText : Object
    {
        private int type;
        public HudButtonText(int type)
        {
            this.type = type;

            Sprite = Game1.texHudButtonText;
            frameCount = 8;
            xoff = Sprite.Width / frameCount / 2;
            yoff = Sprite.Height / 2;

            depth = 0.41f;
        }
        public override void Update()
        {
            base.Update();
            frame = type;
        }
    }
}
