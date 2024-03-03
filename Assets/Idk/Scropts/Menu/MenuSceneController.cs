using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
  public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void ClassChange()
    {
        SceneManager.LoadScene("ClassesScreen");
    }

    public void QuitGame()
    {
        Debug.Log("Game has been quit");
        Application.Quit();
    }
}
