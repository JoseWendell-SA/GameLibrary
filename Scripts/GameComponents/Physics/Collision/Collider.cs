using Joguinho.Scripts.GameComponents;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts.GameComponents.Physics.Collision
{
    public class Collider : ObjectComponent
    {
        public Vector2 localPosition;

        public Collider(Object newGameObject) : base(newGameObject)
        {
            
        }

        public virtual void OnCollision()
        {
            
        }
    }
}
