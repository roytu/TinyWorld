using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    class Menu : Object
    {
        private MenuSpace ms;
        public void StartGame()
        {
            Game1.hRoomCont.gameHandler = new GameHandler();
            ms.Remove();
            Remove();
            Game1.sndStart.Play();
        }
        public Menu()
        {
            Sprite = Game1.texTitle;
            xoff = width / 2;
            yoff = height / 2;
            x = 400;
            y = 40;
            ms = new MenuSpace();
        }
        public override void Update()
        {
            base.Update();
            KeyboardState k = Keyboard.GetState();
            if (k.IsKeyDown(Keys.Space))
            {
                StartGame();
            }
        }
    }
}
