using GameLIB.Scripts.GameComponents;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using GameLIB.Scripts.Interface;
using GameLIB.Scripts.System;

namespace GameLIB.Scripts.GameComponents.Graphics
{
    public class Sprite : ObjectComponent
    {
        private Vector2 rect;
        private Vector2 rectSize;
        private Vector2 positionInInterface;

        private int offsetX;
        private int offsetY;

        private int layer = 0;

        public Sprite(Object newGameObject) : base(newGameObject)
        {
            SpriteSystem.Register(this);
        }

        public override void Update()
        {
            positionInInterface = new Vector2(gameObject.transform.position.X - GameManager.GMInstance.world.camera.GetCameraPosition().X, gameObject.transform.position.Y - GameManager.GMInstance.world.camera.GetCameraPosition().Y);
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
            return positionInInterface;
        }

        public int GetLayer()
        {
            return layer;
        }

        public override void DeleteComponent()
        {
            SpriteSystem.Unregister(this);
        }
    }
}
