using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    GameObject spawnObject;
    public GameObject[] spawnObjects;
    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnCharacter()
    {
        spawnPoint = new Vector3(123, 0, 86);
        if(GameManager.whichCharacterSelected){
            spawnObject = spawnObjects[1];
        }else{
            spawnObject = spawnObjects[0];
        }
        Instantiate(spawnObject, spawnPoint, Quaternion.identity);
    }
}
