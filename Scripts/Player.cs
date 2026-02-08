using Joguinho.Scripts.GameComponents.Physics;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.GameComponents.Physics.Interface;
using Joguinho.Scripts.Graphics;
using Joguinho.Scripts.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts
{
    public class Player : Entity, IOnCollisionEnter
    {
        private KeyboardState keyboardPrev = new KeyboardState();
        private MouseState mousePrev = new MouseState();
        private MouseState mouseCur;

        private int num = 0;
        private int timer = 1;

        private int fireRate = 10;
        private int timeToNextShot = 0;

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
            mouseCur = Mouse.GetState();

            num += 1;

            if (keyboardCur.IsKeyDown(Keys.W))
            {
                mov.Y = -1;
            }

            else if (keyboardCur.IsKeyDown(Keys.S))
            {
                mov.Y = 1;
            }

            else
            {
                mov.Y = 0;
            }

            if (keyboardCur.IsKeyDown(Keys.D))
            {
                mov.X = 1;
            }

            else if (keyboardCur.IsKeyDown(Keys.A))
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

            Vector2 direction = GameUtilities.DiffBetweenA_B(MouseInput.GetMouseMapPosition(), new Vector2(GetPosition().X - GetComponent<Sprite>().GetSize().X / 2, GetPosition().Y - GetComponent<Sprite>().GetSize().Y / 2));
            float angle = (float)(Math.Atan2(direction.Y, direction.X));
            rotation = angle;

            if (mouseCur.LeftButton == ButtonState.Pressed && num > timeToNextShot)
            {
                List<CollisionTag> collisionTags = [CollisionTag.Projectile];
                GameUtilities.CreateProjectile(GetPosition(), 120, angle, collisionTags);

                timeToNextShot = num + fireRate;
            }

            rigidbody.AddForce(mov);
            
            keyboardPrev = keyboardCur;

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
