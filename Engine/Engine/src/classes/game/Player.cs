using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Player : Object
    {
        public Player(int x, int y) : base(x,y)
        {
            Sprite = null;

            xoff = width / 2;
            yoff = height;
        }
        public override void Update()
        {
            #region Input
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
            }
            #endregion

        }
    }
}