using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class World : Object
    {
        private int t;
        public World()
        {
            Sprite = Game1.texWorld;
            xoff = Sprite.Width / 2;
            yoff = Sprite.Height / 2;
            angle = 0;

            x = Game1.VIEW_WIDTH / 2;
            y = Game1.VIEW_HEIGHT / 2;

            t = 0;
            depth = 0.3f;
        }
        public override void Update()
        {
            base.Update();
            t++;
            if (t % 5 == 0)
            {
                Random rand = new Random();
                angle = rand.Next(360);
            }
        }
    }
}
