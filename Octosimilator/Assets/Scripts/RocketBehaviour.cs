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
        // Make Rocket always face upwards
        transform.eulerAngles = Vector3.zero;
    }

    public void LaunchRocket()
    {
        // Get rigidbody in parent
        parentrb = transform.parent.GetComponent<Rigidbody>();
        if (isFlying)
        {
            return;
        }
        // Play particles if not null
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
            // Apply force to parent while attached to e.g. tentacle
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
        // Set paretn rigidbody to null when let go
        parentrb = null;
    }
}
