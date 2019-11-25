using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSelector : MonoBehaviour
{
    public TentacleNavigation[] tentacleNavigations;
    public Material defaultMaterial;
    public Material selectedMaterial;
    int input;
    MeshRenderer[] meshRenderers;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderers = new MeshRenderer[tentacleNavigations.Length];
        for (int i = 0; i < tentacleNavigations.Length; ++i)
        {
            tentacleNavigations[i].enabled = false;
            MeshRenderer rend = tentacleNavigations[i].Tip.GetComponentInChildren<MeshRenderer>();
            if (rend)
            {
                rend.material = defaultMaterial;
            }
            meshRenderers[i] = rend;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get input 1 to 4
        input = -1;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            input = 1;
            tipClamp.selectedArm = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            input = 2;
            tipClamp.selectedArm = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            input = 3;
            tipClamp.selectedArm = input;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            input = 4;
            tipClamp.selectedArm = input;
        }
        if (input > 0)
        {
            // Reset all materials to default and set tentacles inactive
            for (int i = 0; i < tentacleNavigations.Length; ++i)
            {
                tentacleNavigations[i].enabled = false;
                if (meshRenderers[i])
                {
                    meshRenderers[i].material = defaultMaterial;
                }
            }
            // Set selected tentacle to be active and change material to highlight
            if (input <= tentacleNavigations.Length)
            {
                int index = input - 1;
                tentacleNavigations[index].enabled = true;
                if (meshRenderers[index])
                {
                    meshRenderers[index].material = selectedMaterial;
                }
            }
        }
    }
}
