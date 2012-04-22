using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class HudButton : Object
    {
        private int t;
        private int type;

        private HudButtonText text;
        private HudButtonResearching researching;
        public HudButton(float x, float y, int type)
        {
            this.x = x;
            this.y = y;
            this.type = type;

            Sprite = Game1.texHudButton;
            xoff = Sprite.Width / 2;
            yoff = Sprite.Height / 2;

            t = 0; //time tracking for angles

            text = new HudButtonText(type);
            text.x = x;
            text.y = y;

            researching = new HudButtonResearching(x, y);

            depth = 0.42f;
        }
        public override void Update()
        {
            base.Update();
            t++;
            if (t % 5 == 0)
            {
                Random rand = new Random();
                angle = (float)(rand.Next(360) * Math.PI / 180);
            }
        }
        public override void LeftClicked(int mouseX, int mouseY)
        {
            base.LeftClicked(mouseX, mouseY);
            if (Math.Sqrt(Math.Pow(mouseX - x, 2) + Math.Pow(mouseY - y, 2)) < 50)
            {
                switch (type)
                {
                    case 0: //Energy
                        new ObjEnergy((int)Game1.hRoomCont.gameHandler.player.pos, 0);
                        break;
                    case 1: //Research
                        researching.BeginResearch();
                        break;
                }
            }
        }
    }
}
