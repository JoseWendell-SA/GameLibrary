using GameLIB.Scripts.GameComponents.Graphics;
using GameLIB.Scripts.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace GameLIB.Scripts.Interface
{
    public static class InterfaceManager
    {
        static SpriteBatch batch;
        static SpriteFont spriteFont;

        public static void DrawElements(Texture2D texture)
        {
            List<Sprite> sprites = SpriteSystem.GetSpriteList();
            Vector2 pos;

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

                    pos = sprites[n].GetSpritePositionInInterface();

                    Vector2 spriteRect = sprites[n].GetRect();
                    Vector2 spriteRectSize = sprites[n].GetRectSize();

                    Rectangle rect = new Rectangle((int)spriteRect.X, (int)spriteRect.Y, (int)spriteRectSize.X, (int)spriteRectSize.Y);
                    Vector2 origin = new Vector2(rect.Width / 2, rect.Height / 2);
                    if (n == 1)
                    {
                        //Console.WriteLine("X: " + posX + " | Y: " + posY);
                    }
                    batch.Draw(texture, new Vector2(pos.X, pos.Y), rect, Color.White, (float)sprites[n].gameObject.rotation, origin, 1f, SpriteEffects.None, 0);
                }
            }

            else if (GameManager.GMInstance.gameLevel == 2)
            {
                batch.DrawString(spriteFont, "You Died!\nFinal Score: " + GameManager.GMInstance.score + "\nPress \"Esc\" to continue", new Vector2(120, 110), Color.White, 0, Vector2.One, 0.3f, SpriteEffects.None, 1);
            }

            else if (GameManager.GMInstance.gameLevel == 3)
            {
                char[] name = GameManager.GMInstance.name;
                String text = ("Name: " + name[0] + name[1] + name[2]);
                batch.DrawString(spriteFont, (text + "\nScore: " + GameManager.GMInstance.score), new Vector2(120, 110), Color.White, 0, Vector2.One, 0.3f, SpriteEffects.None, 1);
            }

            else if (GameManager.GMInstance.gameLevel == 4)
            {
                List<FinalScore> scores = GameManager.GMInstance.GetAllScores();
                for (int n = 0; n < scores.Count; n++)
                {
                    batch.DrawString(spriteFont, (scores[n].name + scores[n].score.ToString()), new Vector2(110, 0 + (12 * n)), Color.White, 0, Vector2.One, 0.3f, SpriteEffects.None, 1);
                }
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
