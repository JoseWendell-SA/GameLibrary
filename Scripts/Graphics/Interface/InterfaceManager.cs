using Joguinho.Scripts.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace Joguinho.Scripts.Graphics.Interface
{
    public static class InterfaceManager
    {
        static SpriteBatch batch;

        static List<Sprite> sprite = new List<Sprite>();

        public static void InsertSprite(Sprite newSprite)
        {

            if (sprite.Count == 0)
            {
                sprite.Add(newSprite);
            }

            else
            {
                int n = 1;
                int newSpriteLayer = newSprite.GetLayer();

                if (sprite[0].GetLayer() > newSpriteLayer)
                {
                    sprite.Insert(0, newSprite);
                }

                else
                {
                    while (n < sprite.Count && newSpriteLayer > sprite[n].GetLayer())
                    {
                        n++;
                    }

                    if (n == sprite.Count)
                    {
                        sprite.Add(newSprite);
                    }

                    else
                    {
                        sprite.Insert(n, newSprite);
                    }
                }
            }
        }

        public static void RemoveSprite(Sprite oldSprite)
        {

        }

        public static void DrawElements(Texture2D texture)
        {
            float posX;
            float posY;
            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            for (int n = 0; n < sprite.Count; n++)
            {
                posX = (sprite[n].gameObject.GetPosition().X - sprite[n].GetSize().X / 2) - GameManager.GMInstance.world.camera.GetX() + GameManager.GMInstance.world.camera.offsetX;
                posY = (sprite[n].gameObject.GetPosition().Y - sprite[n].GetSize().Y / 2) - GameManager.GMInstance.world.camera.GetY() + GameManager.GMInstance.world.camera.offsetY;
                Rectangle rect = new Rectangle((int)sprite[n].GetSprite().X, (int)sprite[n].GetSprite().Y, (int)sprite[n].GetSize().X, (int)sprite[n].GetSize().Y);
                Vector2 origin = new Vector2(rect.Width / 2, rect.Height / 2);
                if (n == 1)
                {
                    //Console.WriteLine("X: " + posX + " | Y: " + posY);
                }
                batch.Draw(texture, new Vector2(posX, posY), rect, Color.White, (float)sprite[n].gameObject.rotation, origin, 1f, SpriteEffects.None, 0);
            }
            batch.End();
        }

        public static void SetWorldAndSpriteBatch(World newWorld, SpriteBatch newBatch)
        {
            batch = newBatch;
        }
    }
}
