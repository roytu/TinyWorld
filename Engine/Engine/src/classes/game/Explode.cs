using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Explode : Object
    {
        private int t;
        public Explode()
        {
            Sprite = Game1.prSquare;
            xscale = Game1.VIEW_WIDTH;
            yscale = Game1.VIEW_HEIGHT;
            color = Color.White;
            color.A = 128;
            t = 0;
            depth = 0.01f;
        }
        public override void Update()
        {
            base.Update();
            t++;
            if (color.A > 0) { color.A--; }
            if (t >= 300)
            {
                Remove();
            }
        }
    }
}
