using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundGeneration : MonoBehaviour
{

    [SerializeField] 
    private Vector2 mapSize;

    public Tilemap groundTilemap;
    public Tilemap waterTilemap;

    public RuleTile waterRuleTile;
    public Tile grassTile;

    public float noiseScale = 0.1f;


    // Start is called before the first frame update
    public void Start()
    {

        // Get children tilemaps
        groundTilemap = transform.Find("Ground").GetComponent<Tilemap>();
        waterTilemap  = transform.Find("Water").GetComponent<Tilemap>();

        Debug.Log(mapSize);

        // Set the entire background to grass, just for now
        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                groundTilemap.SetTile(new Vector3Int(x, y, 0), grassTile);
            }
        }

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                float noise = Mathf.PerlinNoise((x + 0.5f) * noiseScale, (y + 0.5f) * noiseScale);

                if (noise > 0.5f)
                {
                    waterTilemap.SetTile(new Vector3Int(x, y, 0), waterRuleTile);
                }
            }
        }

        // waterTilemap.SetTile(new Vector3Int(0, 0, 0), waterRuleTile);
        // waterTilemap.SetTile(new Vector3Int(1, 0, 0), waterRuleTile);
        // waterTilemap.SetTile(new Vector3Int(0, 1, 0), waterRuleTile);


        
        // mapHeight = mapSize.y;
        // mapWidth = mapSize.x;

        // Terrain perlin noise generation
        // for (int x = 0; x < mapWidth; x++) {
        //     for (int y = 0; y < mapHeight; y++) {

        //     }
        // }


        // Create a 2D array to store the terrain data
        // float[,] terrainData = new float[mapWidth, mapHeight];

        // Fill the terrainData array with random noise values
        // for (int x = 0; x < mapWidth; x++)
        // {
        //     for (int y = 0; y < mapHeight; y++)
        //     {
        //         terrainData[x, y] = Mathf.PerlinNoise((float)x / mapWidth * scale, (float)y / mapHeight * scale);
        //     }
        // }

        // // Iterate through the terrainData array and instantiate the appropriate tile
        // for (int x = 0; x < mapWidth; x++)
        // {
        //     for (int y = 0; y < mapHeight; y++)
        //     {
        //         // Set a threshold for water (e.g. 0.2)
        //         if (terrainData[x, y] < 0.2)
        //         {
        //             // Instantiate a water tile
        //             Instantiate(waterTile, new Vector3(x, y, 0), Quaternion.identity);
        //         }
        //         else
        //         {
        //             // Instantiate a grass tile
        //             Instantiate(grassTile, new Vector3(x, y, 0), Quaternion.identity);
        //         }
        //     }
        // }

    }

    // Update is called once per frame  
    public void Update()
    {

    }
}
