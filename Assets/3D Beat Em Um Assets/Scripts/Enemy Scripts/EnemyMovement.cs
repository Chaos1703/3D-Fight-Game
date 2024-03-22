using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimations enemyAnim;
    private Rigidbody rb;
    private float speed = 1.8f , attackDistance = 1.3f;
    private Transform playerTarget;
    private float chasePlayerAfterAttack = 0.2f , currentAttackTime , defaultAttackTime = 1.2f;
    private bool followPlayer , attackPlayer;

    void Awake(){
        enemyAnim = GetComponentInChildren<CharacterAnimations>();
        rb = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    void Update()
    {
        AttackPlayer();
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer(){
        if(!followPlayer){
            return;
        }
        if(Vector3.Distance(transform.position , playerTarget.position) > attackDistance){
            transform.LookAt(playerTarget);
            rb.velocity = transform.forward * speed;
            if(rb.velocity != Vector3.zero){
                enemyAnim.Walk(true);
            }
        }else if(Vector3.Distance(transform.position , playerTarget.position) <= attackDistance){
            rb.velocity = Vector3.zero;
            enemyAnim.Walk(false);
            followPlayer = false;
            attackPlayer = true;
        }
    }

    void AttackPlayer(){
        if(!attackPlayer){
            return;
        }
        currentAttackTime += Time.deltaTime;
        if(currentAttackTime > defaultAttackTime){
            enemyAnim.enemyAttack(Random.Range(0,3));
            currentAttackTime = 0f;
        }
        if(Vector3.Distance(transform.position , playerTarget.position) > attackDistance + chasePlayerAfterAttack){
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
