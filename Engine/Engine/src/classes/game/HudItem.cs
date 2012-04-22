using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class HudItem : Object
    {
        public List<HudActionButton> actionButtons;
        public HudItem()
        {
            Sprite = Game1.texHudItem;
            frameCount = 4;
            xoff = width / frameCount / 2;
            yoff = height / 2;

            actionButtons = new List<HudActionButton>();

            depth = 0.29f;
        }
        public void UpdateActions()
        {
            foreach (HudActionButton b in actionButtons)
            {
                b.Remove();
            }
            switch (Game1.hRoomCont.gameHandler.item)
            {
                case 0: //none
                    
                    break;
                case 1: //dead baby
                    HudActionButton b;
                    b = new HudActionButton(225, 530, 0);
                    actionButtons.Add(b);
                    b = new HudActionButton(575, 530, 1);
                    actionButtons.Add(b);
                    break;
            }
        }
        public override void Update()
        {
            base.Update();
            Random rand = new Random();
            x = Game1.VIEW_WIDTH / 2 + rand.Next(4) - 2;
            y = Game1.VIEW_HEIGHT / 2 + rand.Next(4) - 2;

            switch (Game1.hRoomCont.gameHandler.item)
            {
                case 0:
                    visible = false;
                    break;
                case 1:
                    visible = true;
                    frame = 0;
                    break;
                case 2:
                    visible = true;
                    frame = 1;
                    break;
                case 3:
                    visible = true;
                    frame = 2;
                    break;
            }
        }
    }
}
