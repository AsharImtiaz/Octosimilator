using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public GameObject toFollow;
    public float zOffset = -15.7f;
    public float yOffset = 10.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(toFollow.transform.position, Vector3.up, 30.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(toFollow.transform.position, Vector3.up, -30.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(toFollow.transform.position, transform.right, 30.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(toFollow.transform.position, transform.right, -30.0f * Time.deltaTime);
        }
        Vector3 offset = transform.forward;
        offset.y = 0.0f;
        offset = offset.normalized * zOffset;
        offset.y = yOffset;
        transform.position = Vector3.Lerp(transform.position, toFollow.transform.position + offset, Time.deltaTime);
        transform.LookAt(toFollow.transform);
    }
}
