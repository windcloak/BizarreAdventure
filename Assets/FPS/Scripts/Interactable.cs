using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool _canBeInteractedWith;
    private PlayerCharacterController _pickingPlayer;

    public delegate void onInteract();

    Transform playerTransform; //player position

    public virtual void Interact() {
        //To be overridden
        Debug.Log("Interacting with " + transform.name);
    }
    void Update() {
        //if in interactable range
        if (_canBeInteractedWith)
        {
            //if the f key is pressed
            if (Input.GetKeyDown(KeyCode.F))
            {
                Interact(); //Perform some assigned interaction
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _pickingPlayer = other.GetComponent<PlayerCharacterController>();

        if (_pickingPlayer != null)
        {
            _canBeInteractedWith = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _pickingPlayer = other.GetComponent<PlayerCharacterController>();

        if (_pickingPlayer != null)
        {
            _canBeInteractedWith = false;
        }
    }
}
