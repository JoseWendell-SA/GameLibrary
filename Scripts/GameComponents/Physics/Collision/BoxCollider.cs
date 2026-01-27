using Microsoft.Xna.Framework;

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
            min = new Vector2(gameObject.GetPosition().X - (size.X/2) + localPosition.X, gameObject.GetPosition().Y - (size.Y/2) + localPosition.Y);
            max = new Vector2(gameObject.GetPosition().X + (size.X/2) + localPosition.X, gameObject.GetPosition().Y + (size.Y/2) + localPosition.Y);
        }

        public void SetBoxSize(Vector2 newSize)
        {
            size = newSize;
            min = new Vector2(gameObject.GetPosition().X - (size.X/2) + localPosition.X, gameObject.GetPosition().Y - (size.Y/2) + localPosition.Y);
            max = new Vector2(gameObject.GetPosition().X + (size.X/2) + localPosition.X, gameObject.GetPosition().Y + (size.Y/2) + localPosition.Y);
        }
    }
}
