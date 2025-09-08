using UnityEngine;

public class ShotResultManager : MonoBehaviour
{
    public static ShotResultManager Instance;
    private void Awake() => Instance = this;

    public void RegisterResult(float time, Vector3 impactPoint, float relVel, float impulse, string targetName)
    {
        string report = $"Tiempo vuelo: {time:F2}s\n" +
                        $"Impacto en: {impactPoint}\n" +
                        $"Velocidad relativa: {relVel:F2}\n" +
                        $"Impulso: {impulse:F2}\n" +
                        $"Objeto golpeado: {targetName}";
        Debug.Log(report);

        // TODO: mostrar en UI final
    }
}
