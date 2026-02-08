using Joguinho.Scripts.GameComponents.Physics;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.GameComponents.Physics.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts.Entities
{
    public class GenericEnemy : Entity, IOnCollisionEnter
    {
        private Entity target;
        private float speed;

        private Rigidbody rigidbody;

        private float health = 3;

        public GenericEnemy(Vector2 newPosition) : base(newPosition)
        {
            
        }

        public override void StartObject()
        {
            target = GameManager.GMInstance.GetEntityByCollisionTag(CollisionTag.Player);
            AddComponent<Rigidbody>();
            rigidbody = GetComponent<Rigidbody>();
        }

        public override void Update()
        {
            if (target != null)
            {
                Vector2 direction = GameUtilities.DiffBetweenA_B(target.GetPosition(), position);
                float angle = (float)(Math.Atan2(direction.Y, direction.X));
                rotation = angle;

                Vector2 mov = new Vector2(MathF.Cos(rotation), MathF.Sin(rotation));

                rigidbody.AddForce(mov * speed);
            }

            base.Update();
        }

        public void OnCollisionEnter(Collider collider)
        {
            if (collider.collisionTag.Contains(CollisionTag.Projectile))
            {
                health -= 1;

                if (health <= 0)
                {
                    GameManager.GMInstance.DeleteObject(this);
                }
            }
        }
    }
}
