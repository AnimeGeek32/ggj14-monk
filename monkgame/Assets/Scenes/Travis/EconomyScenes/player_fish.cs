using UnityEngine;
using System.Collections;

public class player_fish : MonoBehaviour
{
    public static player_fish Current;
    public float MoveSpeed = 5f;

    private float y;
    // Use this for initialization
    void Start()
    {
        Current = this;
        y = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigidbody
            .transform
            .Translate(
                horizontal * Time.deltaTime * MoveSpeed,
                0f,
                vertical * Time.deltaTime * MoveSpeed
            );
    }
}