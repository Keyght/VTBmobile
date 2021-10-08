using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenAnotherScene : MonoBehaviour
{
    public string sceneToLoad;

    public void OnMouseDown()
    {
        LoadScene();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
   
}
