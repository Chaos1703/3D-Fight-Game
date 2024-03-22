using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftArmAttackPoint, rightArmAttackPoint, leftLegAttackPoint, rightLegAttackPoint;
    public float standUpTimer = 2f; 
    private CharacterAnimations animationScript;
    private AudioSource audioSource;
    [SerializeField] private AudioClip wooshSound , fallSound , groundHitSound , deadSound;
    private EnemyMovement enemyMovement;
    private ShakeCamera shakeCamera;



    void Awake()
    {
        animationScript = GetComponent<CharacterAnimations>();
        audioSource = GetComponent<AudioSource>();
        if(gameObject.CompareTag("Enemy"))
        {
            enemyMovement = GetComponentInParent<EnemyMovement>();
        }
        shakeCamera = GameObject.FindWithTag("MainCamera").GetComponent<ShakeCamera>();

    }

    void LeftArmAttackOn()
    {
        leftArmAttackPoint.SetActive(true);
    }

    void LeftArmAttackOff()
    {
        if (leftArmAttackPoint.activeInHierarchy)
        {
            leftArmAttackPoint.SetActive(false);
        }
    }

    void RightArmAttackOn()
    {
        rightArmAttackPoint.SetActive(true);
    }

    void RightArmAttackOff()
    {
        if (rightArmAttackPoint.activeInHierarchy)
        {
            rightArmAttackPoint.SetActive(false);
        }
    }

    void LeftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }

    void LeftLegAttackOff()
    {
        if (leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }

    void RightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }

    void RightLegAttackOff()
    {
        if (rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }

    void TagLeftArm()
    {
        leftArmAttackPoint.tag = "LeftArm";
    }

    void UntagLeftArm()
    {
        leftArmAttackPoint.tag = "Untagged";
    }

    void TagLeftLeg()
    {
        leftLegAttackPoint.tag = "LeftLeg";
    }

    void UntagLeftLeg()
    {
        leftLegAttackPoint.tag = "Untagged";
    }

    void EnemyStandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(standUpTimer);
        animationScript.StandUp();
    }

    public void AttackFxSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = wooshSound;
        audioSource.Play();
    }

    public void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }

    public void EnemyKnockDown()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    public void EnemyHitGround()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    public void DisableMovement()
    {
        enemyMovement.enabled = false;  
        transform.parent.gameObject.layer = 0;
    }

    public void EnableMovement()
    {
        enemyMovement.enabled = true;
        transform.parent.gameObject.layer = 7;
    }

    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }
    void characterDied(){
        Invoke("TurnOffGameObject", 2f);
    }

    void TurnOffGameObject(){
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }

}
