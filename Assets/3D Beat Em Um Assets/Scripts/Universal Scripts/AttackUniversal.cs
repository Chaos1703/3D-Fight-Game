using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 10f;
    public bool isPlayer, isEnemy;
    public GameObject hitFx;

    void Update()
    {
        detectCollision();
    }
    void detectCollision(){
        Collider[] hit = Physics.OverlapSphere(transform.position , radius , collisionLayer);
        if(hit.Length > 0){
            if(isPlayer){
                Vector3 hitFxPos = hit[0].transform.position;
                hitFxPos.y += 1.3f;
                if(hit[0].transform.forward.x > 0)
                    hitFxPos.x += 0.3f;
                else if(hit[0].transform.forward.x < 0){
                    hitFxPos.x -= 0.3f;
                }
                Instantiate(hitFx, hitFxPos, Quaternion.identity);
                if(gameObject.CompareTag("LeftArm") || gameObject.CompareTag("LeftLeg")){
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage , true);
                }
                else{
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage , false);
                }
            }
            if(isEnemy){
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage , false);
            }
            gameObject.SetActive(false);
        }
    }

}
