using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]private GameObject[] prefabsSpawn;

    float WorldPositionSpawn = 0;

    void Start()
    {
        InvokeRepeating("SpawnObject", 5f, 1f);
        FirstLoaded();
    }

    void FirstLoaded()
    {
        for(int i = 0; i < 10; i++)
        {
            InstantiateObject();
        }
    }    

    void SpawnObject()
    {
        InstantiateObject();
    }

    int index = 0;

    void InstantiateObject()
    {
        GameObject newObject = new GameObject();
        Transform t = newObject.transform;

        t.position = new Vector3(WorldPositionSpawn, 0f, 0f);
        WorldPositionSpawn += 20f;
        GameObject obj = Instantiate(prefabsSpawn[Random.Range(0, prefabsSpawn.Length)], t);
        obj.name = obj.name + index++;
    }
}
