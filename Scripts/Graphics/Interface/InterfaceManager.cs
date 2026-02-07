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

        static List<Sprite> sprites = new List<Sprite>();

        public static void InsertSprite(Sprite newSprite)
        {

            if (sprites.Count == 0)
            {
                sprites.Add(newSprite);
            }

            else
            {
                int n = 1;
                int newSpriteLayer = newSprite.GetLayer();

                if (sprites[0].GetLayer() > newSpriteLayer)
                {
                    sprites.Insert(0, newSprite);
                }

                else
                {
                    while (n < sprites.Count && newSpriteLayer > sprites[n].GetLayer())
                    {
                        n++;
                    }

                    if (n == sprites.Count)
                    {
                        sprites.Add(newSprite);
                    }

                    else
                    {
                        sprites.Insert(n, newSprite);
                    }
                }
            }
        }

        public static void RemoveSprite(Sprite oldSprite)
        {
            Console.WriteLine("Total: " + sprites.Count);
            sprites.Remove(oldSprite);
        }

        public static void DrawElements(Texture2D texture)
        {
            float posX;
            float posY;
            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            for (int n = 0; n < sprites.Count; n++)
            {
                posX = (sprites[n].gameObject.GetPosition().X - sprites[n].GetSize().X / 2) - GameManager.GMInstance.world.camera.GetX() + GameManager.GMInstance.world.camera.offsetX;
                posY = (sprites[n].gameObject.GetPosition().Y - sprites[n].GetSize().Y / 2) - GameManager.GMInstance.world.camera.GetY() + GameManager.GMInstance.world.camera.offsetY;
                Rectangle rect = new Rectangle((int)sprites[n].GetSprite().X, (int)sprites[n].GetSprite().Y, (int)sprites[n].GetSize().X, (int)sprites[n].GetSize().Y);
                Vector2 origin = new Vector2(rect.Width / 2, rect.Height / 2);
                if (n == 1)
                {
                    //Console.WriteLine("X: " + posX + " | Y: " + posY);
                }
                batch.Draw(texture, new Vector2(posX, posY), rect, Color.White, (float)sprites[n].gameObject.rotation, origin, 1f, SpriteEffects.None, 0);
            }
            batch.End();
        }

        public static void SetWorldAndSpriteBatch(World newWorld, SpriteBatch newBatch)
        {
            batch = newBatch;
        }
    }
}
