using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts
{
    public static class GameUtilities
    {
        /*public static void CreateObject<T>(Vector2 position, float rotation) where T : Object
        {
            Object newGameObject = (T)Activator.CreateInstance(typeof(T), new object[] {  });
        }*/

        public static void CreateProjectile(Vector2 origin, float timer, float rotation)
        {
            Projectile newProjectile = new Projectile(origin);
            newProjectile.UpdateAngle(rotation);
            newProjectile.SetTimerToDestroy(timer);
        }

        public static Vector2 DiffBetweenA_B(Vector2 pointA, Vector2 pointB)
        {
            Vector2 result = new Vector2(pointA.X - pointB.X, pointA.Y - pointB.Y);

            return result;
        }
    }
}
