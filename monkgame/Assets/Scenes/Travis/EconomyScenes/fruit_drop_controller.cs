using UnityEngine;
using System.Collections;

public class fruit_drop_controller : MonoBehaviour
{
    public float Timer = 3f;
    private float _timer = 0f;
    public float DropSpeed;
    private Vector3 _dropSpeed;
    private int fishLayerMask;

    // Use this for initialization
    void Start()
    {
        _timer = 0f;
        _dropSpeed = Vector3.back * DropSpeed;
        fishLayerMask = 1 << LayerMask.NameToLayer("fishLayer");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, float.PositiveInfinity, fishLayerMask);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                EconomyController.Current.PlayerAteTheFruit();
                Destroy(gameObject);
            }
            else if (hit.collider.CompareTag("fish"))
            {
                EconomyController.Current.FishAteTheFruit();
                Destroy(gameObject);
            }
        }

        if (_timer >= Timer)
        {
            Destroy(gameObject);
        }

        Vector3 dropping = _dropSpeed * Time.deltaTime;
        gameObject.transform.Translate(dropping);

        _timer += Time.deltaTime;
    }
}
