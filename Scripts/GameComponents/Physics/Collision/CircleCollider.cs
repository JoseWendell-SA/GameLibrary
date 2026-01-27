using Microsoft.Xna.Framework;

namespace Joguinho.Scripts.GameComponents.Physics.Collision
{
    public class CircleCollider : Collider
    {
        public CircleCollider(Object newGameObject) : base(newGameObject)
        {
            
        }

        public float radius;
        public Vector2 position;
    }
}
