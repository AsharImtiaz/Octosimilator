using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public ParticleSystem particles;
    public float flightTime = 30.0f;
    public float forceMagnitude = 20.0f;

    private Rigidbody rigidb;
    private Rigidbody parentrb;
    private bool isFlying;

    private void Start()
    {
        rigidb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.eulerAngles = Vector3.zero;
    }

    public void LaunchRocket()
    {
        parentrb = transform.parent.GetComponent<Rigidbody>();
        if (isFlying)
        {
            return;
        }
        if (particles != null)
        {
            particles.Play();
        }       
        StartCoroutine(RocketFlyRoutine());
    }

    private IEnumerator RocketFlyRoutine()
    {
        isFlying = true;
        float elapsedTime = 0.0f;
        Rigidbody activeBody = null;
        while (elapsedTime < flightTime)
        {
            activeBody = parentrb ? parentrb : rigidb;
            activeBody.AddForce(transform.up * forceMagnitude, ForceMode.Acceleration);
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        particles.Stop();
        isFlying = false;
    }

    public void ThrowRocket()
    {
        parentrb = null;
    }
}
