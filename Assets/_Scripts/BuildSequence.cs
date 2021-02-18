using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BuildSequence : MonoBehaviour
{
    public enum _Steps { S1Screws, S2RAM, S3CPU, S4Heatsink, S5GPU, S6PSU }
    public _Steps _step;
    public string _currentObjectTag;
    public int _stepCompletion = 0;
    public int _stepCompletionTotal;
    public Image _stepImage;
    public Sprite[] _stepImages;
    //public AudioClip[] _narrations;



    private void Start()
    {
        ChangeStep(_Steps.S1Screws);
    }

    public void ChangeStep(_Steps _stepChange)
    {
        _step = _stepChange;
        _stepCompletion = 0;
        switch (_step)
        {
            case _Steps.S1Screws:
                _currentObjectTag = "screw";
                _stepCompletionTotal = 5;
                print("screws completed");
                _stepImage.sprite = _stepImages[0];
                //_narrations.AudioClip = _narrations[0];
                break;
            case _Steps.S2RAM:
                _currentObjectTag = "RAM";
                _stepCompletionTotal = 2;
                print("RAM completed");
                _stepImage.sprite = _stepImages[1];
                break;
            case _Steps.S3CPU:
                _currentObjectTag = "CPU";
                _stepCompletionTotal = 1;
                print("CPU completed");
                _stepImage.sprite = _stepImages[2];
                break;
            case _Steps.S4Heatsink:
                _currentObjectTag = "heatsink";
                _stepCompletionTotal = 1;
                print("Heatsink completed");
                _stepImage.sprite = _stepImages[3];
                break;
            case _Steps.S5GPU:
                _currentObjectTag = "GPU";
                _stepCompletionTotal = 1;
                print("GPU completed");
                _stepImage.sprite = _stepImages[4];
                break;
            case _Steps.S6PSU:
                _currentObjectTag = "PSU";
                _stepCompletionTotal = 1;
                print("PSU completed");
                _stepImage.sprite = _stepImages[5];
                break;
                    


        }
    }

    private void Update()
    {
        if (_stepCompletion == _stepCompletionTotal && _step ==_Steps.S1Screws) ChangeStep(_Steps.S2RAM);
        if (_stepCompletion == _stepCompletionTotal && _step == _Steps.S2RAM) ChangeStep(_Steps.S3CPU);
        if (_stepCompletion == _stepCompletionTotal && _step == _Steps.S3CPU) ChangeStep(_Steps.S4Heatsink);
        if (_stepCompletion == _stepCompletionTotal && _step == _Steps.S4Heatsink) ChangeStep(_Steps.S5GPU);
        if (_stepCompletion == _stepCompletionTotal && _step == _Steps.S5GPU) ChangeStep(_Steps.S6PSU);


        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeStep(_Steps.S1Screws);
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeStep(_Steps.S2RAM);
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeStep(_Steps.S3CPU);
        if (Input.GetKeyDown(KeyCode.Alpha4)) ChangeStep(_Steps.S4Heatsink);
        if (Input.GetKeyDown(KeyCode.Alpha5)) ChangeStep(_Steps.S5GPU);
        if (Input.GetKeyDown(KeyCode.Alpha6)) ChangeStep(_Steps.S6PSU);
    }

}
