using GameLIB.Scripts.Entities;
using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using GameLIB.Scripts.EventSystem;

namespace GameLIB.Scripts
{
    public class GameManager
    {
        public static GameManager GMInstance;
        private EnemyGeneratorSystem enemyGenerator;

        public World world;

        private List<Object> deleteList = new List<Object>();

        private List<FinalScore> allScores;

        public int gameLevel {get; private set;} = 0;
        public int difficultyLevel = 1;
        public int score = 0;
        public char[] name = [' ', ' ', ' '];
        public int nameIndex = 0;

        public GameManager(World newWorld)
        {
            world = newWorld;
            GMInstance = this;

            List<CollisionTag> test = [CollisionTag.Player];

            ComponentUtilities.AddBoxCollider(world.entities[0], 12, 12, test);
            enemyGenerator = new EnemyGeneratorSystem(world.entities[0]);
        }

        public void Update(GameTime gameTime)
        {
            world.Update();
            enemyGenerator.Update();
            ClearAllObjectsInDeleteList();

            if ((int)gameTime.TotalGameTime.TotalSeconds > 0 && (int)gameTime.TotalGameTime.TotalSeconds % (15 * difficultyLevel) == 0)
            {
                difficultyLevel += 1;
                Console.WriteLine("Difficulty Level Increased: " + difficultyLevel);
            }
        }

        public void NotifyPlayerAboutEnemyDeath(int num)
        {
            (world.entities[0] as Player).AddXp(num);
        }

        public bool AABBvsAABB(BoxCollider a, BoxCollider b)
        {
            if (a.max.X < b.min.X || a.min.X > b.max.X)
                return false;
            else if (a.max.Y < b.min.Y || a.min.Y > b.max.Y)
                return false;

            return true;
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

        public void SetAllScores(List<FinalScore> loadedScores)
        {
            allScores = loadedScores;
        }

        public List<FinalScore> GetAllScores()
        {
            return allScores;
        }

        public void ChangeGameLevel(int newLevel)
        {
            gameLevel = newLevel;
        }
    }
}
