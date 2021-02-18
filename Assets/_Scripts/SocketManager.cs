using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SocketManager : MonoBehaviour
{
    private XRSocketInteractor socketInteractable = null;
    public bool isActive = true;
    private SocketContainer socketContainer;

    private int grabbedObjectCounter = 0;

    private void Awake()
    {
        
        socketInteractable = GetComponent<XRSocketInteractor>();
        socketInteractable.onSelectEnter.AddListener(SetStateAsBeingUsed);
        socketInteractable.onSelectExit.AddListener(SetStateAsBeingNotUsed);
        //socketContainer = transform.parent.GetComponent<SocketContainer>();
    }

    public void OnDestroy()
    {
        socketInteractable.onSelectEnter.RemoveListener(SetStateAsBeingUsed);
        socketInteractable.onSelectExit.RemoveListener(SetStateAsBeingNotUsed);
    }

    private void SetStateAsBeingUsed(XRBaseInteractable interactor)
    {
        if (gameObject.tag == "screw")
        {
            //socketContainer.ChangeStateOfScrew(gameObject, false);
        }
        isActive = false;

    }

    private void SetStateAsBeingNotUsed(XRBaseInteractable interactor)
    {
        if (gameObject.tag == "screw")
        {
            //socketContainer.ChangeStateOfScrew(gameObject, true);
        }
        isActive = true;

    }


}
