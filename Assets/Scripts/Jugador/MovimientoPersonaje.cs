using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public Transform cam;
    float VerMouse;
    float HorMouse;
    float RotCam = 0.0f;
    public Transform player;

    public float VerSpeed;
    public float HorSpeed;

    public Stats stats;
    public CharacterController controller;
    public float speed;
    float x;
    float z;
    Vector3 move;
    public Joystick joystickMover;
    // Start is called before the first frame update
    void Start()
    {
        //Bloqueo del mouse
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        speed = stats.Velocity.ValorBase;
        OpcionesCamara();
        Movimiento();
    }
    
   
    void OpcionesCamara()
    {
        HorMouse = Input.GetAxis("Mouse X") * HorSpeed * Time.deltaTime;
        VerMouse = Input.GetAxis("Mouse Y") * VerSpeed * Time.deltaTime;

        RotCam -= VerMouse;
        RotCam = Mathf.Clamp(RotCam, -90f, 90f);
        transform.Rotate(0f, HorMouse, 0f);
        cam.localRotation = Quaternion.Euler(RotCam, 0f, 0f);
    }
    void Movimiento()
    {
        x = Input.GetAxis("Horizontal")+joystickMover.Horizontal;
        z = Input.GetAxis("Vertical")+joystickMover.Vertical;

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
