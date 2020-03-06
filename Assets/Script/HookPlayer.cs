using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPlayer : MonoBehaviour
{
    FireHook fireHook;
    public Transform hook;
    GameObject playerMovement;

    void Start()
    {
        fireHook = gameObject.GetComponentInParent<FireHook>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            ScreenShakeManager.Perturb();
            fireHook.caughtplayer = collision.collider.gameObject.transform.parent.transform;

            collision.collider.gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);
            collision.collider.gameObject.transform.parent.transform.SetParent(hook);
            collision.collider.gameObject.GetComponent<CapsuleController>().isAbleToMove = false;
            collision.collider.gameObject.GetComponent<PlayerPunch>().isAbleToPunch = false;
            collision.collider.gameObject.GetComponent<LayDownHook>().isAbleToLayDownHook = false;

            playerMovement = collision.collider.gameObject;
            fireHook.ishooking = false;
            fireHook.isstop = false;
        }
    }

    void OnDestroy()
    {
        playerMovement.GetComponent<CapsuleController>().isAbleToMove = true;
    }

}
