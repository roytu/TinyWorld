using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class Player : Object
    {
        private float speed;
        public float pos;

        public Player(int x, int y) : base(x,y)
        {
            Sprite = Game1.texPlayer;
            frameCount = 4;
            frameSpeed = 0.2f;

            xoff = width / frameCount / 2;
            yoff = height;

            speed = 1;
            pos = 0;
        }
        public override void Update()
        {
            base.Update();
            #region Input
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
            {
            }
            #endregion

            pos += speed;

            x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-ExtConstants.PI_TWO * pos / 360) * 100;
            y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-ExtConstants.PI_TWO * pos / 360) * 100;
            angle = (float)ExtConstants.PI_TWO * ((pos + 90) / 360);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
        {
            base.Draw(sb);
            /*
            float dist = (float)Math.Sqrt(Math.Pow(15.5, 2) + Math.Pow(100 + height - 14, 2));
            float rotoff = (float)(Math.Atan2(-(height - 14) - 100, 21 - width / 2)*180/Math.PI);
            float _x = Game1.VIEW_WIDTH / 2 + (float)Math.Cos(-angle+90+rotoff) * dist;
            float _y = Game1.VIEW_HEIGHT / 2 - (float)Math.Sin(-angle+90+rotoff) * dist;
            Vector2 pos = new Vector2(_x, _y);
            Rectangle destRect = new Rectangle((int)pos.X, (int)pos.Y, (int)Math.Round((double)Game1.texFaceNeutral.Width), (int)Math.Round((double)Game1.texFaceNeutral.Height));
            sb.Draw(Game1.texFaceNeutral, destRect, null, Color.White, angle, Vector2.Zero, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0);
            */
        }
    }
}