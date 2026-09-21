using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLIB.Scripts.System
{
    public class EntitySystem
    {
        private static List<Entity> entities = new List<Entity>();

        public static void Register(Entity newEntity)
        {
            entities.Add(newEntity);
        }

        public static void Unregister(Entity oldEntity)
        {
            entities.Remove(oldEntity);

            Console.WriteLine("A Entity has been removed, total: " + entities.Count);
        }

        public void Update()
        {
            for (int n = 0; n < entities.Count; n++)
            {
                entities[n].Update();
            }
        }
    }
}
