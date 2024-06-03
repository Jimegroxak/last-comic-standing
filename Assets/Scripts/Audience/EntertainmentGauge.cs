using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntertainmentGauge : MonoBehaviour
{
    private const float MAX_ENTERTAINMENT_VALUE = 100f;

    private AudienceGroupSO audienceGroup;
    [SerializeField] private Image gaugeImage;
    [SerializeField] private TextMeshProUGUI gaugeText;

    public void SetAudienceGroup(AudienceGroupSO audience)
    {
        audienceGroup = audience;
    }

    public void SetText(string text)
    {
        gaugeText.text = text;
    }

    private void Update() 
    {
        if (audienceGroup)
        {
            gaugeImage.fillAmount = audienceGroup.GetEntertainmentValue() / MAX_ENTERTAINMENT_VALUE;
        }    
    }
}
