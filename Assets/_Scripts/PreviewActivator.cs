using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PreviewActivator : MonoBehaviour
{

    private XRGrabInteractable grabInteractable = null;
    private PreviewManager previewManager = null;

    private int grabbedObjectCounter = 0;
    private Collider boxCollider;

    private void Awake()
    {
        previewManager = GameObject.Find("GameManager").GetComponent<PreviewManager>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEnter.AddListener(TurnPreviewOn);
        grabInteractable.onSelectExit.AddListener(TurnPreviewOff);
        boxCollider = GetComponent<Collider>();
    }

    public void OnDestroy()
    {
        grabInteractable.onSelectEnter.RemoveListener(TurnPreviewOn);
        grabInteractable.onSelectExit.RemoveListener(TurnPreviewOff);
    }

    private void TurnPreviewOn(XRBaseInteractor interactor)
    {   
        if (interactor.gameObject.tag != this.gameObject.tag)
        {
            boxCollider.isTrigger = true;
            previewManager.SetPreviewOn(gameObject);
        }
    }

    private void TurnPreviewOff(XRBaseInteractor interactor)
    {
        if (interactor.gameObject.tag != this.gameObject.tag)
        {
            boxCollider.isTrigger = false;
            previewManager.SetPreviewOff();
        }
    }

    
}
