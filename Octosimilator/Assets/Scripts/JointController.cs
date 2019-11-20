using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    public CharacterJoint[] joints;
    public float swingLimitSpring = 0.0f;
    public float twistLimitSpring = 0.0f;

    private float[] lowTwistLimits;
    private float[] highTwistLimits;
    private float[] swing1limits;
    private float[] swing2limits;

    public bool setLimitsZero = false;
    private bool limitsAreZero = false;

    // Start is called before the first frame update
    void Start()
    {
        joints = GetComponentsInChildren<CharacterJoint>();
        int jointCount = joints.Length;
        lowTwistLimits = new float[jointCount];
        highTwistLimits = new float[jointCount];
        swing1limits = new float[jointCount];
        swing2limits = new float[jointCount];
        for (int i = 0; i < jointCount; ++i)
        {
            lowTwistLimits[i] = joints[i].lowTwistLimit.limit;
            highTwistLimits[i] = joints[i].highTwistLimit.limit;
            swing1limits[i] = joints[i].swing1Limit.limit;
            swing2limits[i] = joints[i].swing2Limit.limit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < joints.Length; ++i)
        {
            SoftJointLimitSpring swingSpring = joints[i].swingLimitSpring;
            swingSpring.spring = swingLimitSpring;

            SoftJointLimitSpring twistSpring = joints[i].twistLimitSpring;
            twistSpring.spring = twistLimitSpring;

            joints[i].swingLimitSpring = swingSpring;
            joints[i].twistLimitSpring = twistSpring;

            if (setLimitsZero && !limitsAreZero)
            {
                SoftJointLimit lowTwist = joints[i].lowTwistLimit;
                lowTwist.limit = 0;
                joints[i].lowTwistLimit = lowTwist;
                SoftJointLimit highTwist = joints[i].highTwistLimit;
                highTwist.limit = 0;
                joints[i].highTwistLimit = highTwist;
                SoftJointLimit swing1 = joints[i].swing1Limit;
                swing1.limit = 0;
                joints[i].swing1Limit = swing1;
                SoftJointLimit swing2 = joints[i].swing2Limit;
                swing2.limit = 0;
                joints[i].swing2Limit = swing2;
            }
            else if (!setLimitsZero && limitsAreZero)
            {
                SoftJointLimit lowTwist = joints[i].lowTwistLimit;
                lowTwist.limit = lowTwistLimits[i];
                joints[i].lowTwistLimit = lowTwist;
                SoftJointLimit highTwist = joints[i].highTwistLimit;
                highTwist.limit = highTwistLimits[i];
                joints[i].highTwistLimit = highTwist;
                SoftJointLimit swing1 = joints[i].swing1Limit;
                swing1.limit = swing1limits[i];
                joints[i].swing1Limit = swing1;
                SoftJointLimit swing2 = joints[i].swing2Limit;
                swing2.limit = swing2limits[i];
                joints[i].swing2Limit = swing2;
            }
        }
    }
}
