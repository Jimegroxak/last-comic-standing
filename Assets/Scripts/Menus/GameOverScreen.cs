using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI resultText;
    public void Setup()
    {
        gameObject.SetActive(true);
        resultText.text = ("You made it to round " + PlayerStats.roundNumber.ToString());
    }

    public void OnButtonSelected(int index)
    {
        if (index == 0)
        {
            GameController.Instance.RestartGame();
        }

        else if (index == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
