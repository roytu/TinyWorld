using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class GameHandler : Object
    {
        public GameHandler()
        {
            new World();
            new Player(Game1.VIEW_WIDTH / 2, Game1.VIEW_HEIGHT / 2);
        }
        public override void Update()
        {
        }
    }
}