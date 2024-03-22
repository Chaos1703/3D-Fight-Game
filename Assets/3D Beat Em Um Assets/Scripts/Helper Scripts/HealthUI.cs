using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour
{
   [SerializeField] private Image HealthBar;

   public void DisplayHealth(float health){
       if(health < 0){
           health = 0;
       }    

       health = health / 100f;
       HealthBar.fillAmount = health;
   }

}
