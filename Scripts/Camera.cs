using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GameLIB.Scripts.GameComponents.Graphics;
using GameLIB.Scripts.GameComponents.Physics;
using GameLIB.Scripts.Objects.Entities;

namespace GameLIB.Scripts
{
    public class Camera
    {
        public Transform transform { get; private set; } = new Transform();

        bool FreeMode = false;
        Entity Target;
        public readonly int offsetX = 140;
        public readonly int offsetY = 120;

        public Camera(int width, int height)
        {
            offsetX = width / 2;
            offsetY = height / 2;
        }

        public void Update()
        {
            if (Target != null)
            {
                Sprite targetSprite = Target.GetComponent<Sprite>();

                transform.position = Target.transform.position;
                
                if (targetSprite != null)
                {
                    //transform.position -= targetSprite.GetSize() / 2;
                    //transform.position.X -= Target.GetComponent<Sprite>().GetRectSize().X / 2;
                    //transform.position.Y -= Target.GetComponent<Sprite>().GetRectSize().Y / 2;
                }
            }
        }

        public Vector2 GetCameraPosition()
        {
            return new Vector2(transform.position.X - offsetX, transform.position.Y - offsetY);
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
