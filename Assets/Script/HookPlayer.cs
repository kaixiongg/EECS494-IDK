using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPlayer : MonoBehaviour
{
    FireHook fireHook;
    public Transform hook;
    // Start is called before the first frame update
    void Start()
    {
        fireHook = gameObject.GetComponentInParent<FireHook>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide!");
        if (other.tag == "Player")
        {
            fireHook.caughtplayer = other.transform;
            other.transform.SetParent(hook);
            fireHook.ishooking = false;
            fireHook.isstop = false;
        }
    }
}
