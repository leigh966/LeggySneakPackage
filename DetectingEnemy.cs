using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingEnemy : MonoBehaviour
{
    public float hearingSensitivity, fieldOfView, numberOfRaycasts;
    public SneakyPlayer player;
    float getHearingLevel()
    {
        float distanceFromPlayer = (player.transform.position - transform.position).magnitude;
        return hearingSensitivity * player.currentNoiseEmission / distanceFromPlayer;
    }

    bool canSeePlayer()
    {
        float deltaAngle = fieldOfView / (float)(numberOfRaycasts);
        for(float angle = -fieldOfView/2; angle <= fieldOfView/2; angle+=deltaAngle)
        {
            Vector3 rayVector = Quaternion.Euler(0f, angle, 0f) * transform.forward;
            bool didHit = Physics.Raycast(transform.position, rayVector, out RaycastHit hit, 100.0F);
            if (!didHit) continue;
            if (hit.collider.gameObject == player.gameObject)
            {
                return true;
            }
        }

        return false;
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
        if(canSeePlayer())
        {
            Debug.Log("I can see you");
        }
    }
}
