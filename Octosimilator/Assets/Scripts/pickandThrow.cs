using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickAndThrow : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPicked;
    GameObject parentTemp;
    Vector3 objPosition;
    Vector3 throwForce;
    bool buttonCheck;

    bool isChecked;

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
        if(isPicked)
        {
            //Debug.Log("Object touching");
            if (Input.GetKeyDown(KeyCode.LeftShift) && buttonCheck == false)
            {
                Debug.Log("Picking");
                pickObject();
                buttonCheck = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && buttonCheck == true)
            {
                Debug.Log("Throwing");
                throwObject();
                octoHead.GetComponent<AudioSource>().Play();
                buttonCheck = false;
                //Throw

            }
        }
        else
        {
            //objPosition = gameObject.transform.position;
            //gameObject.transform.SetParent(null);
            //gameObject.GetComponent<Rigidbody>().useGravity = true;
            //gameObject.transform.position = objPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
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

    void pickObject()
    {
        Debug.Log("Object picked");
        rigidb.detectCollisions = true;
        foreach (Collider col in colliders)
        {
            //col.enabled = false;
        }
        //gameObject.GetComponent<CapsuleCollider>().enabled = false;
        rigidb.isKinematic = true;
        rigidb.velocity = Vector3.zero;
        rigidb.angularVelocity = Vector3.zero;
        gameObject.transform.SetParent(parentTemp.transform, true);
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
        
        if (onPickUp != null)
        {
            onPickUp.Invoke();
        }
    }

    void throwObject()
    {
        Debug.Log("Object thrown... please");
        
        rigidb.isKinematic = false;
        throwForce = parentTemp.GetComponent<Rigidbody>().velocity;
        gameObject.transform.SetParent(null, true);
        rigidb.velocity = Vector3.zero;
        rigidb.angularVelocity = Vector3.zero;
        rigidb.AddForce(throwForce, ForceMode.Impulse);
        foreach (Collider col in colliders)
        {
            //col.enabled = true;
        }
        //gameObject.GetComponent<CapsuleCollider>().enabled = true;
        isPicked = false;

        if (onThrow != null)
        {
            onThrow.Invoke();
        }
    }
}
