using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimAssist : MonoBehaviour
{
    public GameObject hookendpoint;
    Transform endptrtran;
    ControllerInput controls;

    bool show_assist = false;

    void Awake()
    {
        controls = new ControllerInput();
        controls.Capsule.AimAssist.started += ctx => KeyDown();
        controls.Capsule.AimAssist.canceled += ctx => KeyUp();
    }

    void Start()
    {
        endptrtran = hookendpoint.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (show_assist)
            DrawDottedLine(endptrtran.position - new Vector3(0, 1, 0), transform.position - new Vector3(0, 1, 0));
    }

    // Inspector fields
    public Sprite Dot;
    public float Size = 0.2f;
    public float Delta = 0.5f;

    //Utility fields
    List<Vector3> positions = new List<Vector3>();
    List<GameObject> dots = new List<GameObject>();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (positions.Count > 0)
        {
            DestroyAllDots();
            positions.Clear();
        }
    }

    private void DestroyAllDots()
    {
        foreach (var dot in dots)
        {
            Destroy(dot);
        }
        dots.Clear();
    }

    GameObject GetOneDot()
    {
        var gameObject = new GameObject();
        gameObject.transform.localScale = Vector3.one * Size;
        gameObject.transform.parent = transform;

        var sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = Dot;
        return gameObject;
    }

    public void DrawDottedLine(Vector3 start, Vector3 end)
    {
        DestroyAllDots();

        Vector3 point = start;
        Vector3 direction = (end - start).normalized;

        while ((end - start).magnitude > (point - start).magnitude)
        {
            positions.Add(point);
            point += (direction * Delta);
        }

        Render();
    }

    private void Render()
    {
        foreach (var position in positions)
        {
            var g = GetOneDot();
            g.transform.position = position;
            dots.Add(g);
        }
    }

    // void OnAimAssist(InputValue value)
    // {
    //     // Debug.Log(input.Player.Movement.cancelled);
    //     Debug.Log( (int) value.ReadValue<float>() );
    // }


    // void OnAimAssist(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //         Debug.Log("pressed");
    //     else if (context.canceled)
    //         Debug.Log("released");
    //     else
    //         Debug.Log("whatthefuck");
    //     Debug.Log("IN ONAIMASSIST");
    // }

    void KeyDown()
    {
        show_assist = true;
    }

    void KeyUp()
    {
        show_assist = false;
    }

    void OnEnable()
    {
        controls.Capsule.Enable();
    }

    void OnDisable()
    {
        controls.Capsule.Disable();
    }
}
