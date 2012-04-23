using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    class MenuSpace : Object
    {
        public MenuSpace()
        {
            Sprite = Game1.texSpace;
            xoff = width / 2;
            yoff = height / 2;
            x = 408;
            y = 434;
        }
    }
}
