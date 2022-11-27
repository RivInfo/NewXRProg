using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsAction : MonoBehaviour
{
    [SerializeField] private int _sceneLoadIndex;
    
    public void LoadSceneAsunc()
    {
        SceneManager.LoadSceneAsync(_sceneLoadIndex);
    }

    public void LoadSceneAsunc(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
