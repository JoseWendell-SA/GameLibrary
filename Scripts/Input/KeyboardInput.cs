using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLIB.Scripts.Input
{
    public static class KeyboardInput
    {
        private static KeyboardState keyboardPrev;
        private static KeyboardState keyboardCur = Keyboard.GetState();

        public static void Update()
        {
            keyboardPrev = keyboardCur;
            keyboardCur = Keyboard.GetState();
        }

        public static bool GetKeyDown(Keys selKey)
        {
            return keyboardCur.IsKeyDown(selKey) && keyboardPrev.IsKeyUp(selKey);
        }

        public static bool GetKeyUp(Keys selKey)
        {
            return keyboardCur.IsKeyUp(selKey) && keyboardPrev.IsKeyDown(selKey) ;
        }

        public static bool GetKeyHold(Keys selKey)
        {
            return keyboardCur.IsKeyDown(selKey);
        }
    }
}
