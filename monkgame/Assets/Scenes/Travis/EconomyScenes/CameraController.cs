using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float CatchUpSpeed = 5f;

    private GameObject thePlayer;
    private float y;

    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        y = gameObject.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 following = Vector3.Lerp(transform.position, thePlayer.transform.position, Time.deltaTime * CatchUpSpeed);
        if (following != null || following != Vector3.zero)
        {
            transform.position = new Vector3(following.x, y, following.z);
        }
    }
}
