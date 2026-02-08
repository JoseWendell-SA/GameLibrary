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
        static SpriteFont spriteFont;

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

                if (!sprites.Contains(newSprite))
                {
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
        }

        public static void RemoveSprite(Sprite oldSprite)
        {
            sprites.Remove(oldSprite);
            Console.WriteLine("Total: " + sprites.Count);
        }

        public static void DrawElements(Texture2D texture)
        {
            float posX;
            float posY;

            batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if (GameManager.GMInstance.gameLevel == 0)
            {
                batch.DrawString(spriteFont, "Press \"L\" to start", new Vector2(120, 110), Color.White, 0, Vector2.One, 0.3f, SpriteEffects.None, 1);
            }

            else if (GameManager.GMInstance.gameLevel == 1)
            {
                for (int n = 0; n < sprites.Count; n++)
                {
                    batch.DrawString(spriteFont, ("Score: " + GameManager.GMInstance.score.ToString()), new Vector2(0, 0), Color.White, 0, Vector2.One, 0.3f, SpriteEffects.None, 1);

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
            }

            else if (GameManager.GMInstance.gameLevel == 2)
            {
                batch.DrawString(spriteFont, "You Died! Press \"L\" to continue", new Vector2(120, 110), Color.White, 0, Vector2.One, 0.3f, SpriteEffects.None, 1);
            }
            
            batch.End();
        }

        public static void SetWorldAndSpriteBatch(SpriteBatch newBatch, SpriteFont newFont)
        {
            batch = newBatch;
            spriteFont = newFont;
        }
    }
}
