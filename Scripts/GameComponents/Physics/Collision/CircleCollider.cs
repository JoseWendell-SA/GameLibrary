using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;

namespace GameLIB.Scripts.GameComponents.Physics.Collision
{
    public class CircleCollider : Collider
    {
        public CircleCollider(Object newGameObject) : base(newGameObject)
        {
            CollisionSystem.Register(this);
        }

        public float radius;
        public Vector2 position;
    }
}
