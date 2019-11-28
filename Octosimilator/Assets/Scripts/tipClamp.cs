using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipClamp : MonoBehaviour
{
    public static int selectedArm;          //variable to keep in check which arm is curretly selected
    // Start is called before the first frame update
    void Start()
    {
        selectedArm = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))           // with the press of left ctrl unclamp tip of tentacle from wall
        {
            Debug.Log("Unclamped!");
            unclampArm();           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Climb")         // if collision with the object has tag 'Climb' latch on automatically
        {
            clampArm();
            Debug.Log("Grabhold reached");
        }
    }

    void clampArm()         // function to clamp the tip of the tentacle to the point where it collided with the wall
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void unclampArm()           // unclamp or release the arm that is currently selected from the wall 
    {
        if (selectedArm == 1)
        {
            //Debug.Log("In Arm 1");
            GameObject.Find("Tip Container (1)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip Container (1)").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (selectedArm == 2)
        {
            //Debug.Log("In Arm 2");
            GameObject.Find("Tip Container (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip Container (2)").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (selectedArm == 3)
        {
            //Debug.Log("In Arm 3");
            GameObject.Find("Tip Container (3)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip Container (3)").GetComponent<Rigidbody>().isKinematic = false;
        }
        if (selectedArm == 4)
        {
            //Debug.Log("In Arm 4");
            GameObject.Find("Tip Container (4)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GameObject.Find("Tip Container (4)").GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
