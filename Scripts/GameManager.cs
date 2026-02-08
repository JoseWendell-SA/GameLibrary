using Joguinho.Scripts.Entities;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace Joguinho.Scripts
{
    public class GameManager
    {
        public static GameManager GMInstance;

        public World world;

        private List<BoxCollider> colliders = new List<BoxCollider>();

        private List<Object> deleteList = new List<Object>();

        public GameManager(World newWorld)
        {
            world = newWorld;
            GMInstance = this;

            world.entities.Add(new GenericEnemy(new Vector2(-10, -10)));

            List<CollisionTag> test = [CollisionTag.Player];
            List<CollisionTag> test2 = [CollisionTag.Enemy];

            ComponentUtilities.AddBoxCollider(world.entities[0], 16, 16, test);
            ComponentUtilities.AddBoxCollider(world.entities[1], 16, 16, test2);
        }

        public void Update()
        {
            world.Update();
            IdentifyCollidingBoxes();
            ClearAllObjectsInDeleteList();
        }

        private void IdentifyCollidingBoxes()
        {
            for (int n = 0; n < colliders.Count; n++)
            {
                for (int m = n+1; m < colliders.Count; m++)
                {
                    if (AABBvsAABB(colliders[n], colliders[m]))
                    {
                        colliders[n].OnCollision(colliders[m]);
                        colliders[m].OnCollision(colliders[n]);
                    }
                }
            }
        }

        public void InsertNewBoxCollider(BoxCollider newBoxCollider)
        {
            if (!colliders.Contains(newBoxCollider))
            {
                colliders.Add(newBoxCollider);
            }
        }

        public List<Object> DoesItCollides(BoxCollider target)
        {
            List<Object> gameObjects = new List<Object>();

            for (int n = 0; n < colliders.Count; n++)
            {
                if (target.gameObject != colliders[n].gameObject)
                {
                    if (AABBvsAABB(target, colliders[n]))
                    {
                        gameObjects.Add(colliders[n].gameObject);
                    }
                }
            }

            return gameObjects;
        }

        public bool AABBvsAABB(BoxCollider a, BoxCollider b)
        {
            if (a.max.X < b.min.X || a.min.X > b.max.X)
                return false;
            else if (a.max.Y < b.min.Y || a.min.Y > b.max.Y)
                return false;

            return true;
        }

        public void RemoveCollider(Collider oldCollider)
        {
            Console.WriteLine("Total Colliders: " + colliders.Count);
            colliders.Remove(oldCollider as BoxCollider);
        }

        public void DeleteObject(Object oldObject)
        {
            if (!deleteList.Contains(oldObject))
            {
                deleteList.Add(oldObject);
            }
        }

        private void ClearAllObjectsInDeleteList()
        {
            while (deleteList.Count > 0)
            {
                deleteList[0].RemoveAllComponents();

                if (deleteList[0] is Projectile)
                {
                    world.projectiles.Remove(deleteList[0] as Projectile);
                }

                else if (deleteList[0] is Entity)
                {
                    world.entities.Remove(deleteList[0] as Entity);
                }

                deleteList.RemoveAt(0);
            }
        }

        public Entity GetEntityByCollisionTag(CollisionTag targetTag)
        {
            int n = 0;

            while (n < world.entities.Count)
            {
                if (world.entities[n].GetComponent<BoxCollider>().collisionTag.Contains(targetTag))
                {
                    return world.entities[n];
                }

                n++;
            }

            return null;
        }
    }
}
