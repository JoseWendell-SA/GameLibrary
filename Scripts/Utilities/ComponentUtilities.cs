using GameLIB.Scripts.GameComponents.Graphics;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using GameLIB.Scripts.Interface;
using GameLIB.Scripts.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameLIB.Scripts.Utilities
{
    public static class ComponentUtilities
    {
        internal static Texture2D texture;

        public static void AddSprite(GameObject gameObject, int spriteID, int sizeX, int sizeY, int layer)
        {
            int posX = (spriteID % (texture.Width / sizeX)) * sizeX;
            int posY = (spriteID / (texture.Width / sizeX)) * sizeY;

            Sprite sprite = gameObject.AddComponent<Sprite>();
            sprite.SetSprite(posX, posY);
            sprite.SetSize(sizeX, sizeY);
            sprite.SetLayer(layer);
        }

        public static void AddBoxCollider(GameObject gameObject, int sizeX, int sizeY, List<CollisionTag> collisionTags)
        {
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();

            try
            {
                boxCollider.SetNewBoxSize(new Vector2(sizeX, sizeY));
                boxCollider.SetNewCollisionTag(collisionTags);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception after adding Box Collider: " + e);
            }
        }

        public static void AddTileCollider(GameObject tile, int sizeX, int sizeY)
        {
            BoxCollider boxCollider = tile.AddComponent<BoxCollider>();
            boxCollider.SetNewBoxSize(new Vector2(sizeX, sizeY));

            List<CollisionTag> collisionTag = [CollisionTag.Terrain];
            boxCollider.SetNewCollisionTag(collisionTag);
        }
    }
}
