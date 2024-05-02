//This script keeps track of the player's health. It is also used to communicate with the GameManager

using UnityEngine;
//using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Animator animator;					//Reference to the animator component


    //This method is called by an event in the Death animation on the player
    void DeathComplete ()
    {
        //If this player is the registered player of the GameManager, tell the GameManager that this player
        //has finished its death animation
        if(GameManager.Instance.Player == this)
            GameManager.Instance.PlayerDeathComplete();
    }
}
