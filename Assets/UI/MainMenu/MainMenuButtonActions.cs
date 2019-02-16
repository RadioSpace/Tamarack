using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonActions : MonoBehaviour
{
    
    public void StartButtonAction()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButtonAction()
    {
        

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;

#elif UNITY_STANDALONE

        Application.Quit(0);

#endif
    }
}
