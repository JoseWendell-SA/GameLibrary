using System;
using System.Collections.Generic;

namespace Joguinho.Scripts
{
    public class Camera
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        bool FreeMode = false;
        Entity Target;
        public readonly int offsetX = 140;
        public readonly int offsetY = 120;

        public Camera(int width, int height)
        {
            X = 0;
            Y = 0;

            offsetX = width / 2;
            offsetY = height / 2;
        }

        public int GetX()
        {
            return X;
        }

        public int GetY()
        {
            return Y;
        }

        public void Update()
        {
            X = (int)(Target.GetPosition().X - Target.GetSpriteSize().X / 2);
            Y = (int)(Target.GetPosition().Y - Target.GetSpriteSize().Y / 2);
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
