//This script handles the lightning attack. The lightning attack is an instant line attack that does a moderate
//amount of damage with a small cooldown.

using UnityEngine;

public class PrototypeAttack : MonoBehaviour
{
    [Header("Weapon Specs")]
    public float Cooldown = 1f;						//The cooldown of the attach

    [SerializeField] int damage = 20; 				//How much damage the attack does
    [SerializeField] float range = 20.0f;			//How far the attack can shoot
    [SerializeField] LayerMask strikeableMask; 		//Layermask that determines what the attack can hit
    //[SerializeField] bool debugRay;               //Enables Debug Line Draw is Gizmos in on in Game window.


    //Called from PlayerAttack script
    public void Fire()
    {
        //Create a ray from the current position and extending straight forward
        Ray ray = new Ray(transform.position, transform.forward);
        //Create a RaycastHit variable which will store information about the raycast
        RaycastHit hit;

        //If our raycast hits something...
        if (Physics.Raycast(ray, out hit, range, strikeableMask))
        {
            //...then try to get a reference to an EnemyHealth script...
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            //...if the script exists...
            if (enemyHealth != null)
            {	
                //...tell the enemy to take damage
                enemyHealth.TakeDamage(damage);
            }
        }

        /* If debugRay is not commented out
        if (debugRay)
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * range, Color.green, 7.0f);
        }
        */
    }
}
    