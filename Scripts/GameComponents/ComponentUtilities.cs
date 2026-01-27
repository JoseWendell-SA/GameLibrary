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

            gameObject.AddComponent<Sprite>(gameObject);
            Sprite sprite = gameObject.GetComponent<Sprite>();
            sprite.SetSprite(posX, posY);
            sprite.SetSize(sizeX, sizeY);
            sprite.SetLayer(layer);

            InterfaceManager.InsertSprite(sprite);
        }

        public static void AddTileCollider(Object tile, int sizeX, int sizeY)
        {
            tile.AddComponent<BoxCollider>(tile);
            tile.GetComponent<BoxCollider>().SetBoxSize(new Vector2(sizeX, sizeY));
        }

        public static void InsertTexture(Texture2D newTexture)
        {
            texture = newTexture;
        }
    }
}
