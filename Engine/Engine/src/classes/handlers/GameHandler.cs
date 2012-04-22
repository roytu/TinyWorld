using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class GameHandler : Object
    {
        public Player player;
        //public RenderTarget2D rtCircles;
        public int item;
        public Hud hud;

        public GameHandler()
        {
            new World();
            player = new Player(Game1.VIEW_WIDTH / 2, Game1.VIEW_HEIGHT / 2);
            hud = new Hud();

            //rtCircles = new RenderTarget2D(Game1.graphicsDevice, Game1.VIEW_WIDTH, Game1.VIEW_HEIGHT, true, Game1.graphicsDevice.DisplayMode.Format, DepthFormat.Depth24, 1, RenderTargetUsage.PreserveContents);
            item = 0;
        }
        public void GiveItem()
        {
            item = 1;
            hud.huditem.UpdateActions();
        }
        public void RemoveItem()
        {
            item = 0;
            hud.huditem.UpdateActions();
        }
        public override void Update()
        {
            Random rand = new Random();
            for (int i = 0; i < player.speed; i++)
            {
                if (rand.Next(60)==0)
                {
                    new DecalCircle(rand.Next(Game1.VIEW_WIDTH), rand.Next(Game1.VIEW_HEIGHT));
                }
            }
        }
        public override void Draw(SpriteBatch sb)
        {
            //Rectangle destRect=new Rectangle(0,0,rtCircles.Width,rtCircles.Height);
            //sb.Draw(rtCircles, destRect, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.95f);
            //Game1.graphicsDevice.SetRenderTarget(rtCircles);
            //Game1.graphicsDevice.Clear(new Color(0, 0, 0, 0));
            //sb.Draw(rtCircles, new Vector2(0, -1), null, Color.White);
            //Game1.graphicsDevice.SetRenderTarget(null);
        }
    }
}