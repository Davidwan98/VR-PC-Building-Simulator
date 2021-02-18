using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepPlaced : MonoBehaviour
{
    private AudioSource _audioSource; // where the sound is playing from.
    public AudioClip _placedObjectSound;
    public AudioClip _removedObjectSound;
    public AudioClip _successNarration;
    public AudioClip _failNarration;
    //public Image _pickUpObject; // MAYBE LATER
    //public Image _putDownObject;
    //public Image _placeObject;

    BuildSequence _buildSequence;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _buildSequence = FindObjectOfType<BuildSequence>();
    }

    public void PlacedObject()
    {
        if (gameObject.tag == _buildSequence._currentObjectTag)
        {
            _buildSequence._stepCompletion += 1;
            // sounds ......
            _audioSource.clip = _successNarration;
            _audioSource.Play();
            print("placed");
        }

    }

    public void RemovedObject()
    {
        if (gameObject.tag == _buildSequence._currentObjectTag)
        {
            _buildSequence._stepCompletion -= 1; 
            // sounds ...... 
            _audioSource.clip = _failNarration;
            _audioSource.Play();
            print("removed");
        }
        print("REMOVED outside");
        print(gameObject.tag);
        print(_buildSequence._currentObjectTag);
    }


}
