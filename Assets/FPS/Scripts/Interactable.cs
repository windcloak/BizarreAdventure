using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f; //interactable radius
    public Transform interactionTransform; //position of the interaction

    bool isFocus = false; //is the player interacting with this object?
    bool hasInteracted = false; //Has the object already been interacted with?
    Transform playerTransform; //player position

    public virtual void Interact() {
        //To be overridden
        Debug.Log("Interacting with " + transform.name);
    }

    void Update() {
        //if this interactableis focused
        if(isFocus && !hasInteracted) {
            //if the player is close enough
            float distanceFromPlayer = Vector3.Distance(playerTransform.position, transform.position);
            if(distanceFromPlayer <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform transform) {
        isFocus = true;
        playerTransform = transform;
        hasInteracted = false;
    }
    public void OnDefocused() {
        isFocus = false;
        playerTransform = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected() {
        if(interactionTransform == null) interactionTransform = playerTransform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
