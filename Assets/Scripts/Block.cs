using UnityEngine;

public class Block : MonoBehaviour
{
    private bool hit = false; 
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hit && collision.gameObject.CompareTag("Projectile"))
        {
            hit = true;

            Rigidbody projRb = collision.rigidbody;
            if (projRb != null)
            {
                float relVel = collision.relativeVelocity.magnitude;
                float impulse = collision.impulse.magnitude;
                Vector3 impactPoint = collision.contacts[0].point;
                float time = Time.timeSinceLevelLoad;

                
                ShotResultManager.Instance.RegisterResult(time, impactPoint, relVel, impulse, gameObject.name);
            }
        }
    }
}
