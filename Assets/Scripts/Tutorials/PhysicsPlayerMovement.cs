using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerMovement : MonoBehaviour
{

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float run = Input.GetAxis("Fire1") > 0 ? 10.0f : 3.0f;


        transform.Translate(Vector3.left * vertical * run * Time.deltaTime);
        transform.Translate(Vector3.forward * horizontal * run * Time.deltaTime);
    }
}
