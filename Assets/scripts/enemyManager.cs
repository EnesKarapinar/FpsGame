using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    private Transform player;

    public int enemyHealth = 200;

    public LayerMask playerLayer;

    // 
    public float attackRange;
    public bool enemyAttackRange;

    // Atacking
    public float attackDelay;
    public bool isAttacking;
    private int damageAmount;


    private playerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerControllerScript = GetComponent<playerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if(geceGunduz.isNight == false){
            EnemyDeath();
        }
        if(enemyAttackRange){
            AttackPlayer();
        }else{
            takip();
        }
    }

    void AttackPlayer(){
        if(isAttacking == false){
            // Atak Turu
            //////////////

            isAttacking = true;
            Invoke("ResetAttack", attackDelay);
        }
    }

    void ResetAttack(){
        isAttacking = false;
    }

    public void EnemyTakeDamage(int DamageAmount){
        enemyHealth -= DamageAmount;
        if(enemyHealth <= 0)    EnemyDeath();
    }

    void EnemyDeath(){
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void takip(){
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
        transform.LookAt(player);
    }
}
