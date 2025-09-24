using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] float timeToSpawn = 0.3f;
    [SerializeField] float timeTOWave = 3f;

    [SerializeField] int waveNumer = 1;

    private void Start()
    {
        StartCoroutine(WaveSpawn());   
    }
    IEnumerator WaveSpawn()
    {
        while (true)
        {
            waveNumer++;
            //int enemyCount = waveNumer * 3;
            int enemyCount = 5 + (waveNumer / 3);
            for (int i = 0; i < enemyCount; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].transform;
                GameObject enm =  Instantiate(enemyPrefab,spawnPoint.position,Quaternion.identity);
                if(spawnPoint.name == "right")
                {
                    enm.GetComponent<EnemyAi>().isleft = false;
                }
                else
                {
                    enm.GetComponent<EnemyAi>().isleft=true;
                }
                yield return new WaitForSeconds(timeToSpawn);
            }
            yield return new WaitForSeconds(timeTOWave);
        }
    }
}
