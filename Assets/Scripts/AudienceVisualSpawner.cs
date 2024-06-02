using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceVisualSpawner : MonoBehaviour
{
    [SerializeField] private GameObject audienceMemberVisualPrefab;

    readonly int[] xBound = {-900, 900};
    readonly int[] yBound = {-160, 280};

    private void Start() 
    {
        foreach (AudienceGroupSO ag in Audience.Instance.GetAudienceGroupSOs())
        {
            for (int i = 0; i < 3; i++)
            {
                int x = Random.Range(xBound[0], xBound[1]);
                int y = Random.Range(yBound[0], yBound[1]);
                GameObject curr = Instantiate(audienceMemberVisualPrefab, transform);
                AudienceMember currScript = curr.GetComponent<AudienceMember>();
                currScript.SetSpawnLocation(x, y);
                currScript.AssignAudienceGroup(ag);
            }
        }    
    }
}
