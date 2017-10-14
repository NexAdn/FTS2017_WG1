using UnityEngine;

public class Axe : MonoBehaviour
{
    [HideInInspector]
    public float speed = 0f;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    public void Update()
    {
        speed = Vector3.Distance(transform.position, lastPosition);

        lastPosition = transform.position;
    }
}
