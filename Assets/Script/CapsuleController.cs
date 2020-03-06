using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CapsuleController : MonoBehaviour
{
    Vector2 movement_input;
    public Vector3 movement;
    public float move_speed = 10f;
    Rigidbody rb;
    public Quaternion rotation;
    MeshRenderer cap_mr;


    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    public Text text_component;
    public int player_number = 1;

    int color = 0;
    int team = 0;

    // public Transform parentPlayer; 

    public bool isableMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cap_mr = transform.Find("Capsule").GetComponent<MeshRenderer>();
        isableMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isableMove)
        {
            Move();
            Rotate();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (team == 0)
        {
            text_component.text = "Team 1";
        }
        else
        {
            text_component.text = "Team 2";
        }
    }

    public Quaternion getroation()
    {
        return rotation;
    }

    void Move()
    {
        
        if (Input.GetAxis("LAnalogX" + player_number.ToString()) != 0 || Input.GetAxis("LAnalogY" + player_number.ToString()) != 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("LAnalogX" + player_number.ToString()), 0.0f, -Input.GetAxis("LAnalogY" + player_number.ToString())) * move_speed * Time.deltaTime;

            rotation = Quaternion.LookRotation(movement);

            transform.Translate(movement, Space.World);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Rotate()
    {
        if (Input.GetAxis("LAnalogX" + player_number.ToString()) != 0 || Input.GetAxis("LAnalogY" + player_number.ToString()) != 0)
        {
            Vector3 movement = new Vector3(Input.GetAxis("LAnalogY" + player_number.ToString()), 0.0f, Input.GetAxis("LAnalogX" + player_number.ToString()));

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(movement), 0.2F);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    //void OnColor(InputValue value)
    //{
    //    color += (int) value.Get<float>();

    //    if (color == -1)
    //        color = 8;
        
    //    color %= 9;

    //    switch (color)
    //    {
    //        case 0:
    //            // foreach( MeshRenderer child in GetComponentsInChildren<MeshRenderer>() )
    //            cap_mr.material.color = Color.white;
    //            break;
    //        case 1:
    //            cap_mr.material.color = Color.black;
    //            break;
    //        case 2:
    //            cap_mr.material.color = Color.red;
    //            break;
    //        case 3:
    //            cap_mr.material.color = Color.yellow;
    //            break;
    //        case 4:
    //            cap_mr.material.color = Color.blue;
    //            break;
    //        case 5:
    //            cap_mr.material.color = Color.cyan;
    //            break;
    //        case 6:
    //            cap_mr.material.color = Color.green;
    //            break;
    //        case 7:
    //            cap_mr.material.color = Color.grey;
    //            break;
    //        case 8:
    //            cap_mr.material.color = Color.magenta;
    //            break;
    //    }
    //}

    //void OnTeam(InputValue value)
    //{
    //    if (team == 0)
    //        team = 1;
    //    else
    //        team = 0;
    //}
}
