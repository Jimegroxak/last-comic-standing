using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joke Group", menuName = "New Joke Group", order = 0)]
public class JokeGroupSO : ScriptableObject 
{
    [TextArea(2,3)]
    [SerializeField] string group = "Enter joke group name here";
}

