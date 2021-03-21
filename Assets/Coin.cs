using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // public GameObject eatenEffect;
    public float coinAmount = 10f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PickupCoin();
        }

    }

    void PickupCoin()
    {
        // FindObjectOfType<AudioManager>().Play("Coin");
        Money.UpdateMoney(coinAmount);
        // Instantiate(eatenEffect, transform.position, transform.rotation);   // show effect
        Destroy(gameObject);    // destroy coin
    }
}
