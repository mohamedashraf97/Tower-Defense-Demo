using System.Collections;
using UnityEngine;
using UnityEngine.UI ;
public class WaveSpawner : MonoBehaviour
{

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.5f;
    private float countDown = 2f;
	public Text WaveCountDownText ;
    private int waveIndex = 0;
    void Update()
    {

        if (countDown <= 0f)
        {

            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;

        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f ,Mathf.Infinity);
		WaveCountDownText.text = string.Format("(0:00.00)",countDown);

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);

        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
