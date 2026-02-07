using System;
using System.Collections.Generic;
using Joguinho.Scripts.GameComponents.Physics;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.GameComponents.Physics.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Joguinho.Scripts
{
    public class Player : Entity, IOnCollisionEnter
    {
        private KeyboardState keyboardPrev = new KeyboardState();
        private MouseState mousePrev = new MouseState();
        private MouseState mouseCur;

        private int num = 0;
        private int timer = 1;

        private Rigidbody rigidbody;

        private Vector2 mov = new Vector2(0, 0);

        public Player(Vector2 newPosition) : base(newPosition)
        {
            //rigidbody = new Rigidbody(this);
            //components.Add(rigidbody);
            AddComponent<Rigidbody>();
            rigidbody = GetComponent<Rigidbody>();
        }

        public override void Update()
        {
            KeyboardState keyboardCur = Keyboard.GetState();

            num += 1;

            if (keyboardCur.IsKeyDown(Keys.Up) && num % timer == 0)
            {
                mov.Y = -1;
            }

            else if (keyboardCur.IsKeyDown(Keys.Down) && num % timer == 0)
            {
                mov.Y = 1;
            }

            else
            {
                mov.Y = 0;
            }

            if (keyboardCur.IsKeyDown(Keys.Right) && num % timer == 0)
            {
                mov.X = 1;
            }

            else if (keyboardCur.IsKeyDown(Keys.Left) && num % timer == 0)
            {
                mov.X = -1;
            }

            else
            {
                mov.X = 0;
            }

            if (keyboardPrev.IsKeyUp(Keys.U) && keyboardCur.IsKeyDown(Keys.U))
            {
                if (timer > 1)
                {
                    timer -= 1;
                }
            }

            if (keyboardPrev.IsKeyUp(Keys.I) && keyboardCur.IsKeyDown(Keys.I))
            {
                if (timer < 60)
                {
                    timer += 1;
                }
            }

            if (keyboardPrev.IsKeyUp(Keys.C) && keyboardCur.IsKeyDown(Keys.C))
            {
                
            }

            rigidbody.AddForce(mov);
            
            keyboardPrev = keyboardCur;

            if (num >= 60)
                num = 0;

            base.Update();
        }

        public override void Move()
        {
            
        }

        public void OnCollisionEnter(Collider collider)
        {

        }
    }
}
