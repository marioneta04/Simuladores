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

    [Header("References")]
    public Transform spawnPoint;
    public GameObject projectilePrefab;

    private void Start()
    {
        shootButton.onClick.AddListener(Shoot);
    }

    void Shoot()
    {
        // Crear proyectil
        GameObject proj = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        // Masa según dropdown
        float mass = float.Parse(massDropdown.options[massDropdown.value].text);
        rb.mass = mass;

        // Calcular ángulo y fuerza
        float angle = angleSlider.value * Mathf.Deg2Rad;
        float force = forceSlider.value;

        Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        rb.AddForce(dir * force, ForceMode.Impulse);
    }
}
