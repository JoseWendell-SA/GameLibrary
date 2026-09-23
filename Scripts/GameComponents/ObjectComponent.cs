using GameLIB.Scripts.Objects;
using System;
using System.Collections.Generic;

namespace GameLIB.Scripts.GameComponents
{
    public class ObjectComponent
    {
        public GameObject gameObject { get; private set; }

        public ObjectComponent(GameObject newGameObject)
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
