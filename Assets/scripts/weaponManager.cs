using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{

    public int minDamage, maxDamage;
    public Camera playerCamera;
    public float range = 300f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private enemyManager enemyManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.timeScale > 0)
        {
            Fire();
            muzzleFlash.Play();
        }
    }

    void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            enemyManagerScript = hit.transform.GetComponent<enemyManager>();
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            if(enemyManagerScript !=null)
            {
                enemyManagerScript.EnemyTakeDamage(Random.Range(minDamage, maxDamage));
            }
        }
    }
}
