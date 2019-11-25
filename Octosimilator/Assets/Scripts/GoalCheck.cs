using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCheck : MonoBehaviour
{
    public Text goalUI;             // reference to the GUIText for displaying the goal message
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
        // if the object entering the collider has the tag 'Grab', enable the GUIText with goal message and play the sound
        if (other.gameObject.tag == "Grab")              
        {
            Debug.Log("Goal Scored!!");
            goalUI.GetComponent<Text>().enabled = true;
            goalUI.GetComponent<AudioSource>().Play();
        }
    }
}
