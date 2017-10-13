using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{ 
    
    public float PickMoveSpeed;

    private Vector3 orgPosition;
    private void Start()
    {
        orgPosition = transform.position;
    }

    public void Update()
    {
        transform.position = transform.position + new Vector3(PickMoveSpeed, 0, 0);

        if (transform.position.x < -0.5f)
        {
            transform.position = orgPosition;
        }
    }
}
