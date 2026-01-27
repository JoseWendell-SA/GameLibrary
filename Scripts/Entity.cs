using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Joguinho.Scripts.GameComponents.Physics.Collision;

namespace Joguinho.Scripts
{
    public class Entity : Object
    {
        Camera camera;

        public Entity(Vector2 newPosition) : base(newPosition)
        {

        }

        public virtual void Update()
        {
            for (int n = 0; n < components.Count; n++)
            {
                components[n].Update();
            }
        }

        public virtual void Move()
        {
            
        }

        public void SetCamera(Camera newCamera)
        {
            camera = newCamera;
        }
    }
}
