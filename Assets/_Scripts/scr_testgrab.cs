using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_testgrab : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rigidbody.useGravity = false; // when mousebutton is down turn gravity off
            gameObject.transform.position = Input.mousePosition;

        }
        if(Input.GetMouseButtonUp(0))
        {
            _rigidbody.useGravity = true;
        }
    }
}
