using GameLIB.Scripts.Objects;
using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;
using System;

namespace GameLIB.Scripts.GameComponents.Physics.Collision
{
    public class CircleCollider : Collider
    {
        public float radius;
        public Vector2 position;

        private float r;

        public CircleCollider(GameObject newGameObject) : base(newGameObject)
        {
            CollisionSystem.Register(this);
        }

        public override void Update()
        {
            
        }

        public override bool CheckCollision(Collider newCol)
        {
            return newCol.CheckCollision(this);
        }

        public override bool CheckCollision(BoxCollider boxCol)
        {
            float circleDistX = MathF.Abs(gameObject.transform.position.X - boxCol.gameObject.transform.position.X);
            float circleDistY = MathF.Abs(gameObject.transform.position.Y - boxCol.gameObject.transform.position.Y);

            if (circleDistX > (boxCol.size.X / 2 + radius))
                return false;
            if (circleDistY > (boxCol.size.Y / 2 + radius))
                return false;

            if (circleDistX <= boxCol.size.X / 2)
                return true;
            if (circleDistY <= boxCol.size.Y / 2)
                return true;

            float cornerDist = MathF.Pow((circleDistX - boxCol.size.X / 2), 2) + MathF.Pow((circleDistY - boxCol.size.Y / 2), 2);

            return cornerDist <= radius * radius;
        }

        public override bool CheckCollision(CircleCollider cirCol)
        {
            float sum = MathF.Pow(gameObject.transform.position.X - cirCol.gameObject.transform.position.X, 2) + MathF.Pow(gameObject.transform.position.Y - cirCol.gameObject.transform.position.Y, 2);

            return MathF.Pow(radius + cirCol.radius, 2) >= sum;
        }
    }
}
