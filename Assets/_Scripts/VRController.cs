using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

//public class VRController : MonoBehaviour
//{
//    public GameObject _hand;
//    private VRHand _vrHand;
//    public GameObject _grabbedObject;
//    public Quaternion _handRotation;
//    public Vector3 _handPosition;
    

//    // Start is called before the first frame update
//    void Start()
//    {
//        _vrHand = _hand.GetComponent<VRHand>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        _handPosition = UnityEngine.XR.InputTracking.GetLocalPosition(XRNode.RightHand);
//        _handRotation = UnityEngine.XR.InputTracking.GetLocalRotation(XRNode.RightHand);
//        _hand.transform.position = _handPosition;
//        if(Input.GetButton("XRI_Right_Gripbutton") == true)
//        {
//            print("Grab");
//            if (_vrHand._triggered)
//            {
//                _grabbedObject = _vrHand._triggeredObject;
//                _grabbedObject.transform.position = _handPosition;
//                _grabbedObject.transform.rotation = _handPosition;
//                _grabbedObject.GetComponent<Rigidbody>().useGravity = false;
//            }
//        }
//        if (Input.GetButton("XRI_Right_Gripbutton") == false)
//        {
//            _grabbedObject.GetComponent<Rigidbody>().useGravity = true;
//        }



//    }


//}
