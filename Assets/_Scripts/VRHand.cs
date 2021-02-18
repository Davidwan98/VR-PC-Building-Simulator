using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHand : MonoBehaviour
{
    public bool _triggered;
    public GameObject _triggeredObject;
    private void OnTriggerEnter(Collider other)
    {
        print("Triggered");
        _triggered = true;
        _triggeredObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        print("NOT TRiggered");
        _triggered = false;
        _triggeredObject = null; // null means no value / empty
    }
}
