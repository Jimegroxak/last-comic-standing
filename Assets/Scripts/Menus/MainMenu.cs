using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnButtonSelected(int index)
    {
        if (index == 0)
        {
            SceneManager.LoadScene(1);
        }

        if (index == 1)
        {
            //TODO, create how to play page
        }

        if (index == 2)
        {
            Debug.Log("Quitting game");
            Application.Quit();
        }
    }
}
