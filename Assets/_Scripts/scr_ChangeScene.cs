using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_ChangeScene : MonoBehaviour
{
    public int _sceneNumber;
    public void ChangeScene()
    
    {
        SceneManager.LoadScene(1);
    }
}
