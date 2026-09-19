using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics.Interface;
using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GameLIB.Scripts.GameComponents.Physics.Collision
{
    public class Collider : ObjectComponent
    {
        public Vector2 localPosition;

        public List<CollisionTag> collisionTag { get; private set; } = new List<CollisionTag>();
        public float restitution = 0;

        public Collider(Object newGameObject) : base(newGameObject)
        {
            
        }

        public override void DeleteComponent()
        {
            CollisionSystem.Unregister(this);
        }

        public virtual bool CheckCollision(Collider newCol)
        {
            return false;
        }

        public virtual bool CheckCollision(BoxCollider boxCol)
        {
            return false;
        }

        public virtual bool CheckCollision(CircleCollider boxCol)
        {
            return false;
        }

        public void OnCollision(Collider collider)
        {
            IOnCollisionEnter IcollsionEnter = gameObject as IOnCollisionEnter;
            if (IcollsionEnter != null)
            {
                IcollsionEnter.OnCollisionEnter(collider);
            }
        }

        public void SetNewCollisionTag(List<CollisionTag> newCollisiontag)
        {
            collisionTag = newCollisiontag;
        }
    }

    public enum CollisionTag {Terrain, Enemy, Projectile, Player};
}
