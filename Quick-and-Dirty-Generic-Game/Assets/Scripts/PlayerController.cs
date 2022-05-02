using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool moveXY = true;      // T == XY translation; F == yaw & forward.
    public bool moveForce = false;  // T == move with force applied to Rigidbody; F == move with transform.Translate.
 
    public float speed;
    public float yawRate;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if (moveForce)
        {
            // Move by applying forces to the Rigidbody.
        }
        else
        {
            // Move with transform.Translate
            if (moveXY)
            {
                // Move by translations on the horizontal & vertical axes,
                // speed controls both axes.
                transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
                transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            }
            else
            {
                // Rotate around Y axis, Translate on Player Z axis.
                transform.Rotate(Vector3.up, horizontalInput * yawRate * Time.deltaTime);
                transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            }
        }
    }
}
