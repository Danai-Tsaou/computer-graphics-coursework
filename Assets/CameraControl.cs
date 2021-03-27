using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

        public float WalkingSpeed = 0.1f;

    void Update() {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * WalkingSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * WalkingSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * WalkingSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * WalkingSpeed;
        }
    }
}