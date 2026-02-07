using System;
using System.Collections.Generic;
using Joguinho.Scripts.GameComponents.Physics;
using Microsoft.Xna.Framework;
using Joguinho.Scripts.GameComponents.Physics.Interface;
using Joguinho.Scripts.GameComponents.Physics.Collision;

namespace Joguinho.Scripts
{
    public class Projectile : Object, IOnCollisionEnter
    {
        private float speed = 1;

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

            rigidbody.AddForce(mov);

            for (int n = 0; n < components.Count; n++)
            {
                components[n].Update();
            }
        }

        public void ChangeSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        public void OnCollisionEnter(Collider collider)
        {
            if (!(collider.gameObject is Player))
                GameManager.GMInstance.DeleteObject(this);
        }
    }
}
