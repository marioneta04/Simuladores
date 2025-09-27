using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LauncherController : MonoBehaviour
{
    [Header("UI")]
    public Slider angleSlider;      // vertical
    public Slider yawSlider;        // horizontal
    public Slider forceSlider;
    public TMP_Dropdown massDropdown;
    public Button shootButton;

    [Header("Cannon Parts")]
    public Transform cannonBarrel;   // el cilindro que rota con los sliders
    public Transform spawnPoint;
    public GameObject projectilePrefab;

    private float[] massValues = { 1f, 5f, 10f, 20f };

    private void Start()
    {
        // Conectar sliders y bot�n
        angleSlider.onValueChanged.AddListener(UpdatePitch);
        yawSlider.onValueChanged.AddListener(UpdateYaw);
        shootButton.onClick.AddListener(Shoot);

        // Inicializar rotaci�n seg�n sliders
        UpdatePitch(angleSlider.value);
        UpdateYaw(yawSlider.value);
    }

    public void UpdatePitch(float value)
    {
        // l�gica del chino: rotaci�n X = vertical slider
        cannonBarrel.localRotation = Quaternion.Euler(-value, yawSlider.value, 0f);
    }

    public void UpdateYaw(float value)
    {
        // l�gica del chino: rotaci�n Y = horizontal slider
        cannonBarrel.localRotation = Quaternion.Euler(-angleSlider.value, value, 0f);
    }

    private void Shoot()
    {
        if (projectilePrefab == null || spawnPoint == null) return;

        GameObject proj = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = massValues[massDropdown.value];
            rb.AddForce(spawnPoint.forward * forceSlider.value, ForceMode.Impulse);
        }
    }
}

