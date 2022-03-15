using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public Transform cam;
    float VerMouse;
    float HorMouse;
    float RotCam = 0.0f;

    public float VerSpeed;
    public float HorSpeed;


    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
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
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
