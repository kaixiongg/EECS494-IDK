using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPunch : MonoBehaviour
{
    public GameObject LHand; // LHand
    public GameObject RHand; // RHand

    public bool isPunch; // 是否出拳
    public bool isablePunch; // 是否能出拳

    public Vector3 direction; // 出拳方向

    public GameObject hand; // 出拳手

    int player_number; // player 序列号
     
    void Awake()
    {
        hand = LHand; // 出拳手初始是左手
    }

    void Start()
    {
        isPunch = false;
        isablePunch = true;
        direction = new Vector3(1, 0, 0);
        player_number = this.GetComponent<CapsuleController>().player_number;
    }

    void Update()
    {
        if (isPunch == false && isablePunch && Input.GetButtonDown("Punch" + player_number.ToString()))
        {
            isPunch = true;
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

        if (hand != LHand) { hand = LHand; } // 换手
        else { hand = RHand; }

        isPunch = false;
    }
}
