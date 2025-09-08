using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LauncherController : MonoBehaviour
{
    [Header("UI")]
    public Slider angleSlider;
    public Slider forceSlider;
    public TMP_Dropdown massDropdown;
    public Button shootButton;
    public Slider yawSlider;

    [Header("References")]
    public Transform spawnPoint;
    public GameObject projectilePrefab;

    private void Start()
    {
        shootButton.onClick.AddListener(Shoot);
    }

    void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        float mass = float.Parse(massDropdown.options[massDropdown.value].text);
        rb.mass = mass;

        float angle = angleSlider.value * Mathf.Deg2Rad;   // vertical
        float yaw = yawSlider.value * Mathf.Deg2Rad;       // horizontal
        float force = forceSlider.value;

        Vector3 dir = new Vector3(
            Mathf.Cos(angle) * Mathf.Cos(yaw),
            Mathf.Sin(angle),
            Mathf.Cos(angle) * Mathf.Sin(yaw)
        );

        rb.AddForce(dir * force, ForceMode.Impulse);
    }
}
