using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
   
    public void loadthisscene(int lvlIndex)
    {
       SceneManager.LoadScene(lvlIndex);
        Debug.Log("scne load alled");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
