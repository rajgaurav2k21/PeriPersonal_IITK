using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualColliderTrigger : MonoBehaviour
{
    // Reference to the CircleCollider2D and BoxCollider2D
    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;

    // Called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter2D(Collider2D other)
    
    {
        Debug.Log(other);
        if (other == circleCollider)
        {
            Debug.Log("You are in the Range");
        }
        else if (other == boxCollider)
        {
            Debug.Log("You Hit the Target");
        }
    }
}
