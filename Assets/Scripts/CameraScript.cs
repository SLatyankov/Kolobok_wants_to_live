using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] Joystick joystick;

    void Update()
    {
        if (GameManager.Instance.isAnotherControllerOn)
        {
            float horizontalInput;
            if (DataBox.Instance.isPC)
            {
                horizontalInput = Input.GetAxis("Horizontal");
            }
            else
            {
                horizontalInput = joystick.Horizontal;
            }
            transform.Rotate(Vector3.up, horizontalInput * rotateSpeed * Time.deltaTime);
        }
    }
}
