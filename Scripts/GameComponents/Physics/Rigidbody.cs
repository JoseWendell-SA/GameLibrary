using System;
using System.Collections.Generic;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.Interface;
using Joguinho.Scripts;
using Microsoft.Xna.Framework;
using Joguinho.Scripts.System;

namespace Joguinho.Scripts.GameComponents.Physics
{
    public class Rigidbody : ObjectComponent
    {
        public Vector2 currentSpeed = new Vector2(0, 0);
        public int rotationDir = 0;
        public int timer = 0;
        public float mass = 1;
        public float drag = 1;

        public Vector2 velocity;

        public Rigidbody(Object newGameObject) : base(newGameObject)
        {
            RigidbodySystem.Register(this);
        }

        public override void Update()
        {
            gameObject.UpdatePosition(velocity);

            velocity = velocity * (1 - Time.deltaTime * drag);
        }

        public void AddForce(Vector2 force)
        {
            Vector2 acceleration = force / mass;

            velocity += acceleration;
        }
    }
}
