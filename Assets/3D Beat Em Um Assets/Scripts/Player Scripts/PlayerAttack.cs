using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState {None , Punch1, Punch2, Punch3, Kick1, Kick2};
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimations playerAnimations;
    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;
    private ComboState currentComboState;

    void Awake(){
        playerAnimations = GetComponentInChildren<CharacterAnimations>();
    }

    void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.None;
    }

    void Update(){
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks(){
        if(Input.GetKeyDown(KeyCode.Z)){
            if(currentComboState == ComboState.Punch3 || currentComboState == ComboState.Kick1 || currentComboState == ComboState.Kick2){
                return;
            }
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if(currentComboState == ComboState.Punch1){
                playerAnimations.Punch1();
            }
            if(currentComboState == ComboState.Punch2){
                playerAnimations.Punch2();
            }
            if(currentComboState == ComboState.Punch3){
                playerAnimations.Punch3();
            }
        }
        if(Input.GetKeyDown(KeyCode.X)){
            if(currentComboState == ComboState.Kick2 || currentComboState == ComboState.Punch3){
                return;
            }
            if(currentComboState == ComboState.None || currentComboState == ComboState.Punch1 || currentComboState == ComboState.Punch2){
                currentComboState = ComboState.Kick1;
            }else if(currentComboState == ComboState.Kick1){
                currentComboState++;
            }
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if(currentComboState == ComboState.Kick1){
                playerAnimations.Kick1();
            }
            if(currentComboState == ComboState.Kick2){
                playerAnimations.Kick2();
            }
        }
    }

    void ResetComboState(){
        if(activateTimerToReset){
            currentComboTimer -= Time.deltaTime;
            if(currentComboTimer <= 0f){
                currentComboState = ComboState.None;
                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
