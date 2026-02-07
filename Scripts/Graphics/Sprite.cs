using Joguinho.Scripts.GameComponents;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Joguinho.Scripts.Graphics.Interface;

namespace Joguinho.Scripts.Graphics
{
    public class Sprite : ObjectComponent
    {
        private Vector2 sprite;
        private Vector2 size;

        private int layer = 0;

        public Sprite(Object newGameObject) : base(newGameObject)
        {

        }

        public void SetSprite(int spX, int spY)
        {
            sprite.X = spX;
            sprite.Y = spY;
        }

        public void SetSize(int ssX, int ssY)
        {
            size.X = ssX;
            size.Y = ssY;
        }

        public void SetLayer(int newLayer)
        {
            if (newLayer >= 0)
                layer = newLayer;
        }

        public Vector2 GetSprite()
        {
            return sprite;
        }

        public Vector2 GetSize()
        {
            return size;
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
