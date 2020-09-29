using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    private float mouseHorizontalSensitivity = 150;
    private float mouseVerticalSensitivity = 150f;

    public Transform playerBody;

    private float xRotation = 0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {


        float mouseX = Input.GetAxis("Mouse X") * this.mouseHorizontalSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * this.mouseVerticalSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }


}
