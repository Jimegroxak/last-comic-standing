using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joke Group", menuName = "New Joke Group", order = 0)]
public class JokeGroupSO : ScriptableObject 
{
    [SerializeField] string[] jokeSetups = new string[4];
    [SerializeField] string[] jokePunchlines = new string[4];

    public string GetRandomJokeSetup()
    {
        int jokeIndex = Random.Range(0, jokeSetups.Length);
        return jokeSetups[jokeIndex];
    }

    public string[] GetPunchlines()
    {
        return jokePunchlines;
    }
}

