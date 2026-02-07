using Joguinho.Scripts.GameComponents.Physics.Collision;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts.GameComponents.Physics.Interface
{
    interface IOnCollisionEnter
    {
        void OnCollisionEnter(Collider collider);
    }
}
