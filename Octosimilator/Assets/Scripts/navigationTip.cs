using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigationTip : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource musicSource;
    Rigidbody kinematicOption;
    Rigidbody connectedbodykinematicOption;
    public GameObject connectedBody;
    void Start()
    {
        kinematicOption = GetComponent<Rigidbody>();
        connectedbodykinematicOption = connectedBody.GetComponent<Rigidbody>();
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.Space))
       {
            raiseTentacle();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                musicSource.Play();
            }
            
       }
       else
       {
            musicSource.Stop();
            kinematicOption.isKinematic = false;
            connectedbodykinematicOption.isKinematic = false;
       }
    }

    void raiseTentacle()
    {
        
        Debug.Log("Rising");
        kinematicOption.isKinematic = true;
        connectedbodykinematicOption.isKinematic = true;
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
    }
}
