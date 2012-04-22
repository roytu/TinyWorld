using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Player : Object
    {
        public float speed;
        public float pos;
        public int state;

        private Gun gun;

        public Player(int x, int y) : base(x,y)
        {
            Sprite = Game1.texPlayer;
            frameCount = 4;
            frameSpeed = 0.2f;

            xoff = width / frameCount / 2;
            yoff = height;

            speed = 0.5f;
            pos = 0;
            state = 0;

            depth = 0.1f;

            gun = new Gun();

            color = new Color(192, 255, 189);
        }
        public override void Update()
        {
            base.Update();
            switch (state)
            {
                case 0:
                    pos += speed;

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