using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 10f;
    [SerializeField] List<BoxCollider> boxColliders = new List<BoxCollider>();
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        ResetSpawnTIemr();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer<= 0)
        {
            spawnCoin();
            ResetSpawnTIemr() ;
        }
    }
    void ResetSpawnTIemr()
    {
        spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void spawnCoin()
    {
        BoxCollider sspawnZone = boxColliders[Random.Range(0,boxColliders.Count)];

        Bounds bounds = sspawnZone.bounds;

        float x = Random.Range(bounds.min.x,bounds.max.x);
        float z = Random.Range(bounds.min.z,bounds.max.z);

        Vector3 spawnPos = new Vector3(x,0f,z);
        Instantiate(CoinPrefab,spawnPos,Quaternion.identity);
    }
}
