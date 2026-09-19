using Joguinho.Scripts.Entities;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics.Collision;

namespace Joguinho.Scripts.EventSystem
{
    public class EnemyGeneratorSystem
    {
        Random random = new Random();

        private int enemyLimit = 0;

        Entity target;

        public EnemyGeneratorSystem(Entity player)
        {
            target = player;
        }

        public void Update()
        {
            if (GameManager.GMInstance.world.entities.Count-1 < enemyLimit)
            {
                int posX = random.Next(-150, 150);
                int posY = random.Next(-145, 146);

                if (posX >= -145 && posX <= 145)
                {
                    posY = random.Next(-1, 1);

                    posY = 145 * posY + 145 * (posY + 1);
                }

                else if (posY >= -145 && posY <= 145)
                {
                    posX = random.Next(-1, 1);

                    posX = 145 * posX + 145 * (posX + 1);
                }

                    Console.WriteLine("PosX: " + posX + " - PosY: " + posY);
                Console.WriteLine("X: " + (posX + target.transform.position.X) + " - Y: " + (posY + target.transform.position.Y));

                GenericEnemy newEnemy = new GenericEnemy(new Vector2(posX + target.transform.position.X, posY + target.transform.position.Y));
                List<CollisionTag> collisionTag = [CollisionTag.Enemy];
                ComponentUtilities.AddBoxCollider(newEnemy, 12, 12, collisionTag);

                int enemyType = random.Next(1, 100);

                if (enemyType <= 10)
                {
                    newEnemy.ChangeType(3);
                    ComponentUtilities.AddSprite(newEnemy, 33, 16, 16, 2);
                }

                else if (enemyType <= 35)
                {
                    newEnemy.ChangeType(2);
                    ComponentUtilities.AddSprite(newEnemy, 32, 16, 16, 2);
                }

                else if (enemyType <= 100)
                {
                    newEnemy.ChangeType(1);
                    ComponentUtilities.AddSprite(newEnemy, 31, 16, 16, 2);
                }

                newEnemy.StartObject();
                GameManager.GMInstance.world.entities.Add(newEnemy);
            }
        }
    }
}
