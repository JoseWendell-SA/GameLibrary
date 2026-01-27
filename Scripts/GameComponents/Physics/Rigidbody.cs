using System;
using System.Collections.Generic;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.Graphics.Interface;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts.GameComponents.Physics
{
    public class Rigidbody : ObjectComponent
    {
        public Vector2 currentSpeed = new Vector2(0, 0);
        public Vector2 direction = new Vector2(0, 0);
        public int rotationDir = 0;
        public int timer = 0;

        public Rigidbody(Object newGameObject) : base(newGameObject)
        {
            
        }

        public override void Update()
        {
            BoxCollider simulatedCollision = new BoxCollider(gameObject);
            simulatedCollision.localPosition = new Vector2(direction.X, direction.Y);
            simulatedCollision.SetBoxSize(gameObject.GetComponent<BoxCollider>().size);

            List<Object> collidingWith = GameManager.GMInstance.world.DoesItCollides(simulatedCollision);

            if (collidingWith.Count == 0)
            {
                gameObject.UpdatePosition(direction);
                //gameObject.UpdateRotation(rotationDir);
            }
        }

        public void AddForce(Vector2 newDirection)
        {
            direction.X = newDirection.X;
            direction.Y = newDirection.Y;
        }
    }
}
