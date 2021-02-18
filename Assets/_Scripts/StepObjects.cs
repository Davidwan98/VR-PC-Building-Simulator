using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepObjects : MonoBehaviour
{
    BuildSequence _buildSequence;

    void Start()
    {
        _buildSequence = FindObjectOfType<BuildSequence>();
    }

    public void ObjectSelected()
    {
        print(gameObject.tag);
        print(_buildSequence._currentObjectTag);

        if(gameObject.tag == _buildSequence._currentObjectTag)
        {
            print("Good");
            // Positive sounds go, UI image, narration
            //GetComponent<AudioSource>.Play();
        }
        else
        {
            print("Bad");
            // Negative sounds go, UI image, narration
        }
    }

}
