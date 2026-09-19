using GameLIB.Scripts.GameComponents;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GameLIB.Scripts.Interface;

namespace GameLIB.Scripts.GameComponents.Graphics
{
    public class Sprite : ObjectComponent
    {
        private Vector2 rect;
        private Vector2 rectSize;

        private int offsetX;
        private int offsetY;

        private int layer = 0;

        public Sprite(Object newGameObject) : base(newGameObject)
        {

        }

        public void SetSprite(int spX, int spY)
        {
            rect.X = spX;
            rect.Y = spY;
        }

        public void SetSize(int ssX, int ssY)
        {
            rectSize.X = ssX;
            rectSize.Y = ssY;

            offsetX = -ssX / 2;
            offsetY = -ssY / 2;
        }

        public Vector2 GetRect()
        {
            return rect;
        }

        public Vector2 GetRectSize()
        {
            return rectSize;
        }

        public void SetLayer(int newLayer)
        {
            if (newLayer >= 0)
                layer = newLayer;
        }

        public Vector2 GetSpritePositionInInterface()
        {
            return new Vector2(gameObject.transform.position.X, gameObject.transform.position.Y);
        }

        public int GetLayer()
        {
            return layer;
        }

        public override void DeleteComponent()
        {
            InterfaceManager.RemoveSprite(this);
        }
    }
}
