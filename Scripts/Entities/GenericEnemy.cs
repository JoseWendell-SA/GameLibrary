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
        private float speed = 1;

        private Rigidbody rigidbody;

        private int health = 3;
        private int enemyType = 1;

        private int score = 10;

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

        public void ChangeType(int num)
        {
            health *= num + GameManager.GMInstance.difficultyLevel / 2;
            enemyType = num;
            score = score * enemyType + GameManager.GMInstance.difficultyLevel * 2;

            speed = speed + (((float)num-1)/3) + (GameManager.GMInstance.difficultyLevel-1)/10;
        }

        public void OnCollisionEnter(Collider collider)
        {
            if (collider.collisionTag.Contains(CollisionTag.Projectile))
            {
                health -= 1;

                if (health <= 0)
                {
                    GameManager.GMInstance.NotifyPlayerAboutEnemyDeath(enemyType * GameManager.GMInstance.difficultyLevel);

                    Console.WriteLine("Enemy tier " + enemyType + " has been destroyed");
                    
                    GameManager.GMInstance.score += score;
                    GameManager.GMInstance.DeleteObject(this);
                }
            }
        }
    }
}
