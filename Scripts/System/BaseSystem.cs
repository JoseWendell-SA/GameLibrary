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
            for (int n = 0; n < components.Count; n++)
            {
                components[n].Update();
            }
        }
    }

    public class RigidbodySystem : BaseSystem<Rigidbody> { }
    public class CollisionSystem : BaseSystem<Collider> { }
}
