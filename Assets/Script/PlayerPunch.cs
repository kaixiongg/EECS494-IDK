using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    public GameObject LHand;
    public GameObject RHand;
    private bool punch = false;
    public Vector3 direction;

    public GameObject hand;

    void Start()
    {
        direction = new Vector3(1, 0, 0);
        hand = LHand;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && punch == false)
        {
            punch = true;
            StartCoroutine(Punch());
            
        }    
    }

    IEnumerator Punch()
    {
        Vector3 start = hand.transform.position;
        Vector3 end = hand.transform.position + direction * 1.5f;

        float timeElapsed = 0f;
        float totalLerpTime = 0.2f;

        while(timeElapsed < totalLerpTime)
        {
            hand.transform.position = Vector3.Lerp(start, end, (timeElapsed/totalLerpTime));
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
              timeElapsed = 0f;
              totalLerpTime = 0.05f;

        while(timeElapsed < totalLerpTime)
        {
            hand.transform.position = Vector3.Lerp(end, start, (timeElapsed/totalLerpTime));
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        hand.transform.position = start;

        Debug.Log("enable");
        if (hand != LHand) hand = LHand;
        else hand = RHand;
        punch = false;
    }
}
