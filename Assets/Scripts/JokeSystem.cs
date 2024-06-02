using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JokeSystem : MonoBehaviour
{
    public static JokeSystem Instance { get; private set; }

    public class OnPunchlineSelectedEventArgs : EventArgs
    {
        public bool correctJoke;
        public int jokeGroupIndex;
    }

    public event EventHandler<OnPunchlineSelectedEventArgs> OnPunchlineSelected;

    [SerializeField] JokeGroupSO[] jokeGroups = new JokeGroupSO[5];
    [SerializeField] TextMeshProUGUI[] jokeButtons = new TextMeshProUGUI[4]; 
    [SerializeField] 
    private int[] activeJokeGroups = new int[4];
    private string setup;
    private string punchline;
    private int selectedGroup;

    private int state = 0;

    private void Awake() 
    {
        if (Instance)
        {
            Debug.LogError("There is more than one joke system! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
            
        Instance = this;    
    }

    void Start() 
    {
        DisplaySetups();
    }

    public void OnButtonSelected(int index)
    {
        if (state == 0)
        {
            setup = jokeButtons[index].text;
            DisplayPunchlines(index);
        }
           
        else if (state == 1)
        {
            punchline = jokeButtons[index].text;
            bool correct = jokeGroups[selectedGroup].IsMatchingParts(setup, punchline);
            //Debug.Log("Current group " + jokeGroups[activeJokeGroups[index]]);
            OnPunchlineSelected?.Invoke(this, new OnPunchlineSelectedEventArgs { correctJoke = correct, jokeGroupIndex = GetCurrentJokeGroupIndex(index)});
            DisplaySetups();
        }
    }

    private void DisplaySetups()
    {
        for (int i = 0; i < jokeButtons.Length; i++)
        {
            int r = UnityEngine.Random.Range(0, jokeGroups.Length);
            jokeButtons[i].text = jokeGroups[r].GetRandomJokeSetup();
            jokeButtons[i].transform.parent.gameObject.GetComponent<Image>().color = jokeGroups[r].GetColor();
            activeJokeGroups[i] = r;
        }
        state = 0;
    }

    private void DisplayPunchlines(int index)
    {
        selectedGroup = activeJokeGroups[index];
        Debug.Log(selectedGroup);
        string[] punchlines = new string[4];
        punchlines = jokeGroups[activeJokeGroups[index]].GetPunchlines();
        for (int i = 0; i < jokeButtons.Length; i++)
        {
            jokeButtons[i].text = punchlines[i];
            jokeButtons[i].transform.parent.gameObject.GetComponent<Image>().color = Color.black;
        }

        state = 1;
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < jokeButtons.Length; i++)
        {
            Button button = jokeButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    //pass this index to audience script for processing by likes/dislikes tables
    public int GetCurrentJokeGroupIndex(int index)
    {
        return jokeGroups[activeJokeGroups[index]].GetGroupID();
    }
}
