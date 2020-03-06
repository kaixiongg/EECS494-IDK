using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadExperiment : MonoBehaviour
{

    public int gamepad_index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad active_gamepad = Gamepad.current;

        float horizontal_val = active_gamepad.leftStick.x.ReadValue();
        // Debug.Log(horizontal_val);
        
        float vertical_val = active_gamepad.leftStick.y.ReadValue();
        // Debug.Log(vertical_val);

        bool a_pressed_this_frame = active_gamepad.aButton.wasPressedThisFrame;
        Debug.Log(a_pressed_this_frame);
        bool b_pressed_this_frame = active_gamepad.bButton.wasPressedThisFrame;
        Debug.Log(b_pressed_this_frame);
        List<Gamepad> game_pads = new List<Gamepad>(Gamepad.all);

        // foreach(Gamepad gp in game_pads)
        // {
        //     Debug.Log(gp.name);
        //     Debug.Log("yay");
        // }
            
    }
}
