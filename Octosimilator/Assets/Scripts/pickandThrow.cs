using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickandThrow : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPicked;          // confirm if object is picked or not
    GameObject parentTemp;          
    Vector3 objPosition;
    Vector3 throwForce;         //amount of force to apply when throwing
    bool buttonCheck;

    Rigidbody rigidb;
    Collider[] colliders;

    public UnityEvent onPickUp;
    public UnityEvent onThrow;

    GameObject octoHead;
    void Start()
    {
        isPicked = false;
        throwForce = Vector3.zero;
        buttonCheck = false;

        rigidb = GetComponent<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();

        octoHead = GameObject.Find("OctoBodyRestructured");
    }

    // Update is called once per frame
    void Update()
    {
        // grabbable object has collided
        if(isPicked)
        {
            //Picking object
            if (Input.GetKey(KeyCode.LeftShift) && buttonCheck == false)
            {
                Debug.Log("Picking");
                pickObject();
                buttonCheck = true;
            }
            //Throwing object
            else if (Input.GetKeyDown(KeyCode.LeftShift) && buttonCheck == true)
            {
                Debug.Log("Throwing");
                throwObject();
                octoHead.GetComponent<AudioSource>().Play();
                buttonCheck = false;
            }
        }
        else
        {
        
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // checking if grabbable objects have collided
        if(collision.gameObject.tag == "Tip")
        {
            parentTemp = collision.gameObject;
            isPicked = true;
        }
        else
        {
            isPicked = false;
        }
    }

    // function to pick object
    void pickObject()
    {
        Debug.Log("Object picked");
        gameObject.transform.SetParent(parentTemp.transform, true);         // to attach object make it child of colliding tip

        rigidb.detectCollisions = true;
        foreach (Collider col in colliders)
        {
            //col.enabled = false;
        }
        rigidb.isKinematic = true;
        rigidb.velocity = Vector3.zero;
        rigidb.angularVelocity = Vector3.zero;
        
        if (onPickUp != null)
        {
            onPickUp.Invoke();
        }
    }

    // function to throw object
    void throwObject()
    {
        Debug.Log("Object thrown... please");

        gameObject.transform.SetParent(null, true);             // to release object set parent to null
        rigidb.isKinematic = false;
        throwForce = parentTemp.GetComponent<Rigidbody>().velocity;             // amount of force equal to the velocity of tip the object was previously attached to
        rigidb.velocity = Vector3.zero;
        rigidb.angularVelocity = Vector3.zero;
        rigidb.AddForce(throwForce, ForceMode.Impulse);             //applying force to throw
        foreach (Collider col in colliders)
        {
            //col.enabled = true;
        }
        isPicked = false;
        if (onThrow != null)
        {
            onThrow.Invoke();
        }
    }
}
