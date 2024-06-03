using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    public static Audience Instance { get; private set; }

    //[SerializeField] AudienceGroupSO[] audienceGroups = new AudienceGroupSO[3];
    private AudienceGroupSO[] audienceGroups = new AudienceGroupSO[3];
    [SerializeField] private GameObject entertainmentGaugePrefab;

    private int[] activeGroups = new int[3];

    private void Awake() 
    {
        if (Instance)
        {
            Debug.LogError("There is more than one audience system! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
            
        Instance = this;    
    }

    private void Start()
    {
        for (int i = 0; i < audienceGroups.Length; i++)
        {
            audienceGroups[i].ResetEntertainmentValue();
        }
        CreateEntertainmentGauges();

        JokeSystem.Instance.OnPunchlineSelected += JokeSystem_OnPunchlineSelected;
    }

    private void LateUpdate() 
    {
        for (int i = 0; i < audienceGroups.Length; i++)
            audienceGroups[i].SetEntertainmentValue(-Time.deltaTime * PlayerStats.entertainmentDecaySpeed); 
    }

    private void CreateEntertainmentGauges()
    {
        for (int i = 0; i < audienceGroups.Length; i++)
        {
            GameObject currGauge = Instantiate(entertainmentGaugePrefab, GameObject.Find("/JokeCanvas/EntertainmentGaugeGroup").transform);
            EntertainmentGauge gauge = currGauge.GetComponent<EntertainmentGauge>();
            gauge.SetAudienceGroup(audienceGroups[i]);
            gauge.SetText(audienceGroups[i].GetGroupName());
        } 
    }

    public AudienceGroupSO GetAudienceGroupSO(int index)
    {
        return audienceGroups[index];
    }

    public AudienceGroupSO[] GetAudienceGroupSOs()
    {
        return audienceGroups;
    }

    public void SetAudienceGroupSOs(AudienceGroupSO[] audienceGroups)
    {
        this.audienceGroups = audienceGroups;
    }

    private void JokeSystem_OnPunchlineSelected(object sender, JokeSystem.OnPunchlineSelectedEventArgs e)
    {
        bool correctJoke = e.correctJoke;
        int jokeGroupIndex = e.jokeGroupIndex;

        foreach (AudienceGroupSO a in audienceGroups)
        {
            if (correctJoke)
            {
                if (a.likes.Contains(jokeGroupIndex))
                    a.SetEntertainmentValue(25f);
                else if (a.neutrals.Contains(jokeGroupIndex))
                    a.SetEntertainmentValue(10f);
                else if (a.dislikes.Contains(jokeGroupIndex))
                    a.SetEntertainmentValue(-10f);
            }

            else
            {
                a.SetEntertainmentValue(-20f);
                Debug.Log("Bad joke!");
            }
        }

    }
}
