using Joguinho.Scripts.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts
{
    public class Camera
    {
        private Vector2 position;

        bool FreeMode = false;
        Entity Target;
        public readonly int offsetX = 140;
        public readonly int offsetY = 120;

        public Camera(int width, int height)
        {
            position = new Vector2(0, 0);

            offsetX = width / 2;
            offsetY = height / 2;
        }

        public float GetX()
        {
            return position.X;
        }

        public float GetY()
        {
            return position.Y;
        }

        public void Update()
        {
            if (Target != null)
            {
                Sprite targetSprite = Target.GetComponent<Sprite>();

                position.X = Target.GetPosition().X;
                position.Y = Target.GetPosition().Y;
                
                if (targetSprite != null)
                {
                    position.X -= Target.GetComponent<Sprite>().GetSize().X / 2;
                    position.Y -= Target.GetComponent<Sprite>().GetSize().Y / 2;
                }
            }
        }

        public void DefineTarget(Entity newTarget)
        {
            Target = newTarget;
        }

        public Entity GetTarget()
        {
            return Target;
        }
    }
}
