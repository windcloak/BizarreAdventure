using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCText : MonoBehaviour
{
    private GameObject triggeringNPC;
    private bool triggering;

    public GameObject text;
    public GameObject textbox;

    void Start(){

    }
    void Update(){
        if (triggering){
            text.SetActive(true);
            textbox.SetActive(true);
        }
        else{
            text.SetActive(false);
            textbox.SetActive(false);
        }
 

    }
    
    // seeing if player collides with npc
    void OnTriggerEnter(Collider other){ 
        if (other.tag == "Player"){
            triggering = true;
            triggeringNPC = other.gameObject; // the object we are colliding with
        }


    }


    // seeing if player is not colliding with npc
    void OnTriggerExit(Collider other){
        if (other.tag == "Player"){
            triggering = false;
            triggeringNPC = null; // the object we are colliding with
        }
    }
}
