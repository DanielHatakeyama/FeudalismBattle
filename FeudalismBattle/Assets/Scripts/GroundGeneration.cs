using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundGeneration : MonoBehaviour
{


    [Header("Map Settings")]
    public Vector2 mapSize = new Vector2(50, 50);
    public int seed = 0; // Declare a seed variable

    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap waterTilemap;

    [Header("Ground Settings")]

    [SerializeField] private RuleTile waterRuleTile;
    [SerializeField] private Tile grassTile;

    [Header("Water Settings")]

    [Range(0, 1)]
    [SerializeField] private float noiseScale = 0.09f;
    [Range(0, 1)]
    [SerializeField] private float waterLevel = 0.4f;
    [SerializeField] private int octaves = 1; 
    [SerializeField] private float persistence = 1f; 
    [SerializeField] private float lacunarity = 2f;
    private float[,] noiseMap; // TODO make noise better implemented.

    // Start is called before the first frame update
    public void Start()
    {

        // Get children tilemaps
        groundTilemap = transform.Find("Ground").GetComponent<Tilemap>();
        waterTilemap  = transform.Find("Water").GetComponent<Tilemap>();

        Debug.Log(mapSize);

        // TODO Make grass geneartion not just grass but a bunch of different tiles that are populated based on height and temperature map. This could eventually be combined with the celular atonoma process to run a better terrain generation.

        // Set the entire background to grass, just for now
        for (int x = 0; x < mapSize.x; x++) {
            for (int y = 0; y < mapSize.y; y++) {
                groundTilemap.SetTile(new Vector3Int(x, y, 0), grassTile);
            }
        }

        // TODO Make noise generation for water much better and cooler looking, probably involve celular atonoma to grow water dynamically.

        // Note that it is limited at -1 temporarily so water does not generate outside the map. 
        // Later this would be nice to remove so we get water seamlessly leaving the edges of the map.

        for (int x = 0; x < mapSize.x-1; x++)
        {
            for (int y = 0; y < mapSize.y-1; y++)
            {
                float noiseValue = Mathf.PerlinNoise((x + 0.5f) * noiseScale, (y + 0.5f) * noiseScale);
                
                // float noiseValue = simplexNoise.cnoise(new float2(x * scale, y * scale));

                if (noiseValue < waterLevel)
                {
                    //Place a water rule tile in the top left corner of the 4x4 block
                    waterTilemap.SetTile(new Vector3Int(x, y, 0), waterRuleTile);

                    //Place a water rule tile in the top right corner of the 4x4 block
                    waterTilemap.SetTile(new Vector3Int(x + 1, y, 0), waterRuleTile);

                    //Place a water rule tile in the bottom left corner of the 4x4 block
                    waterTilemap.SetTile(new Vector3Int(x, y + 1, 0), waterRuleTile);

                    //Place a water rule tile in the bottom right corner of the 4x4 block
                    waterTilemap.SetTile(new Vector3Int(x + 1, y + 1, 0), waterRuleTile);
                }
            }
        }
    }

    // Update is called once per frame  
    public void Update()
    {

    }
}