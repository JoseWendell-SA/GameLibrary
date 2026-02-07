using System;
using System.Collections.Generic;

namespace Joguinho.Scripts.GameComponents
{
    public class ObjectComponent
    {
        public Object gameObject { get; private set; }

        public ObjectComponent(Object newGameObject)
        {
            gameObject = newGameObject;
        }

        public virtual void DeleteComponent()
        {
            
        }

        public virtual void Update()
        {
            
        }
    }
}
