using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skeleton1;
    [SerializeField]
    private GameObject skeleton2;

    [SerializeField]
    private float skeleton1Interval = 1f;
    [SerializeField]
    private float skeleton2Interval = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(skeleton1Interval, skeleton1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(10, 180), 0, Random.Range(10, 180)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy)); 
        Debug.Log("Oluyo");
    }
}
