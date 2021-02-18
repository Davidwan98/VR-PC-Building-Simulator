using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; // add Unity audio functionality in this script


public class scr_snapping_snapsound : MonoBehaviour
{
    public GameObject _snapableObject; // variable.  lets us choose our object
    public GameObject _snapableObject2;
    private AudioSource _audioSource; // 
    //private MeshRenderer _meshRenderer;
    private bool _isTriggered = false; // triggered = true means object is within the trigger's space


    private void Start() // step after awake, before update
    {
        _audioSource = GetComponent<AudioSource>();
        //_meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
            if (Input.GetMouseButtonUp(0) && _isTriggered) // if left click is clicked & released, and it's inside the trigger box.  && means adding second condition to if statement
            {
                _snapableObject.transform.position = transform.position; // make the object go to trigger's position
                _snapableObject.transform.rotation = transform.rotation; // make the object rotate upright
                _audioSource.Play();
                //_meshRenderer.enabled = false;
            }
    }
    // on trigger enter and on trigger exit only happen once
    private void OnTriggerEnter(Collider other) // Is trigger box is checked. collider other us any other gameobject that touches this object. private = keeps it inside this script only
    {
        if (other.transform == _snapableObject.transform) // only trigger if collider is snapable object
        { 
            _isTriggered = true; // turn on trigger
        }
    }

    private void OnTriggerExit(Collider other) // checking to see if object left so we can turn off the trigger
    {
        if (other.transform == _snapableObject.transform)
        {
            _isTriggered = false;
        }
    }
}
