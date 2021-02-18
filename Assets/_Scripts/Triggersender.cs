using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggersender : MonoBehaviour
{
    Screwdriver parentScript = null;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = transform.parent.GetComponent<Screwdriver>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        parentScript.OnChildTriggerEnter(other.gameObject);
        Debug.Log("triggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        parentScript.OnChildTriggerExit();
        Debug.Log("triggerExit");

    }
}
