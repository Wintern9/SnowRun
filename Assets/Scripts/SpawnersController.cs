using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    [SerializeField] private TerrainData terrainData;
    void Start()
    {
        InvokeRepeating("CreateTerrain", 1f, 1f);
    }

    float WorldPositionSpawn = 0;

    void CreateTerrain()
    {
        // ������� ������ GameObject ��� ������ Terrain
        GameObject terrainObject = new GameObject("New Terrain");

        // ��������� ��������� Terrain
        Terrain terrain = terrainObject.AddComponent<Terrain>();

        // ��������� ��������� TerrainCollider
        TerrainCollider terrainCollider = terrainObject.AddComponent<TerrainCollider>();

        // ������ ������� Terrain
        terrainData.heightmapResolution = 512;
        terrainData.size = new Vector3(20, 1, 20);

        // ��������� �������� ������ (��������, ������� Terrain)
        float[,] heights = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        for (int x = 0; x < terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                heights[x, y] = 0; // ������ ������ � 0, ����� ������� ������� Terrain
            }
        }
        terrainData.SetHeights(0, 0, heights);

        // ����������� ��������� TerrainData ����������� Terrain � TerrainCollider
        terrain.terrainData = terrainData;
        terrainCollider.terrainData = terrainData;

        InteractiveSnow interactiveSnow = terrainObject.AddComponent<InteractiveSnow>();

        Transform t = terrainObject.transform;
        t.position = new Vector3(WorldPositionSpawn, 0f, 0f);
        WorldPositionSpawn += 20f;
    }
}
