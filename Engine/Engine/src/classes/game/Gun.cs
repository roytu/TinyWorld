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
        public Gun()
        {
            Sprite = Game1.texGun;
            frameCount = 4;
            xoff = 0;
            yoff = height / 2;
        }
    }
}
