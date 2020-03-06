using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloEffect : MonoBehaviour
{
    public Vector3 speed;

    public float amplitude = 0.8f;
    public float k = 0.3f;
    public float dampening_factor = 0.95f;
    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = Vector3.zero - transform.localPosition;
        Vector3 acceleration = k * displacement;
        velocity += acceleration;
        velocity *= dampening_factor;

        transform.localPosition += velocity;

        transform.Rotate(speed * Time.deltaTime);
        transform.localPosition = UnityEngine.Random.onUnitSphere * amplitude;
    }
}
