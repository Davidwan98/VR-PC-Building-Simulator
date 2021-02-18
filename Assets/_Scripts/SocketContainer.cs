using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketContainer : MonoBehaviour
{
    Dictionary<GameObject, bool> dictOfScrews = new Dictionary<GameObject, bool>();
    Dictionary<XRSocketInteractor, LayerMask> dictOfSocketInteractors = new Dictionary<XRSocketInteractor, LayerMask>();
    List<SocketManager> listofSocketManagers = new List<SocketManager>();
    //XRGrabInteractable containerInteractable;
    Rigidbody containerRB;
    public bool attachingEnabled = false;
    public bool grabbingEnabled = true;
    LayerMask permanentLayer;


    private void Awake()
    {
        //containerInteractable = GetComponent<XRGrabInteractable>();
        containerRB = GetComponent<Rigidbody>();
    }
    void Start()
    {
        foreach (Transform child in transform)   /// we use it to get a list of all the childen
        {
            if (child.gameObject.tag == "screw")
            {
                dictOfScrews.Add(child.gameObject, true);
            }
            else
            {
                listofSocketManagers.Add(child.gameObject.GetComponent<SocketManager>());
                dictOfSocketInteractors.Add(child.GetComponent<XRSocketInteractor>(), child.GetComponent<XRSocketInteractor>().interactionLayerMask);
            }
        }
        SetSocketsState(false);
        //permanentLayer = containerInteractable.interactionLayerMask;
    }

    public void ChangeStateOfScrew(GameObject snapCollider, bool state)
    {
        dictOfScrews[snapCollider] = state;
        CheckIfGrabbingEnabled();
        if (grabbingEnabled)
        {
            //containerInteractable.interactionLayerMask = permanentLayer;
            containerRB.useGravity = true;
            containerRB.isKinematic = false;
        }
        else
        {
            //containerInteractable.interactionLayerMask = 0;
            containerRB.useGravity = false;
            containerRB.isKinematic = true;
        }
        SetSocketsState(attachingEnabled);
    }

    private void CheckIfGrabbingEnabled()
    {
        bool localgrabbingEnabled = true;
        bool localattachingEnabled = false;
        for (int i = 0; i < dictOfScrews.Count; i++)
        {
            localgrabbingEnabled = localgrabbingEnabled && dictOfScrews.Values.ElementAt(i);
            localattachingEnabled = localattachingEnabled || dictOfScrews.Values.ElementAt(i);
        }
        grabbingEnabled = localgrabbingEnabled;
        attachingEnabled = localattachingEnabled;
    }

    public void SetSocketsState(bool currentState)
    {
        for (int i = 0; i < listofSocketManagers.Count; i++)
        {
            listofSocketManagers[i].isActive = currentState;
            if(!currentState)
            dictOfSocketInteractors.Keys.ElementAt(i).InteractionLayerMask = 0;
            else
            dictOfSocketInteractors.Keys.ElementAt(i).InteractionLayerMask = dictOfSocketInteractors[dictOfSocketInteractors.Keys.ElementAt(i)];
        }
    }
        // Update is called once per frame
    void Update()
    {

    }

}
