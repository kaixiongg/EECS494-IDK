using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;
public class LayDownHook : MonoBehaviour
{
    private Vector3 spawnpos;
    public GameObject hooktower;
    CapsuleController capsuleController;
    public Transform forward;
    float charge_time = 0;
    public float duration_time;
    ControllerInput input;
    public Image chargebar;
    private bool m_Pressed;
    private bool m_Released;

    public bool isAbleToLayDownHook;

    void Awake()
    {
        input = new ControllerInput();

        input.Capsule.PlaceHookTower.performed += ctx => m_Pressed = true;
        input.Capsule.PlaceHookTower.canceled += ctx => m_Released = true;
        isAbleToLayDownHook = true;
}

    // Start is called before the first frame update
    void Start()
    {
        capsuleController = GetComponent<CapsuleController>();
    }

    void Update()
    {
        //Debug.Log("start");
        if (m_Pressed)
        {
            Debug.Log(charge_time);
            charge_time += Time.deltaTime;
            charge_time = charge_time % duration_time;
            chargebar.fillAmount = charge_time / duration_time;

        }

        if (m_Released)
        {

            var temp = forward.position; temp.y = 0.1f;

            Vector3 rot = capsuleController.getroation().eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            GameObject tower = Instantiate(hooktower, temp, Quaternion.Euler(rot));
            tower.GetComponent<FireHook>().hookspeed += tower.GetComponent<FireHook>().hookspeed * (charge_time / duration_time) * 3;
            tower.transform.Find("Hook").GetComponent<Transform>().localScale *= ((charge_time / duration_time) * 2);

            Debug.Log("niu");
            charge_time = 0;
            m_Pressed = false;
            m_Released = false;
        }



    }
    // Update is called once per frame
    private void OnEnable()
    {
        input.Capsule.Enable();
    }
    private void OnDisable()
    {
        input.Capsule.Disable();
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
