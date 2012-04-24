using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Enemy : Object
    {
        public float speed;
        public float pos;
        public int state;
        public int delay;

        public bool isLost;

        private Gun gun;
        public void Win()
        {
            gun.isWon = true;
        }
        public void Lose()
        {
            if (!isLost)
            {
                isLost = true;
                gun.Remove();
            }
        }
        public Enemy(int x, int y) : base(x,y)
        {
            isLost = false;
            Sprite = Game1.texPlayer;
            frameCount = 4;
            frameSpeed = 0.2f;

            xoff = width / frameCount / 2;
            yoff = height;

            speed = 0.5f;
            pos = 180;
            state = 0;

            depth = 0.1f;

            gun = new Gun();

            color = new Color(255, 189, 189);
        }
        public override void Update()
        {
            base.Update();
            if (isLost)
            {
                if (color.A > 0) { color.A--; }
            }
            Random rand = new Random();
            if (rand.Next(300) == 0 && delay<=0)
            {
                new ObjEnergy((int)Game1.hRoomCont.gameHandler.enemy.pos, 1);
            }
            switch (state)
            {
                case 0:
                    if (!isLost && delay<=0) { pos += speed; }
                    if (delay > 0) { delay--; }

                    x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-ExtConstants.PI_TWO * pos / 360) * 100;
                    y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-ExtConstants.PI_TWO * pos / 360) * 100;
                    angle = (float)ExtConstants.PI_TWO * ((pos + 90) / 360);

                    float xoff = 36;
                    float yoff = -61 + (int)frame;
                    float d = (float)Math.Sqrt(xoff * xoff + yoff * yoff);
                    float dir = (float)(Math.Atan2(yoff, xoff) + Math.PI / 2);
                    gun.x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-ExtConstants.PI_TWO * pos / 360) * 100 + (float)Math.Cos(-dir - ExtConstants.PI_TWO * pos / 360) * d;
                    gun.y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-ExtConstants.PI_TWO * pos / 360) * 100 - (float)Math.Sin(-dir - ExtConstants.PI_TWO * pos / 360) * d;
                    gun.angle = (float)ExtConstants.PI_TWO * ((pos + 90) / 360);
                    break;
                case 1: //researching

                    break;
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            base.Draw(sb);
            int xf = 16;
            int yf = -115 + (int)frame;
            float angOff = (float)(Math.Atan2(yf,xf)+Math.PI/2);
            int dist = (int)Math.Sqrt(xf * xf + yf * yf);
            float _x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-angle+Math.PI/2) * 100 + (float)Math.Cos(angOff - angle + Math.PI/2) * dist;
            float _y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-angle+Math.PI/2) * 100 - (float)Math.Sin(angOff - angle + Math.PI/2) * dist;
            Texture2D faceSprite = null;
            switch (state)
            {
                case 0:
                    faceSprite = Game1.texFaceNeutral;
                    break;
                case 1:
                    faceSprite = Game1.texFaceThinking;
                    break;
            }
            if (isLost || delay>0) { faceSprite = Game1.texFaceThinking; }
            Vector2 pos = new Vector2(_x, _y);
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, (int)Math.Round((double)faceSprite.Width), (int)Math.Round((double)faceSprite.Height));
            sb.Draw(faceSprite, destRect, null, Color.White, angle, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, (float)(depth - 0.01));
        }
        public void SetState(int state)
        {
            this.state=state;
        }
    }
}