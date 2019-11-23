using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipClamp : MonoBehaviour
{
    public static int selectedArm;
    // Start is called before the first frame update
    void Start()
    {
        selectedArm = -1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(selectedArm);
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Debug.Log("Unclamped!");
            unclampArm();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Climb")
        {
            clampArm();
            Debug.Log("Grabhold reached");
        }
    }

    void clampArm()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void unclampArm()
    {
        if (selectedArm == 1)
        {
            Debug.Log("In Arm 2");
            GameObject.Find("Tip (1)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip (1)").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (selectedArm == 2)
        {
            Debug.Log("In Arm 2");
            GameObject.Find("Tip (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip (2)").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (selectedArm == 3)
        {
            Debug.Log("In Arm 3");
            GameObject.Find("Tip (3)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip (3)").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (selectedArm == 4)
        {
            Debug.Log("In Arm 4");
            GameObject.Find("Tip (4)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip (4)").GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
