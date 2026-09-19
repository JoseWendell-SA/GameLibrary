using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joguinho.Scripts
{
    public static class Time
    {
        private static float lastTime = 0;
        public static float deltaTime { get; private set; }

        internal static void UpdateGameTime(GameTime gameTime)
        {
            float curTime = (float)gameTime.TotalGameTime.TotalSeconds;
            deltaTime = curTime - lastTime;
            lastTime = curTime;
        }
    }
}
