using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    public CharacterJoint[] joints;
    public float swingLimitSpring = 0.0f;
    public float twistLimitSpring = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        joints = GetComponentsInChildren<CharacterJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (CharacterJoint cj in joints)
        {
            SoftJointLimitSpring swingSpring = cj.swingLimitSpring;
            swingSpring.spring = swingLimitSpring;

            SoftJointLimitSpring twistSpring = cj.twistLimitSpring;
            twistSpring.spring = twistLimitSpring;

            cj.swingLimitSpring = swingSpring;
            cj.twistLimitSpring = twistSpring;
        }
    }
}
