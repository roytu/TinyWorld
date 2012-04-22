using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class HudButtonResearching : Object
    {
        private int t;
        private bool isResearching;
        private int progress;
        public HudButtonResearching(float x, float y)
        {
            this.x = x;
            this.y = y;
            
            Sprite = Game1.texHudButtonResearching;
            frameCount = 8;
            xoff = Sprite.Width / frameCount / 2;
            yoff = Sprite.Height / 2;

            visible = false;
            isResearching = false;

            t = 0;
            progress = 0;

            depth = 0.415f;
        }
        public void BeginResearch()
        {
            if (!isResearching)
            {
                visible = true;
                isResearching = true;
                progress = 0;
                Game1.hRoomCont.gameHandler.player.SetState(1);
            }
        }
        public override void Update()
        {
            base.Update();
            if (isResearching)
            {
                t++;
                if (t % 5 == 0)
                {
                    Random rand = new Random();
                    angle = (float)(rand.Next(360) * Math.PI / 180);
                }
                progress++;
                frame = progress / 10;
                if (progress >= 10 * frameCount)
                {
                    isResearching = false;
                    visible = false;

                    Game1.hRoomCont.gameHandler.GiveItem();

                    Game1.hRoomCont.gameHandler.player.SetState(0);
                }
            }
        }
    }
}
