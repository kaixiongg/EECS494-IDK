using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleController : MonoBehaviour
{
    Vector2 movement_input;
    public Vector3 movement;
    public float move_speed = 10f;
    Rigidbody rb;
    public Quaternion rotation;
    MeshRenderer mr;
    int color = 0;
    int team = 0;

    // public Transform parentPlayer; 

    public bool isAbleToMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //string[] gamepadnames = Input.GetJoystickNames();
        //foreach(string name in gamepadnames)
        //{
        //    Debug.Log(name);
        //}
        Debug.Log(Input.GetAxis("LAnalogX").ToString());
        Debug.Log(Input.GetButtonDown("A").ToString());

        if (isAbleToMove)
        {
            Move();
            Rotate();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }

    public Quaternion getroation()
    {
        return rotation;
    }
    void Move()
    {
        if (movement_input != Vector2.zero)
        {
            Vector3 movement = new Vector3(movement_input.x, 0, movement_input.y) * move_speed * Time.deltaTime;
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
        if (movement_input != Vector2.zero)
        {
            Vector3 movement = new Vector3(-movement_input.y, 0.0f, movement_input.x);

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(movement), 0.2F);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void OnMove(InputValue value)
    {
        movement_input = value.Get<Vector2>();
    }

    void OnColor(InputValue value)
    {
        color += (int) value.Get<float>();

        if (color == -1)
            color = 8;
        
        color %= 9;

        switch (color)
        {
            case 0:
                // foreach( MeshRenderer child in GetComponentsInChildren<MeshRenderer>() )
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.white;
                break;
            case 1:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.black;
                break;
            case 2:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 3:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case 4:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 5:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.cyan;
                break;
            case 6:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case 7:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.grey;
                break;
            case 8:
                transform.Find("Capsule").GetComponent<MeshRenderer>().material.color = Color.magenta;
                break;
        }
    }

    void OnTeam(InputValue value)
    {
        if (team == 0)
            team = 1;
        else
            team = 0;
    }
}
