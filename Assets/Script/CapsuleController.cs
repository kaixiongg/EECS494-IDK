using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleController : MonoBehaviour
{
    Vector2 movement_input;
    public float move_speed = 10f;
    public float rotate_speed = 10f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 movement = new Vector3(movement_input.x, 0, movement_input.y) * move_speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    void Rotate()
    {
        if (movement_input != Vector2.zero)
        {
            Vector3 movement = new Vector3(-movement_input.y, 0.0f, movement_input.x);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2F);
        }
    }

    void OnMove(InputValue value)
    {
        movement_input = value.Get<Vector2>();
    }

    
}
