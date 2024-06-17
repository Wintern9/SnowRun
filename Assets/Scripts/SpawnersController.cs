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
        // Создаем объект GameObject для нового Terrain
        GameObject terrainObject = new GameObject("New Terrain");

        // Добавляем компонент Terrain
        Terrain terrain = terrainObject.AddComponent<Terrain>();

        // Добавляем компонент TerrainCollider
        TerrainCollider terrainCollider = terrainObject.AddComponent<TerrainCollider>();

        // Задаем размеры Terrain
        terrainData.heightmapResolution = 512;
        terrainData.size = new Vector3(20, 1, 20);

        // Заполняем высотные данные (например, плоский Terrain)
        float[,] heights = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
        for (int x = 0; x < terrainData.heightmapResolution; x++)
        {
            for (int y = 0; y < terrainData.heightmapResolution; y++)
            {
                heights[x, y] = 0; // Задаем высоту в 0, чтобы создать плоский Terrain
            }
        }
        terrainData.SetHeights(0, 0, heights);

        // Присваиваем созданные TerrainData компонентам Terrain и TerrainCollider
        terrain.terrainData = terrainData;
        terrainCollider.terrainData = terrainData;

        InteractiveSnow interactiveSnow = terrainObject.AddComponent<InteractiveSnow>();

        Transform t = terrainObject.transform;
        t.position = new Vector3(WorldPositionSpawn, 0f, 0f);
        WorldPositionSpawn += 20f;
    }
}
