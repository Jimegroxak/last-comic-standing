using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudienceMember : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[5];
    [SerializeField] Image audienceMemberImage;
    private RectTransform rectTransform;
    private AudienceGroupSO audienceGroupSO;

    private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        TryUpdateSprite();
    }

    public void AssignAudienceGroup(AudienceGroupSO audienceGroupSO)
    {
        this.audienceGroupSO = audienceGroupSO;
    }

    private void TryUpdateSprite()
    {
        if (audienceGroupSO)
        {
            float entertainmentValue = audienceGroupSO.GetEntertainmentValue();
            if (entertainmentValue > 80f)
                audienceMemberImage.sprite = sprites[4];
            else if (entertainmentValue > 60f)
                audienceMemberImage.sprite = sprites[3];
            else if (entertainmentValue > 40f)
                audienceMemberImage.sprite = sprites[2];
            else if (entertainmentValue > 20f)
                audienceMemberImage.sprite = sprites[1];
            else
                audienceMemberImage.sprite = sprites[0];
        }
        
    }

    public void SetSpawnLocation(int x, int y)
    {
        rectTransform.anchoredPosition = new Vector3(x, y, 0);
    }
}
