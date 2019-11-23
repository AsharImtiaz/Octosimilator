using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSelector : MonoBehaviour
{
    public TentacleNavigation[] tentacleNavigations;

    // Start is called before the first frame update
    void Start()
    {
        foreach(TentacleNavigation tenNav in tentacleNavigations)
        {
            tenNav.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int input = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            input = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            input = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            input = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            input = 4;
        }
        if (input > 0)
        {
            foreach (TentacleNavigation tenNav in tentacleNavigations)
            {
                tenNav.enabled = false;
            }
            if (input <= tentacleNavigations.Length)
            {
                tentacleNavigations[input - 1].enabled = true;
            }
        }
    }
}
