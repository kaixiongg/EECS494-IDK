using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHook : MonoBehaviour
{

    public LineRenderer hookobj;
    public float hookspeed = 10f;
    public float maxhooklen = 20f;  
    public GameObject  hookendpoint;
    Transform hookendpttran;
    Vector3 originpos;
    public bool ishooking;
    public bool isstop;
    public Transform caughtplayer;
    // Start is called before the first frame update
    void Start()
    {
        hookobj = gameObject.GetComponentInChildren<LineRenderer>();
        hookendpttran = hookendpoint.GetComponent<Transform>();
        originpos = hookendpttran.position;
        caughtplayer = null;
    }

    // Update is called once per frame
    void Update()
    {
        checklength();  

        if (Input.GetKeyDown(KeyCode.Z) && isstop)
        {
            ishooking = true;
        }

        if (ishooking)
        {
            hookobj.enabled = true;
            hookendpoint.SetActive(true);
            hookendpttran.Translate(0, 0, hookspeed * Time.deltaTime);
            //keep the hook same position as the end point of the hook
            hookobj.SetPosition(1, hookendpttran.localPosition);
        }
        //withdraw the hook

        else
        {
            if (Vector3.Distance(originpos, hookendpttran.position) > 0.5f)
            {
                hookendpttran.Translate(0, 0, -hookspeed * Time.deltaTime);
                //keep the hook same position as the end point of the hook
                hookobj.SetPosition(1, hookendpttran.localPosition);
            }
            else
            {
                
                hookobj.enabled = false;
                hookendpoint.SetActive(false);
                isstop = true;
            }

        }
        //release the player being caught
        if (isstop && caughtplayer != null)
        {
            caughtplayer.SetParent(null);
        }
    }

    void checklength() 
    {
        if (Vector3.Distance(originpos, hookendpttran.position) > maxhooklen)
        {
            ishooking = false;
            isstop = false;
        }
    }
}
