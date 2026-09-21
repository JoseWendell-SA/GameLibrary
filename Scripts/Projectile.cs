using System;
using System.Collections.Generic;
using GameLIB.Scripts.GameComponents.Physics;
using Microsoft.Xna.Framework;
using GameLIB.Scripts.GameComponents.Physics.Interface;
using GameLIB.Scripts.GameComponents.Physics.Collision;

namespace GameLIB.Scripts
{
    public class Projectile : Entity, IOnCollisionEnter
    {
        private Player origin;

        private float speed = 5f;

        private Rigidbody rigidbody;

        public Projectile(Vector2 newPosition) : base(newPosition)
        {
            
        }

        public override void StartObject()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public override void Update()
        {
            base.Update();

            Vector2 mov = new Vector2(MathF.Cos(rotation), MathF.Sin(rotation));

            rigidbody.AddForce(mov * speed * Time.deltaTime);

            for (int n = 0; n < components.Count; n++)
            {
                components[n].Update();
            }
        }

        public void ChangeSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public void SetNewOrigin(Player player)
        {
            origin = player;
        }

        public Player GetOrigin()
        {
            return origin;
        }

        public void OnCollisionEnter(Collider collider)
        {
            if (collider.collisionTag.Contains(CollisionTag.Enemy))
            {
                GameManager.GMInstance.DeleteObject(this);
            }
        }
    }
}
