using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPunch : MonoBehaviour
{
    public GameObject LHand;
    public GameObject RHand;
    public bool punch = false;

    public Vector3 direction;

    public GameObject hand;

    void Awake()
    {
        hand = LHand;
    }

    void Start()
    {
        direction = new Vector3(1, 0, 0);
    }

    void OnPunch()
    {
        if (punch == false)
        {
            punch = true;
            StartCoroutine(Punch());
        }
    }

    IEnumerator Punch()
    {
        Vector3 start = hand.transform.localPosition;
        Vector3 end = hand.transform.localPosition + direction * 1.5f;

        float timeElapsed = 0f;
        float totalLerpTime = 0.2f;

        while(timeElapsed < totalLerpTime)
        {
            hand.transform.localPosition = Vector3.Lerp(start, end, (timeElapsed/totalLerpTime));
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
              timeElapsed = 0f;
              totalLerpTime = 0.05f;

        while(timeElapsed < totalLerpTime)
        {
            hand.transform.localPosition = Vector3.Lerp(end, start, (timeElapsed/totalLerpTime));
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        hand.transform.localPosition = start;

        if (hand != LHand) hand = LHand;
        else hand = RHand;
        punch = false;
    }
}
