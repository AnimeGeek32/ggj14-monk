using UnityEngine;
using System.Collections;

public class PushOverRock : MonoBehaviour {

    public float StrengthRequirement;

    void OnTriggerStay2D(Collider2D other)
    {
        if (StrengthRequirement != null && other.CompareTag("Player"))
        {
            if (PlayerController.Current.Strength) // need to add public strength to player
            {
                gameObject.rigidbody2D.AddForce(new Vector2(4f, 4f));
            }
        }
    }
}
