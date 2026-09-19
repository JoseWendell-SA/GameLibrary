using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.GameComponents.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts
{
    public static class GameUtilities
    {
        /*public static void CreateObject<T>(Vector2 position, float rotation) where T : Object
        {
            Object newGameObject = (T)Activator.CreateInstance(typeof(T), new object[] {  });
        }*/

        public static void CreateProjectile(Vector2 origin, int timer, float rotation, List<CollisionTag> collisionTag)
        {
            Projectile newProjectile = new Projectile(origin);
            newProjectile.UpdateAngle(rotation);
            newProjectile.SetTimerToDestroy(timer);
            ComponentUtilities.AddBoxCollider(newProjectile, 3, 3, collisionTag);
            newProjectile.AddComponent<Rigidbody>();
            newProjectile.StartObject();
            ComponentUtilities.AddSprite(newProjectile, 34, 16, 16, 2);

            GameManager.GMInstance.world.projectiles.Add(newProjectile);
        }

        public static Vector2 DiffBetweenA_B(Vector2 pointA, Vector2 pointB)
        {
            Vector2 result = new Vector2(pointA.X - pointB.X, pointA.Y - pointB.Y);

            return result;
        }
    }
}
