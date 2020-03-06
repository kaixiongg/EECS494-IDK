using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FireHook : MonoBehaviour
{

    public LineRenderer hookobj;
    public float hookspeed = 2f;
    public float maxhooklen = 20f;  
    public GameObject hookendpoint;
    Transform hookendpttran;
    Vector3 originpos;
    public bool ishooking;
    public bool isstop;
    public Transform caughtplayer;

    private Vector3 dis;

    // Start is called before the first frame update
    void Start()
    {
        //dis = gameObject.GetComponent<Transform>().rotation.eulerAngles;
        //Vector3 cube3 = transform.TransformPoint(transform.Find("Cube3").GetComponent<Transform>().position);
        //Vector3 cube1 = transform.TransformPoint(transform.Find("Cube1").GetComponent<Transform>().position);

        //dis = (cube3 - cube1).normalized;
        Debug.Log(gameObject.GetComponent<Transform>().rotation.eulerAngles);
        dis = gameObject.GetComponent<Transform>().rotation *(-1*Vector3.forward).normalized;
        //dis =  Vector3.forward;
        Debug.Log(dis);
        //Debug.Log(z);
        //Vector3 x = gameObject.GetComponent<Transform>().rotation * Vector3.right;
        //Debug.Log(x);


        hookobj = gameObject.GetComponentInChildren<LineRenderer>();
        hookendpttran = hookendpoint.GetComponent<Transform>();
        originpos = hookendpttran.position;
        caughtplayer = null;

    }

    public void setdis(Vector3 movedis)
    {
        dis = movedis;
    }
    // Update is called once per frame
    void Update()
    {
        //checklength();
        //if (Input.GetKeyDown(KeyCode.Z) && isstop)
        //{
        //    ishooking = true;
        //}

        checklength();
        if (isstop)
        {
            ishooking = true;
        }

        if (ishooking)
        {
            hookobj.enabled = true;
            hookendpoint.SetActive(true);
            Debug.Log(dis);
            hookendpttran.Translate(dis * hookspeed * Time.deltaTime, Space.World);
            //hookendpttran.Translate(1 * hookspeed * Time.deltaTime,0, 1 * hookspeed * Time.deltaTime, Space.World);
            //keep the hook same position as the end point of the hook
            hookobj.SetPosition(1, hookendpttran.localPosition);
        }
        //withdraw the hook
        else
        {
            if (Vector3.Distance(originpos, hookendpttran.position) > 1.0f)
            {
                hookendpttran.Translate(-1 *dis * hookspeed * Time.deltaTime, Space.World);
                //keep the hook same position as the end point of the hook
                hookobj.SetPosition(1, hookendpttran.localPosition);
            }//
            else
            {
                hookobj.enabled = false;
                hookendpoint.SetActive(false);
                isstop = true;

                // dizziness 
                if (caughtplayer != null) { caughtplayer.SetParent(null); StartCoroutine(Dizziness()); }
                else { Destroy(this.gameObject); }
            }

        }
        //release the player being caught
        //if (isstop && caughtplayer != null)
        //{
        //    caughtplayer.SetParent(null);
        //}

        IEnumerator Dizziness()
        {
            foreach (MeshRenderer child in this.GetComponentsInChildren<MeshRenderer>())
            {
                Destroy(child);
            }
            this.isstop = false;
            yield return new WaitForSeconds(3f);
            caughtplayer.GetChild(0).gameObject.SetActive(false);
            caughtplayer.GetComponentInChildren<CapsuleController>().isAbleToMove = true;
            caughtplayer.GetComponentInChildren<PlayerPunch>().isAbleToPunch = true;
            caughtplayer.GetComponentInChildren<LayDownHook>().isAbleToLayDownHook = true;
            Destroy(this.gameObject);
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
