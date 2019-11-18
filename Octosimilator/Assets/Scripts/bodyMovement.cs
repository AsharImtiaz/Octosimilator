using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyMovement : MonoBehaviour
{
    public GameObject particle;
    public float thresh = 1.0f;
    public float input_force = 1.0f;

    Mesh mesh;
    Vector3[] vertices;
    GameObject[] particles;
    Transform childObj;

    void AddSpring(int i0, int i1)
    {
        SpringJoint sj = particles[i0].AddComponent<SpringJoint>() as SpringJoint;
        sj.connectedBody = particles[i1].GetComponent<Rigidbody>();
        sj.spring = 10;
        sj.damper = 0.75f;
        sj.autoConfigureConnectedAnchor = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter filter = GetComponentInChildren<MeshFilter>();
        mesh = filter.mesh;
        childObj = filter.transform;
        vertices = mesh.vertices;
        particles = new GameObject[vertices.Length];

        Debug.Log("mesh has " + vertices.Length + " vertices");
        Debug.Log("mesh has " + mesh.GetIndexCount(0) / 3 + " faces");

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 pos = childObj.TransformPoint(transform.TransformPoint(vertices[i]));
            GameObject go = Instantiate(particle, pos, Quaternion.identity);
            particles[i] = go;
        }

        for (int i = 0; i < particles.Length; i++)
        {
            float maxDist = 0;
            int maxDistIndex = 0;
            Vector3 pos0 = particles[i].transform.position;

            for (int j = 0; j < particles.Length; j++)
            {
                if (i == j) continue;

                Vector3 pos1 = particles[j].transform.position;
                float dist = (pos1 - pos0).magnitude;
                if (dist < thresh)
                    AddSpring(i, j);

                if (dist > maxDist)
                {

                }
            }
        }

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(-input_force, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(input_force, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(0, 0, input_force);

        if (Input.GetKey(KeyCode.DownArrow))
            foreach (GameObject p in particles)
                p.GetComponent<Rigidbody>().AddForce(0, 0, -input_force);


        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 pos = childObj.InverseTransformPoint(particles[i].transform.position);
            vertices[i] = pos;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
