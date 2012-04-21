using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Hud : Object
    {
        public Hud()
        {
            Sprite = null;
            HudButton b = new HudButton(715, 75, 0);
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
