using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabsSpawn;
    static public int indexX = 5;

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            CreateTerrain();
            InstantiateObject();
        }
    }
    
    void Update()
    {
        if (indexX < 5)
        {
            CreateTerrain();
            InstantiateObject();
            indexX++;
        }
    }

    float WorldPositionSpawn = 20;

    static int index = 0;

    void CreateTerrain()
    {
        // ������� ������ GameObject ��� ������ Terrain
        GameObject terrainObject = new GameObject("New Terrain" + index++);

        // ��������� ��������� Terrain
        Terrain terrain = terrainObject.AddComponent<Terrain>();

        terrain.terrainData = new TerrainData();

        // ��������� ��������� TerrainCollider
        TerrainCollider terrainCollider = terrainObject.AddComponent<TerrainCollider>();

        // ������ ������� Terrain
        terrain.terrainData.heightmapResolution = 512;
        terrain.terrainData.size = new Vector3(20, 1, 20);

        // ��������� �������� ������ (��������, ������� Terrain)
        float[,] heights = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        for (int x = 0; x < terrain.terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrain.terrainData.heightmapResolution; y++)
            {
                heights[x, y] = 0; // ������ ������ � 0, ����� ������� ������� Terrain
            }
        }
        terrain.terrainData.SetHeights(0, 0, heights);

        terrainCollider.terrainData = terrain.terrainData;

        InteractiveSnow interactiveSnow = terrainObject.AddComponent<InteractiveSnow>();

        Transform t = terrainObject.transform;
        t.position = new Vector3(WorldPositionSpawn, 0f, 0f);
        WorldPositionSpawn += 20f;
    }

    void InstantiateObject()
    {
        GameObject newObject = new GameObject();
        Transform t = newObject.transform;

        t.position = new Vector3(WorldPositionSpawn, 0f, 0f);
        GameObject obj = Instantiate(prefabsSpawn[Random.Range(0, prefabsSpawn.Length)], t);
    }
}
