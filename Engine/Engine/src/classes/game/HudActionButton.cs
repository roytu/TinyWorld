using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class HudActionButton : Object
    {
        private int t;
        private int type;
        private bool isStarting;

        private int outlineFrame;

        public HudActionButton(float x, float y, int type)
        {
            this.x = x;
            this.y = y;
            this.type = type;

            Sprite = Game1.texHudActions;
            frameCount = 4;
            xoff = Sprite.Width / frameCount / 2;
            yoff = Sprite.Height / 2;

            t = 0; //time tracking for frames
            isStarting = true;
            frameSpeed = 0.1f;

            outlineFrame = 0;

            depth = 0.42f;
        }
        public override void Update()
        {
            base.Update();
            if (isStarting)
            {
                if (frame >= frameCount-1)
                {
                    isStarting = false;
                    frameSpeed = 0;
                    frame = frameCount - 1;
                }
            }
            else
            {
                t++;
                if (t % 5 == 0)
                {
                    Random rand = new Random();
                    outlineFrame = rand.Next(4); //outline frameCount
                }
            }
        }
        public override void LeftClicked(int mouseX, int mouseY)
        {
            base.LeftClicked(mouseX, mouseY);
            int w = width / frameCount;
            if (x - w / 2 < mouseX && mouseX < x + w / 2 && y - height / 2 < mouseY && mouseY < y + height / 2)
            {
                switch(Game1.hRoomCont.gameHandler.item)
                {
                    case 1: //dead baby
                        switch (type)
                        {
                            case 0: //throw
                                Game1.sndMakeEnergy.Play();
                                new ObjBaby((int)(Game1.hRoomCont.gameHandler.player.pos % 360), 0, 0);
                                break;
                            case 1: //drop
                                Game1.sndDropBaby.Play();
                                new ObjBaby((int)(Game1.hRoomCont.gameHandler.player.pos % 360), 0, 1);
                                break;
                        }
                        break;
                    case 2: //detonator
                        switch (type)
                        {
                            case 2: //use
                                new Detonator();
                                break;
                            case 1: //drop
                                Game1.hRoomCont.gameHandler.RemoveItem();
                                break;
                        }
                        break;
                    case 3: //nuke
                        switch (type)
                        {
                            case 2: //use
                                new Nuke();
                                break;
                            case 1: //drop
                                Game1.hRoomCont.gameHandler.RemoveItem();
                                break;
                        }
                        break;
                }
                Game1.hRoomCont.gameHandler.RemoveItem();
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            base.Draw(sb);
            if (!isStarting)
            {
                Rectangle destRect = new Rectangle((int)x - xoff, (int)y - yoff, Game1.texHudActionsOutline.Width / 4, Game1.texHudActionsOutline.Height);
                Rectangle srcRect = new Rectangle((int)outlineFrame * Game1.texHudActionsOutline.Width / 4, 0, Game1.texHudActionsOutline.Width / 4, Game1.texHudActionsOutline.Height);
                sb.Draw(Game1.texHudActionsOutline, destRect, srcRect, Color.White);
                int fc = 3;
                destRect = new Rectangle((int)x - xoff, (int)y - yoff, Game1.texHudActionsText.Width / fc, Game1.texHudActionsText.Height);
                srcRect = new Rectangle(type * Game1.texHudActionsText.Width / fc, 0, Game1.texHudActionsText.Width / fc, Game1.texHudActionsText.Height);
                sb.Draw(Game1.texHudActionsText, destRect, srcRect, Color.White);
            }
        }
    }
}
