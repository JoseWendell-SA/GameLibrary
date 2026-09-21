using System;
using System.Collections.Generic;
using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;

namespace GameLIB.Scripts
{
    public class Object
    {
        public Transform transform { get; private set; } = new Transform();

        protected List<ObjectComponent> components = new List<ObjectComponent>();

        public float rotation = 0;

        protected bool startTimer = false;
        protected float timerInFrames = 0;

        public Object(Vector2 newPosition)
        {
            transform.position = newPosition;
        }

        public virtual void StartObject()
        {
            
        }

        public void UpdatePosition(Vector2 newPosition)
        {
            transform.position += newPosition;
        }

        public void UpdateAngle(float newRotation)
        {
            rotation = newRotation;
        }

        public bool HasComponent<T>() where T : ObjectComponent
        {
            int n = 0;
            while (n < components.Count)
            {
                if (components[n].GetType() == typeof(T))
                    return true;
                n++;
            }

            return false;
        }

        public T GetComponent<T>() where T : ObjectComponent
        {
            for (int n = 0; n < components.Count; n++)
            {
                if (components[n].GetType() == typeof(T))
                    return (T)components[n];
            }

            return null;
        }

        public T AddComponent<T>() where T : ObjectComponent
        {
            if (HasComponent<T>())
            {
                Console.WriteLine("This " + this.GetType().Name + " object already has a " + typeof(T).Name + " component");

                return GetComponent<T>();
            }

            T newComponent = (T)Activator.CreateInstance(typeof(T), new object[] {this});

            components.Add(newComponent);

            return newComponent;
        }

        public void RemoveAllComponents()
        {
            for (int n = 0 ; n < components.Count; n++)
            {
                components[n].DeleteComponent();
            }

            components.RemoveRange(0, components.Count);
        }

        public virtual void Destroy()
        {
            RemoveAllComponents();
        }
    }
}
