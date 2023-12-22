using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingEnemy : MonoBehaviour
{
    public float hearingSensitivity;
    public SneakyPlayer player;
    float getHearingLevel()
    {
        float distanceFromPlayer = (player.transform.position - transform.position).magnitude;
        return hearingSensitivity * player.currentNoiseEmission / distanceFromPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hearingLevel = getHearingLevel();
        if(hearingLevel > 0.1f) 
        {
            Debug.Log("I can hear you!");
        }
        else
        {
            Debug.Log(hearingLevel);
        }
    }
}
