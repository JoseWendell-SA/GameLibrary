using Joguinho.Scripts.GameComponents.Physics.Collision;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts
{
    public class GameManager
    {
        public static GameManager GMInstance;

        public World world;

        private List<BoxCollider> colliders = new List<BoxCollider>();

        public GameManager(World newWorld)
        {
            GMInstance = this;
            world = newWorld;
        }

        public void Update()
        {
            world.Update();
            IdentifyCollidingBoxes();
        }

        public void IdentifyCollidingBoxes()
        {
            for (int n = 0; n < colliders.Count; n++)
            {
                for (int m = n+1; m < colliders.Count; m++)
                {
                    if (AABBvsAABB(colliders[n], colliders[m]))
                    {
                        int k = 0;
                        while (k < colliders[n].collisionTag.Count)
                        {
                            if (colliders[m].collisionTag.Contains(colliders[n].collisionTag[k]))
                            {
                                colliders[n].OnCollision(colliders[m]);
                                colliders[m].OnCollision(colliders[n]);

                                k = colliders[n].collisionTag.Count;
                            }

                            k++;
                        }
                    }
                }
            }
        }

        public void InsertNewBoxCollider(BoxCollider newBoxCollider)
        {
            colliders.Add(newBoxCollider);
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
            oldObject.RemoveAllComponents();

            if (oldObject is Projectile)
            {
                world.projectiles.Remove(oldObject as Projectile);
            }

            else if (oldObject is Entity)
            {
                world.entities.Remove(oldObject as Entity);
            }
        }
    }
}
