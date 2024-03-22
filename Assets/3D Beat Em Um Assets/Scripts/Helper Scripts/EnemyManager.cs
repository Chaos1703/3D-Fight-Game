using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   public static EnemyManager instance;
   [SerializeField] private GameObject Enemy;

   void Awake()
   {
        MakeInstance();
   }

   void Start()
   {
        SpawnEnemy();
   }

    void MakeInstance()
    {
         if(instance == null)
         {
              instance = this;
         }
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
