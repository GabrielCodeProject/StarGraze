using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class Room : MonoBehaviour
{
    public Tilemap tilemap;
    Dictionary<RequireListTool, TileBase> tbDict;
    BoundsInt bounds;

    public Dictionary<Vector2Int, Tiles> tiles;


    public void init()
    {
        tiles = new Dictionary<Vector2Int, Tiles>();
        tilemap = GetComponent<Tilemap>();
        tiles = new Dictionary<Vector2Int, Tiles>();

        bounds = tilemap.cellBounds;

        Vector2Int v = new Vector2Int();
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                v.x = bounds.xMin + x;
                v.y = bounds.yMin + y;
                TileBase tile = tilemap.GetTile((Vector3Int)v);

                if (tile != null)
                {
                    Tiles t = new Tiles();
                    t.init(tile, this, v);
                    tiles.Add(v,t);
                }
                else
                {
                }
            }
        }

        //tbDict.Add(RequireListTool.Hammer, Resources.Load<TileBase>("Tiles/Room_Tiles/floorTiles_crop_0"));
       // wrenchTB = Resources.Load<TileBase>("Tiles/Room_Tiles/floorTiles_crop_0");
       // extinTB = Resources.Load<TileBase>("Tiles/Room_Tiles/floorTiles_crop_0");
       // welderTB = Resources.Load<TileBase>("Tiles/Room_Tiles/floorTiles_crop_0");
    }

    public void destroyRoom()
    {

        int RoomsDestroyed = Random.Range(1,5);
        

        for (int i = 0; i < RoomsDestroyed; i++)
        {
            if (tiles.Keys.Count > 0)
            {
                SpaceShipManager.Instance.krina.AddOxygeneLost();

                Vector2Int v2 = tiles.Keys.ToList()[RandomTile(tiles.Count - 1)];
                tiles[v2].damageTile();
                TileBase tb = Resources.Load<TileBase>("Tiles/tool_tiles/Tile_" + tiles[v2].repairList[0]);
                
                tilemap.SetTile((Vector3Int)v2, tb);
                tilemap.RefreshTile((Vector3Int)v2);
              
            }
        }
        SoundManager.PlaySound(SoundManager.EnumSound.spaceHit);
    }

    int RandomTile(int bound)
    {
        return (int)Random.Range(0, bound);
    }
}
