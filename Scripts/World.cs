using GameLIB.Scripts.GameComponents.Graphics;
using System;
using System.Collections.Generic;
using GameLIB.Scripts.GameComponents.Physics.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameLIB.Scripts.Interface;
using GameLIB.Scripts.GameComponents;
using GameLIB.Scripts.GameComponents.Physics;

//Test, delete later
using GameLIB.Scripts.Entities;

namespace GameLIB.Scripts
{
    public class World
    {
        public List<List<Tile>> map = new List<List<Tile>>();

        /*public int[][] testMap = new int[][]
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
        };*/

        public readonly Camera camera;

        public World(Camera newCamera, Player player)
        {
            camera = newCamera;
            camera.DefineTarget(player);
        }

        public void Update()
        {
            
        }

        public void InsertObject()
        {
            /*for (int y = 0; y < testMap.Length; y++)
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
            }*/
        }
    }
}
