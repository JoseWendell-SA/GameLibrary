using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Joguinho.Scripts.Entities
{
    public class GenericEnemy : Entity
    {
        private Entity target;

        public GenericEnemy(Vector2 newPosition) : base(newPosition)
        {

        }

        public override void StartObject()
        {
            
        }

        public override void Update()
        {
            base.Update();
        }

        public void FindTarget()
        {
            
        }
    }
}
