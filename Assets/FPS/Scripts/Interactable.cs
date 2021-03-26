using UnityEngine;

public class Interactable : MonoBehaviour
{

    private bool _canBeInteractedWith;
    private PlayerCharacterController _pickingPlayer;

    public delegate void onInteract();

    Transform playerTransform; //player position

    void Update() {
        //if in interactable range
        if (_canBeInteractedWith && Input.GetKeyDown(KeyCode.F))
        {
            //if the f key is pressed
            Interact(); //Perform some assigned interaction
        }
    }

    public virtual void Interact()
    {
        //To be overridden
        Debug.Log("Interacting with " + transform.name);
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
