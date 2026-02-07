using Joguinho.Scripts.GameComponents.Physics.Collision;
using Joguinho.Scripts.Graphics;
using Joguinho.Scripts.Graphics.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Joguinho.Scripts.GameComponents
{
    public static class ComponentUtilities
    {
        static Texture2D texture;

        public static void AddSprite(Object gameObject, int spriteID, int sizeX, int sizeY, int layer)
        {
            int posX = (spriteID % (texture.Width / sizeX)) * sizeX;
            int posY = (spriteID / (texture.Width / sizeX)) * sizeY;

            gameObject.AddComponent<Sprite>();
            Sprite sprite = gameObject.GetComponent<Sprite>();
            sprite.SetSprite(posX, posY);
            sprite.SetSize(sizeX, sizeY);
            sprite.SetLayer(layer);

            InterfaceManager.InsertSprite(sprite);
        }

        public static void AddBoxCollider(Object gameObject, int sizeX, int sizeY)
        {
            gameObject.AddComponent<BoxCollider>();
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();

            GameManager.GMInstance.InsertNewBoxCollider(boxCollider);
        }

        public static void AddTileCollider(Object tile, int sizeX, int sizeY)
        {
            tile.AddComponent<BoxCollider>();
            BoxCollider boxCollider = tile.GetComponent<BoxCollider>();
            boxCollider.SetNewBoxSize(new Vector2(sizeX, sizeY));

            GameManager.GMInstance.InsertNewBoxCollider(tile.GetComponent<BoxCollider>());
        }

        public static void InsertTexture(Texture2D newTexture)
        {
            texture = newTexture;
        }
    }
}
