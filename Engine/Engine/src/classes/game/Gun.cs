using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Gun : Object
    {
        public bool isWon;
        public Gun()
        {
            Sprite = Game1.texGun;
            frameCount = 4;
            xoff = 0;
            yoff = height / 2;
            isWon = false;
        }
        public override void Update()
        {
            base.Update();
            if (isWon)
            {
                Random rand = new Random();
                frame = rand.Next(3) + 1;
                angle = (float)(rand.Next(20) * Math.PI / 180);
            }
            else
            {
                frame = 0;
            }
        }
    }
}
