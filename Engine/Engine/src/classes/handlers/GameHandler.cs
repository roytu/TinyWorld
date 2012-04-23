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
        public Enemy enemy;
        //public RenderTarget2D rtCircles;
        public int item;
        public Hud hud;
        public bool lost;
        public int lostI;

        public void EndGame()
        {
            List<Object> oList = new List<Object>();
            foreach (Object o in Game1.hObjCont.objectArray)
            {
                if (!(o is World))
                {
                    oList.Add(o);
                }
            }
            foreach (Object oe in oList)
            {
                oe.Remove();
            }
            new Menu();
            Remove();
        }
        public GameHandler()
        {
            player = new Player(Game1.VIEW_WIDTH / 2, Game1.VIEW_HEIGHT / 2);
            enemy = new Enemy(Game1.VIEW_WIDTH / 2, Game1.VIEW_HEIGHT / 2);
            hud = new Hud();

            //rtCircles = new RenderTarget2D(Game1.graphicsDevice, Game1.VIEW_WIDTH, Game1.VIEW_HEIGHT, true, Game1.graphicsDevice.DisplayMode.Format, DepthFormat.Depth24, 1, RenderTargetUsage.PreserveContents);
            item = 0;
            lost = false;
            lostI = 300;
        }
        public void GiveItem()
        {
            Random rand = new Random();
            int r = rand.Next(10);
            if (r < 5) //dead baby
            {
                item = 1;
            }
            else if (r < 8) //detonator
            {
                item = 2;
            }
            else //nuke
            {
                item = 3;
            }
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
            if(!player.isLost && !enemy.isLost)
            {
                float p = (player.pos % 360);
                float e = (enemy.pos % 360);
                while (Math.Abs(p - e) > 180) { p -= Math.Sign(p - e) * 360; }
                if (Math.Abs(p - e) < 40)
                {
                    if (p < e)
                    {
                        player.Win();
                        enemy.Lose();
                    }
                    else
                    {
                        enemy.Win();
                        player.Lose();
                    }
                    lost = true;
                    Game1.sndShoot.Play();
                }
            }
            if (lost)
            {
                lostI--;
                if (lostI <= 0)
                {
                    EndGame();
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