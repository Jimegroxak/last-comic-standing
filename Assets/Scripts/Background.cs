using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Background : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bgText;

    private void Start() 
    {
        UpdateBGText();
    }

    private void UpdateBGText()
    {
        bgText.text = ("Round " + PlayerStats.roundNumber + "").ToString();
    }

    
}
