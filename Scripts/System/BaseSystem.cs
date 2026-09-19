using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics;
using Joguinho.Scripts.GameComponents.Physics.Collision;

namespace Joguinho.Scripts.System
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
