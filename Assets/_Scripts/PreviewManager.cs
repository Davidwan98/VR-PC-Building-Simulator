using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PreviewManager : MonoBehaviour
{
    private List<GameObject> preview_list = new List<GameObject>();
    public GameObject[] slotContainer;       /// any piece that has snaps in children. Make sure that children has an apropriet tag
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject slot_container in slotContainer)
        {
            foreach (Transform child in slot_container.transform)   /// we use it to get a list of all the childen
            {
                    child.GetComponent<MeshRenderer>().enabled = false; /// disable all meshes by default
                    preview_list.Add(child.gameObject);             /// append the list with that child

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //SetPreviewOn(receiverObject);
    }

    public void SetPreviewOn(GameObject grabbedObject)     /// should be called from another script and send here a currently grabbed object
    {
        foreach (GameObject slot_container in slotContainer)
        {

            foreach (GameObject snapChild in preview_list)
            {
                if (snapChild.tag == grabbedObject.tag && snapChild.GetComponent<SocketManager>().isActive)
                {
                    snapChild.GetComponent<MeshRenderer>().enabled = true;  ///enable needed meshes
                }
            }
        }
    }

    public void SetPreviewOff()                                    /// should be called from another script when there is nothing in the hands
    {
        foreach (GameObject slot_container in slotContainer)
        {
            foreach (GameObject snapChild in preview_list)
            {
                    snapChild.GetComponent<MeshRenderer>().enabled = false;     /// disable all meshes
             
            }
        }
    }
}
