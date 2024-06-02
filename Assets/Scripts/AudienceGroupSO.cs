using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Audience Group", menuName = "New Audience Group", order = 0)]
public class AudienceGroupSO : ScriptableObject 
{
    [SerializeField] string groupName;
    [SerializeField] int groupID;
    [SerializeField] public  int[] likes = new int[5];
    [SerializeField] public int[] neutrals = new int[5];
    [SerializeField] public int[] dislikes = new int[5];

    private float maxEntertainmentValue = 100f;
    private float currentEntertainmentValue = 50f;

    public int GetGroupID()
    {
        return groupID;
    }

    public string GetGroupName()
    {
        return groupName;
    }

    public float GetEntertainmentValue()
    {
        return currentEntertainmentValue;
    }

    public void SetEntertainmentValue(float value)
    {
        if (currentEntertainmentValue + value > maxEntertainmentValue)
            currentEntertainmentValue = maxEntertainmentValue;
        else
            currentEntertainmentValue += value;
    }

    public void ResetEntertainmentValue()
    {
        currentEntertainmentValue = 50f;
    }
}
