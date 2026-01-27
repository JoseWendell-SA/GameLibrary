using System;
using System.Collections.Generic;

namespace Joguinho.Scripts
{
    public class GameManager
    {
        public static GameManager GMInstance;

        public World world;

        public GameManager(World newWorld)
        {
            GMInstance = this;
            world = newWorld;
        }
    }
}
