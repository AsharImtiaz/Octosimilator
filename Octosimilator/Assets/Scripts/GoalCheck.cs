using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCheck : MonoBehaviour
{
    public Text goalUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Grab")
        {
            Debug.Log("Goal Scored!!");
            goalUI.enabled = true;
            goalUI.GetComponent<AudioSource>().Play();
        }
    }
}
