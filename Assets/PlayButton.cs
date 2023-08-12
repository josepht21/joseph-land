using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);        
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(SceneManager.sceneCountInBuildSettings > nextSceneIndex )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);        
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }

    public void SelectLevelMenu()
    {
        SceneManager.LoadScene(1);
    }
}
