using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    public bool isHeld = false;
    private GameObject screw = null;
    public GameObject screwDriverMesh;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Update()
    {
        if (isHeld && (Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger") > 0.8 || Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger") > 0.8))
        {
            screwDriverMesh.transform.Rotate(Vector3.forward, -450 * Time.deltaTime);
            if (screw != null)
            {
                screw.transform.Rotate(Vector3.up, -450 * Time.deltaTime);
                screw.transform.Translate(Vector3.down * 0.01f * Time.deltaTime);
            }
        }

        
    }

    // Update is called once per frame
    public void OnChildTriggerEnter(GameObject touchedObject)
    {
        if (touchedObject.gameObject.tag == "screw")
        {
            screw = touchedObject.gameObject;
            Debug.Log(screw.name);
        }
    }
    public void OnChildTriggerExit()
    {
        screw = null;
    }

    public void SendHoldingState()
    {
        isHeld = true;
    }

    public void SendDroppedState()
    {
        isHeld = false;
    }
}
