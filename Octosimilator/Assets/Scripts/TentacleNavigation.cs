using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    //AudioSource musicSource;
    Rigidbody rbTip;
    Rigidbody[] rbsArm;
    //Transform parent;
    public GameObject Tip;
    public GameObject Arm;
    //Rigidbody connectedbodykinematicOption;
    //public GameObject connectedBody;
    public float ForceStrength = 20.0f;
    //public float TorqueStrength = 20.0f;
    void Start()
    {
        //parent = transform.parent;
        rbTip = Tip.GetComponent<Rigidbody>();
        rbsArm = Arm.GetComponentsInChildren<Rigidbody>();
        //connectedbodykinematicOption = connectedBody.GetComponent<Rigidbody>();
        //musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3();
        //Vector3 torque = new Vector3();
        if(Input.GetKey(KeyCode.Q))
        {
            direction += Vector3.up;
            //torque += transform.TransformDirection(Vector3.left).normalized;
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction += Vector3.down;
            //torque += transform.TransformDirection(Vector3.right).normalized;
        }
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbTip.isKinematic = !rbTip.isKinematic;
        }

        MoveTentacle(direction);
    }

    void MoveTentacle(Vector3 direction)
    {
        Debug.Log("Rising");
        //kinematicOption.isKinematic = true;
        //connectedbodykinematicOption.isKinematic = true;
        //transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        rbTip.AddForce(direction.normalized * ForceStrength, ForceMode.Force);
        //rbTip.AddTorque(torque.normalized * TorqueStrength, ForceMode.Force);
        foreach (Rigidbody rb in rbsArm)
        {
            float factor = Vector3.Distance(transform.position, rb.transform.position) / Vector3.Distance(transform.position, rbTip.transform.position);
            rb.AddForce(direction.normalized * ForceStrength * factor, ForceMode.Force);
            //rb.AddTorque(torque.normalized * TorqueStrength, ForceMode.Force);
        }
    }
}
