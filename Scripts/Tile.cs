using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts
{
    public class Tile : Object
    {
        public bool wasFilled = false;

        public Tile(Vector2 newPosition) : base(newPosition)
        {
            
        }
    }
}
