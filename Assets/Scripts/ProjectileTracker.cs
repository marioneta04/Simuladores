using UnityEngine;

public class ProjectileTracker : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPos;
    private float startTime;
    private bool impactRegistered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (impactRegistered) return;
        impactRegistered = true;

        float flightTime = Time.time - startTime;
        Vector3 impactPoint = transform.position;
        float relativeSpeed = collision.relativeVelocity.magnitude;
        float impulse = collision.impulse.magnitude;

        
        ShotResultManager.Instance.RegisterResult(flightTime, impactPoint, relativeSpeed, impulse, collision.collider.name);

        Destroy(gameObject, 2f);
    }
}
