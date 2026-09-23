using System;
using System.Collections.Generic;
using GameLIB.Scripts.Objects;
using Microsoft.Xna.Framework;

namespace GameLIB.Scripts
{
    public class Tile : GameObject
    {
        public bool wasFilled = false;

        public Tile(Vector2 newPosition) : base(newPosition)
        {
            
        }
    }
}
