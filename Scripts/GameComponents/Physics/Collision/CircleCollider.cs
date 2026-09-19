using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;
using System;

namespace GameLIB.Scripts.GameComponents.Physics.Collision
{
    public class CircleCollider : Collider
    {
        public float radius;
        public Vector2 position;

        public CircleCollider(Object newGameObject) : base(newGameObject)
        {
            CollisionSystem.Register(this);
        }

        public override bool CheckCollision(Collider newCol)
        {
            return newCol.CheckCollision(this);
        }

        public override bool CheckCollision(BoxCollider boxCol)
        {
            return false;
        }

        public override bool CheckCollision(CircleCollider cirCol)
        {
            float r = radius + cirCol.radius;

            r *= r;

            return r < MathF.Pow(position.X + cirCol.position.X, 2) + MathF.Pow(position.Y + cirCol.position.Y, 2);
        }
    }
}
