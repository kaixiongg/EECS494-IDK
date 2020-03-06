using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayDownHook : MonoBehaviour
{
    private Vector3 spawnpos;
    public GameObject hooktower;
    CapsuleController capsuleController;

    public Transform forward;

    public bool isAbleToLayDownHook;

    // Start is called before the first frame update
    void Start()
    {
        capsuleController = GetComponent<CapsuleController>();
        spawnpos = gameObject.GetComponent<Transform>().localPosition;
        spawnpos.y = 0;
        spawnpos.x += 1;
        isAbleToLayDownHook = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPlaceHookTower()
    {

        // Vector3 temp = gameObject.GetComponent<Transform>().position;
        // temp.y = 0.1f;
        if (isAbleToLayDownHook)
        {
            var temp = forward.position; temp.y = 0.1f;


            Vector3 rot = capsuleController.getroation().eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            GameObject tower = Instantiate(hooktower, temp, Quaternion.Euler(rot));
        }

    }

}
