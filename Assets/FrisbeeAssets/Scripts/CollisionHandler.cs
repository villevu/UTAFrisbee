using UnityEngine;
using System.Collections;

/* Frisbee interactions with other objects. Main purpose is to determine if a throw hit
 * the target.
 * 
 * 
 * 
 */

public class CollisionHandler : MonoBehaviour {

    // Checks for collision event (ie. hitting something)
    //collisionDetails = the target that was hit by this object ?
    void OnCollisionEnter(Collision collisionDetails) {
      
        //Debug.Log("Frisbee hit something" + collisionDetails.collider);
       
        if (collisionDetails.gameObject.name == "Target")
        {
            Destroy(collisionDetails.gameObject);
            print("HIT!");
        }        
        
        //Activates when the frisbee is in the goal basket
        if (collisionDetails.gameObject.name == "Goal_HitBox_InsideBasketCheck")
        {
            Debug.Log("Frisbee in basket!");
        }

        //Could also play a simple animation and/or metallic sound here by using
        //Goal_Hitbox_MetalChains as the activator;
        if (collisionDetails.gameObject.name == "Goal_Hitbox_MetalChains")
        {
            Debug.Log("Metallic cling!!");
        }

        
    }
}
