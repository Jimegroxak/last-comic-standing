using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joke Group", menuName = "New Joke Group", order = 0)]
public class JokeGroupSO : ScriptableObject 
{
    [SerializeField] string[] jokeSetups = new string[4];
    [SerializeField] string[] jokePunchlines = new string[4];
    [SerializeField] int groupID;
    [SerializeField] Color jokeColor;

    public string GetRandomJokeSetup()
    {
        int jokeIndex = UnityEngine.Random.Range(0, jokeSetups.Length);
        return jokeSetups[jokeIndex];
    }

    public string[] GetPunchlines()
    {
        return jokePunchlines;
    }

    public int GetGroupID()
    {
        return groupID;
    }

    public Color GetColor()
    {
        return jokeColor;
    }

    public bool IsMatchingParts(string setup, string punchline)
    {
        if (Array.IndexOf(jokeSetups, setup) == Array.IndexOf(jokePunchlines, punchline))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}

