﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Hud : Object
    {
        public HudItem huditem;
        public Hud()
        {
            Sprite = null;
            new HudButton(715, 75, 0);
            new HudButton(715, 200, 1);
            huditem = new HudItem();
        }
    }
}
