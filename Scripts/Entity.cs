using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using GameLIB.Scripts.System;

namespace GameLIB.Scripts
{
    public class Entity : Object
    {
        public Entity(Vector2 newPosition) : base(newPosition)
        {
            EntitySystem.Register(this);
        }

        public virtual void Update()
        {
            if (startTimer)
            {
                if (timerInFrames > 0)
                {
                    timerInFrames -= 1;
                }

                else
                {
                    Destroy();
                }
            }
        }

        public void SetTimerToDestroy(int newTimerInFrames)
        {
            timerInFrames = newTimerInFrames;
            startTimer = true;
        }

        public override void Destroy()
        {
            base.Destroy();
            EntitySystem.Unregister(this);
        }
    }
}
