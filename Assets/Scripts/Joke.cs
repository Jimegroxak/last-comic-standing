using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Joke : MonoBehaviour
{
    [SerializeField] JokeGroupSO[] jokeGroups = new JokeGroupSO[5];
    [SerializeField] TextMeshProUGUI[] jokeSetups = new TextMeshProUGUI[4]; 
    private TextMeshProUGUI jokeSetup;
     private JokeGroupSO jokeGroup;

    void Start() 
    {
        for (int i = 0; i < jokeSetups.Length; i++)
        {
            jokeGroup = jokeGroups[Random.Range(0, jokeGroups.Length)];
            jokeSetups[i].text = jokeGroup.GetRandomJokeSetup();
        }
    }
}
