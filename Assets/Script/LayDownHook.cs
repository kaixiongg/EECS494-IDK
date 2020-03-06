using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class LayDownHook : MonoBehaviour
{
    private Vector3 spawnPosition;
    public GameObject hookTower;
    CapsuleController capsuleController;

    public Transform forward; // 朝向坐标

    float charge_time = 0;
    public float duration_time;
    ControllerInput input;
    public Image chargeBar;

    public bool isableLayDownHook;

    public int player_number;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        capsuleController = GetComponent<CapsuleController>();
        isableLayDownHook = true;
        player_number = this.GetComponent<CapsuleController>().player_number;
    }

    void Update()
    {
        if (Input.GetButton("LayDownHook" + player_number.ToString()))
        {
            charge_time += Time.deltaTime;
            charge_time = charge_time > duration_time ? duration_time : charge_time;
            chargeBar.fillAmount = charge_time / duration_time;
        }

        if (Input.GetButtonUp("LayDownHook" + player_number.ToString()))
        {
            var temp = forward.position; temp.y = 0.1f;
            //forward.eulerAngles
            //Vector3 rot = capsuleController.getroation().eulerAngles;
            //rot = new Vector3(rot.x, rot.y + 180, rot.z);
            //GameObject tower = Instantiate(hooktower, temp, Quaternion.Euler(rot))

            Vector3 rot = forward.eulerAngles;
            rot = new Vector3(rot.x, rot.y - 90, rot.z - 90);

            GameObject tower = Instantiate(hookTower, temp, Quaternion.Euler(rot));
            tower.GetComponent<FireHook>().hookspeed += tower.GetComponent<FireHook>().hookspeed * (charge_time / duration_time) * 3;
            tower.transform.Find("Hook").GetComponent<Transform>().localScale *= ((charge_time / duration_time) * 2);

            charge_time = 0;
        }
    }

    /*
    void OnPlaceHookTower()
    {

        // Vector3 temp = gameObject.GetComponent<Transform>().position;
        // temp.y = 0.1f;

        var temp = forward.position; temp.y = 0.1f;


        Vector3 rot = capsuleController.getroation().eulerAngles;
        rot = new Vector3(rot.x, rot.y + 180, rot.z);
        GameObject tower = Instantiate(hooktower, temp, Quaternion.Euler(rot));

    }*/

    /*
    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                if (context.interaction is SlowTapInteraction)
                {
                    StartCoroutine(BurstFire((int)(context.duration * burstSpeed)));
                }
                else
                {
                    Fire();
                }
                m_Charging = false;
                break;

            case InputActionPhase.Started:
                if (context.interaction is SlowTapInteraction)
                    m_Charging = true;
                break;

            case InputActionPhase.Canceled:
                m_Charging = false;
                break;
        }
    }
    */


}
