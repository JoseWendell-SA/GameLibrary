using GameLIB.Scripts.GameComponents.Physics;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using GameLIB.Scripts.GameComponents.Physics.Interface;
using GameLIB.Scripts.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace GameLIB.Scripts.Objects.Entities
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
            rigidbody = AddComponent<Rigidbody>();
        }

        public override void Update()
        {
            if (target != null)
            {
                Vector2 direction = GameUtilities.DiffBetweenA_B(target.transform.position, transform.position);
                float angle = (float)(Math.Atan2(direction.Y, direction.X));
                rotation = angle;

                Vector2 mov = new Vector2(MathF.Cos(rotation), MathF.Sin(rotation));

                //rigidbody.AddForce(mov * speed * Time.deltaTime);
                rigidbody.velocity = mov * speed * Time.deltaTime;
            }

            base.Update();
        }

        public void ChangeType(int num)
        {
            health *= num;
            enemyType = num;
            score = score * enemyType;

            //speed = speed + (((float)num-1)/3) + (GameManager.GMInstance.difficultyLevel-1)/10;
            speed = 45f;
        }

        public void OnCollisionEnter(Collider collider)
        {
            if (collider.collisionTag.Contains(CollisionTag.Projectile))
            {
                health -= 1;

                if (health <= 0)
                {
                    GameManager.GMInstance.NotifyPlayerAboutEnemyDeath(enemyType);

                    Console.WriteLine("Enemy tier " + enemyType + " has been destroyed");
                    
                    GameManager.GMInstance.score += score;
                    GameManager.GMInstance.DeleteObject(this);
                }
            }
        }
    }
}
