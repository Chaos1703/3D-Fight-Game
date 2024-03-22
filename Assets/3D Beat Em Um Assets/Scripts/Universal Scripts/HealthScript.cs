using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimations characterAnimations;
    private EnemyMovement enemyMovement;    
    private bool characterDied;
    public bool isPlayer;
    private HealthUI healthUI;

    void Awake()
    {
        characterAnimations = GetComponentInChildren<CharacterAnimations>();
        if(isPlayer)
            healthUI = GetComponent<HealthUI>();
    }

    public void ApplyDamage(float damage , bool knockDown){
        if(characterDied){
            return;
        }
        health -= damage;
        if(isPlayer){
            healthUI.DisplayHealth(health);
        }
        if(health <= 0){
            characterAnimations.Death();
            characterDied = true;
            if(isPlayer){
                DisableEnemyAfterPlayerDies();
                gameObject.GetComponentInChildren<CharacterAnimationDelegate>().CharacterDiedSound();
            }
            return;
        }
        if(!isPlayer){
            if(knockDown){
                Random.Range(0, 2);
                if(Random.Range(0, 2) > 0){
                    characterAnimations.KnockDown();
                }
                else{
                    if(Random.Range(0 , 3) > 0)
                    characterAnimations.Hit();
                }
            }
            else{
                characterAnimations.Hit();
            }
        }
    }
    
    void DisableEnemyAfterPlayerDies(){
    int enemyLayer = LayerMask.NameToLayer("EnemyLayer"); 
    foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
        if (enemy.layer == enemyLayer) {
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null) {
                enemyMovement.enabled = false;
            }
        }
    }       
    }
}
