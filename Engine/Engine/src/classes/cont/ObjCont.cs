using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class ObjCont
    {
        public List<Object> objectArray;
        public float shake;
        public void setShake(int n)
        {
            shake += n;
        }
        public int getShake()
        {
            Random rand = new Random();
            int result = (int)(rand.Next((int)Math.Round(shake * 2)) - Math.Round(shake));
            return result;
        }
        public ObjCont()
        {
            objectArray = new List<Object>();
            shake = 0;
        }
        public void Init()
        {
        }
        public void Update()
        {
            for (int i = 0; i < objectArray.Count; i++)
            {
                Object o = objectArray[i];
                o.Update();
            }
            if (shake > 0) { shake -= 0.1f; }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);
            for(int i=0;i<objectArray.Count;i++)
            {
                objectArray[i].Draw(sb);
            }
            sb.End();
        }
    }
}