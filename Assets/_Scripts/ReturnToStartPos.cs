using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToStartPos : MonoBehaviour
{

    Vector3 startPosition = new Vector3();
    Quaternion startRotation = new Quaternion();
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, startPosition) > 2 || transform.position.y < 0)
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}
