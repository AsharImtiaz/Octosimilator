using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleNavigation : MonoBehaviour
{
    Rigidbody rbTip;
    Rigidbody[] rbsArm;
    public GameObject Tip;
    public GameObject Arm;
    public float ForceStrength = 20.0f;
    public AudioClip liftSound;
    AudioSource octoSource;

    void Start()
    {
        rbTip = Tip.GetComponent<Rigidbody>();
        rbsArm = Arm.GetComponentsInChildren<Rigidbody>();
        octoSource = GameObject.Find("Octopus").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get inputs to calculate force direction
        Vector3 direction = new Vector3();

        // Up and down relative to world space
        if(Input.GetKey(KeyCode.Q))
        {
            direction += Vector3.up;
            octoSource.Play();
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction += Vector3.down;
        }
        // horizontal movement relative to camera space
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 cameraDirection = Camera.main.transform.forward;
            cameraDirection.y = 0;
            direction += cameraDirection.normalized;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 cameraDirection = -Camera.main.transform.forward;
            cameraDirection.y = 0;
            direction += cameraDirection.normalized;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 cameraDirection = Camera.main.transform.right;
            cameraDirection.y = 0;
            direction += cameraDirection.normalized;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 cameraDirection = -Camera.main.transform.right;
            cameraDirection.y = 0;
            direction += cameraDirection.normalized;
        }

        MoveTentacle(direction);
    }

    void MoveTentacle(Vector3 direction)
    {
        // Apply force to tentacle tip
        rbTip.AddForce(direction.normalized * ForceStrength, ForceMode.Force);
        // Apply force (in fractions) to tentacle segments
        foreach (Rigidbody rb in rbsArm)
        {
            float factor = Vector3.Distance(transform.position, rb.transform.position) / Vector3.Distance(transform.position, rbTip.transform.position);
            rb.AddForce(direction.normalized * ForceStrength * factor, ForceMode.Force);
        }
    }
}
