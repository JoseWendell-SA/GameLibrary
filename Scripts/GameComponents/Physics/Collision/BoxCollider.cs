using GameLIB.Scripts.GameComponents.Physics.Interface;
using GameLIB.Scripts.Objects;
using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;
using System;

namespace GameLIB.Scripts.GameComponents.Physics.Collision
{
    public class BoxCollider : Collider
    {
        public Vector2 min;
        public Vector2 max;

        public Vector2 size;

        public BoxCollider(GameObject newGameObject) : base(newGameObject)
        {
            CollisionSystem.Register(this);
        }

        public override void Update()
        {
            if (gameObject != null)
            {
                UpdateBox();
            }
        }

        public void SetNewBoxSize(Vector2 newSize)
        {
            size = newSize;

            if (gameObject != null)
            {
                UpdateBox();
            }

            else
            {
                min = new Vector2(localPosition.X - (size.X / 2), localPosition.Y - (size.Y / 2));
                max = new Vector2(localPosition.X + (size.X / 2), localPosition.Y + (size.Y / 2));
            }
        }

        private void UpdateBox()
        {
            min = new Vector2(gameObject.transform.position.X - (size.X / 2) + localPosition.X, gameObject.transform.position.Y - (size.Y / 2) + localPosition.Y);
            max = new Vector2(gameObject.transform.position.X + (size.X / 2) + localPosition.X, gameObject.transform.position.Y + (size.Y / 2) + localPosition.Y);
        }

        public override bool CheckCollision(Collider newCol)
        {
            return newCol.CheckCollision(this);
        }

        public override bool CheckCollision(BoxCollider boxCol)
        {
            if (this.max.X < boxCol.min.X || this.min.X > boxCol.max.X)
                return false;
            else if (this.max.Y < boxCol.min.Y || this.min.Y > boxCol.max.Y)
                return false;

            return true;
        }

        public override bool CheckCollision(CircleCollider cirCol)
        {
            float circleDistX = MathF.Abs(cirCol.gameObject.transform.position.X - gameObject.transform.position.X);
            float circleDistY = MathF.Abs(cirCol.gameObject.transform.position.Y - gameObject.transform.position.Y);

            if (circleDistX > (size.X / 2 + cirCol.radius))
                return false;
            if (circleDistY > (size.Y / 2 + cirCol.radius))
                return false;

            if (circleDistX <= size.X / 2)
                return true;
            if (circleDistY <= size.Y / 2)
                return true;

            float cornerDist = MathF.Pow((circleDistX - size.X / 2), 2) + MathF.Pow((circleDistY - size.Y / 2), 2);

            return cornerDist <= cirCol.radius * cirCol.radius;
        }
    }
}
