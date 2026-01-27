using System;
using System.Collections.Generic;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts
{
    public class Object
    {
        protected Vector2 position;

        protected int SpriteX;
        protected int SpriteY;

        protected Vector2 SpriteSize = new Vector2(16, 16);

        protected List<ObjectComponent> components = new List<ObjectComponent>();

        public float rotation = 0;

        protected bool startTimer = false;
        protected float timer = 0;

        public Object(Vector2 newPosition)
        {
            position = newPosition;
        }

        public virtual void Update()
        {
            if (startTimer)
            {
                if (timer <= 0)
                {
                    
                }
            }
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            position.X += newPosition.X;
            position.Y += newPosition.Y;
        }

        public void UpdateAngle(float newRotation)
        {
            rotation = newRotation;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public Vector2 GetSpriteSize()
        {
            return SpriteSize;
        }

        public int GetSpriteX()
        {
            return SpriteX * 16;
        }

        public int GetSpriteY()
        {
            return SpriteY * 16;
        }

        public void SetSprite(int x, int y)
        {
            SpriteX = x;
            SpriteY = y;
        }

        public T GetComponent<T>() where T : ObjectComponent
        {
            for (int n = 0; n < components.Count; n++)
            {
                if (components[n].GetType() == typeof(T))
                {
                    return components[n] as T;
                }
            }

            return null;
        }

        public void AddComponent<T>(object newGameObject) where T : ObjectComponent
        {
            components.Add((T)Activator.CreateInstance(typeof(T), new object[] {newGameObject}));
        }

        public void SetTimerToDestroy(float newTimer)
        {
            timer = newTimer;
            startTimer = true;
        }
    }
}
