using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set;}

    [SerializeField] AudienceGroupSO[] audienceGroups = new AudienceGroupSO[3];
    [SerializeField] Timer timer;
    private string currentSceneName;

    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;  
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start() 
    {
        SetAudienceGroups();
        timer.OnTimerFinished += Timer_OnTimerFinished;
    }

    private void Update() 
    {
        CheckEntertainmentValues(Audience.Instance.GetAudienceGroupSOs());    
    }

    private void SetAudienceGroups()
    {
        int roundNumber = PlayerStats.roundNumber;
        AudienceGroupSO[] activeGroups = new AudienceGroupSO[Math.Min(roundNumber, audienceGroups.Length)];
        for (int i = 0; i < activeGroups.Length; i++)
        {
            AudienceGroupSO a;
            
            do
            {
                a = audienceGroups[UnityEngine.Random.Range(0, 3)];
            }    
            while (activeGroups.Contains(a));

            activeGroups[i] = a;
        }

        
        
        Audience.Instance.SetAudienceGroupSOs(activeGroups);
    }

    private void CheckEntertainmentValues(AudienceGroupSO[] audienceGroups)
    {
        foreach (AudienceGroupSO a in audienceGroups)
        {
            if (a.GetEntertainmentValue() <= 0)
            {
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    private void Timer_OnTimerFinished(object sender, EventArgs e)
    {
        Debug.Log("You win!");
        PlayerStats.roundNumber += 1;
        PlayerStats.entertainmentDecaySpeed *= 1.2f;
        SceneManager.LoadScene(currentSceneName);
    }
}
