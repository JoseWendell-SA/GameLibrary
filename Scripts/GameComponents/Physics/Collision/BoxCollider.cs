using Microsoft.Xna.Framework;
using Joguinho.Scripts.GameComponents.Physics.Interface;

namespace Joguinho.Scripts.GameComponents.Physics.Collision
{
    public class BoxCollider : Collider
    {
        public Vector2 min;
        public Vector2 max;

        public Vector2 size;

        public BoxCollider(Object newGameObject) : base(newGameObject)
        {

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
            min = new Vector2(gameObject.GetPosition().X - (size.X / 2) + localPosition.X, gameObject.GetPosition().Y - (size.Y / 2) + localPosition.Y);
            max = new Vector2(gameObject.GetPosition().X + (size.X / 2) + localPosition.X, gameObject.GetPosition().Y + (size.Y / 2) + localPosition.Y);
        }
    }
}
