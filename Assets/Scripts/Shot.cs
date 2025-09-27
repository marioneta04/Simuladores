using UnityEngine;

public class Shot 
{
    public float angle;
    public float yaw;
    public float force;
    public float mass;
    public bool hitTarget;
    public float distance;
    public int objectsHit;
    public Vector3 impactPoint;
    public float relativeSpeed;
    public float impulse;
    public string targetName;
    public float time; // <--- tiempo del disparo

    public Shot() { } // Necesario para deserialización

    public Shot(LauncherController launcher, Vector3 impactPoint, float relVel, float impulse, string targetName, bool hitTarget = true, int objectsHit = 1)
    {
        this.angle = launcher.angleSlider.value;
        this.yaw = launcher.yawSlider.value;
        this.force = launcher.forceSlider.value;
        this.mass = launcher.massDropdown.options[launcher.massDropdown.value].text != ""
                    ? float.Parse(launcher.massDropdown.options[launcher.massDropdown.value].text)
                    : 1f;
        this.impactPoint = impactPoint;
        this.relativeSpeed = relVel;
        this.impulse = impulse;
        this.targetName = targetName;
        this.hitTarget = hitTarget;
        this.distance = Vector3.Distance(launcher.spawnPoint.position, impactPoint);
        this.objectsHit = objectsHit;
        this.time = Time.time; // <--- guardamos el momento del disparo
    }
}
