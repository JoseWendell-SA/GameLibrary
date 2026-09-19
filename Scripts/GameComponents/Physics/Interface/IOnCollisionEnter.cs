using GameLIB.Scripts.GameComponents.Physics.Collision;
using System;
using System.Collections.Generic;

namespace GameLIB.Scripts.GameComponents.Physics.Interface
{
    interface IOnCollisionEnter
    {
        void OnCollisionEnter(Collider collider);
    }
}
