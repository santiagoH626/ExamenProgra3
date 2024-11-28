using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawner;
    public float spawnDelay;
    public float spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount <= 0f)
        {
            GameObject o = Instantiate(prefab);
            o.transform.position = spawner.position;

            spawnCount = spawnDelay;
            transform.eulerAngles = new Vector3(0f, Random.Range(-360f, 360f), 0f);
        }
        spawnCount -= Time.deltaTime;
    }
}
