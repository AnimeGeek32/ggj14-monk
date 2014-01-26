using UnityEngine;
using System.Collections;

public class WaterTriggers : MonoBehaviour
{
    private GameObject player;

    void OnAwake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Current.InWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.Current.WaterJump();
            PlayerController.Current.InWater = false;
        }
    }
}
