using Joguinho.Scripts.Graphics;
using System;
using System.Collections.Generic;
using Joguinho.Scripts.GameComponents.Physics.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Joguinho.Scripts.Graphics.Interface;
using Joguinho.Scripts.GameComponents;
using Joguinho.Scripts.GameComponents.Physics;

namespace Joguinho.Scripts
{
    public class World
    {
        public static World worldInstance;

        public List<List<Tile>> map = new List<List<Tile>>();

        public int[][] testMap = new int[][]
        {
            new int[]{8, 8, 8, 8, 8, 8, 8, 8, 8},
            new int[]{8, 1, 1, 1, 2, 3, 1, 1, 8},
            new int[]{8, 1, 2, 2, 2, 3, 2, 1, 8},
            new int[]{8, 1, 3, 1, 1, 1, 12, 13, 8},
            new int[]{8, 2, 1, 3, 3, 2, 18, 19, 8},
            new int[]{8, 12, 13, 3, 1, 1, 1, 4, 8},
            new int[]{8, 8, 8, 8, 8, 8, 8, 8, 8}
        };
        public int[][] testMapCol = new int[][]
        {
            new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1},
            new int[]{1, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[]{1, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[]{1, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[]{1, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[]{1, 0, 0, 0, 0, 0, 0, 0, 1},
            new int[]{1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        public List<Entity> entities = new List<Entity>();
        public List<Projectile> projectiles = new List<Projectile>();

        public readonly Camera camera;

        public World(Camera newCamera, Player player)
        {
            camera = newCamera;
            camera.DefineTarget(player);
            entities.Add(player);
            entities[0].UpdatePosition(new Vector2(17, 17));

            entities[0].AddComponent<BoxCollider>();
            entities[0].GetComponent<BoxCollider>().SetNewBoxSize(new Vector2(16, 16));

            worldInstance = this;
        }

        public void Update()
        {
            for (int n = 0; n < entities.Count ; n++)
            {
                entities[n].Update();
            }

            for (int n = 0; n < projectiles.Count ; n++)
            {
                projectiles[n].Update();
            }
        }

        public bool AABBvsAABB(BoxCollider a, BoxCollider b)
        {
            if (a.max.X < b.min.X || a.min.X > b.max.X)
                return false;
            else if (a.max.Y < b.min.Y || a.min.Y > b.max.Y)
                return false;

            return true;
        }

        public bool CirclevsCircle(CircleCollider a, CircleCollider b)
        {
            float r = a.radius + b.radius;
            r *= r;
            float ca = (a.position.X + b.position.X);
            ca = ca * ca;
            float cb = (a.position.Y + b.position.Y);
            cb = cb * cb;

            return r < ca + cb;
        }

        public void InsertObject()
        {
            ComponentUtilities.AddSprite(entities[0], 35, 16, 16, 1);

            for (int y = 0; y < testMap.Length; y++)
            {
                map.Add(new List<Tile>());
                for (int x = 0; x < testMap[y].Length; x++)
                {
                    map[y].Add(new Tile(new Vector2(x*16, y*16)));
                    ComponentUtilities.AddSprite(map[y][x], testMap[y][x], 16, 16, 0);

                    if (testMapCol[y][x] == 1)
                    {
                        ComponentUtilities.AddTileCollider(map[y][x], 14, 14);
                    }
                }
            }
        }
    }
}
