using GameLIB.Scripts.Entities;
using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace GameLIB.Scripts
{
    public class GameManager
    {
        public static GameManager GMInstance;

        public World world;

        private List<Object> deleteList = new List<Object>();

        public int gameLevel {get; private set;} = 0;
        public int score = 0;
        public char[] name = [' ', ' ', ' '];
        public int nameIndex = 0;

        public GameManager(World newWorld)
        {
            world = newWorld;
            GMInstance = this;

            List<CollisionTag> test = [CollisionTag.Player];
        }

        public void Update(GameTime gameTime)
        {
            world.Update();
            ClearAllObjectsInDeleteList();
        }

        public void NotifyPlayerAboutEnemyDeath(int num)
        {
            
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
                    //world.projectiles.Remove(deleteList[0] as Projectile);
                }

                else if (deleteList[0] is Entity)
                {
                    //world.entities.Remove(deleteList[0] as Entity);
                }

                deleteList.RemoveAt(0);
            }
        }

        public Entity GetEntityByCollisionTag(CollisionTag targetTag)
        {
            return null;
        }

        public void ChangeGameLevel(int newLevel)
        {
            gameLevel = newLevel;
        }
    }
}
