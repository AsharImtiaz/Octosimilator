using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickandThrow : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPicked;
    GameObject parentTemp;
    Vector3 objPosition;
    Vector3 throwForce;
    void Start()
    {
        isPicked = false;
        throwForce = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPicked)
        {
            pickObject();
            //gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.transform.SetParent(parentTemp.transform);
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                throwObject();
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
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().detectCollisions = true;
    }

    void throwObject()
    {
        Debug.Log("Object thrown... please");
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        throwForce = parentTemp.GetComponent<Rigidbody>().velocity;
        gameObject.transform.SetParent(null);
        gameObject.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
        isPicked = false;
    }
}
