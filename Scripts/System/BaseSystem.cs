using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics;
using GameLIB.Scripts.GameComponents.Physics.Collision;

namespace GameLIB.Scripts.System
{
    public class BaseSystem<T> where T : ObjectComponent
    {
        protected static List<T> components = new List<T>();

        public static void Register(T newComponent)
        {
            components.Add(newComponent);
        }

        public virtual void Update()
        {
            for (int n = 0; n < components.Count ; n++)
            {
                components[n].Update();
            }
        }

        public static void Unregister(T oldComponent)
        {
            components.Remove(oldComponent);
        }
    }

    public class RigidbodySystem : BaseSystem<Rigidbody> { }
    public class CollisionSystem : BaseSystem<Collider>
    {
        public override void Update()
        {
            for (int n = 0; n < components.Count ; n++)
            {
                components[n].Update();

                for (int k = 0; k < components.Count; k++)
                {
                    if (n == k)
                        continue;

                    if(components[n].CheckCollision(components[k]))
                    {
                        components[n].OnCollision(components[k]);
                        components[k].OnCollision(components[n]);
                    }
                }
            }
        }
    }
}
