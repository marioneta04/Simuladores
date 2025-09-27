using Proyecto26;
using UnityEngine;

public class ShotResultManager : MonoBehaviour
{
    public static ShotResultManager Instance;
    public LauncherController launcher; // referencia al launcher

    private void Awake() => Instance = this;

    public void RegisterResult(float time, Vector3 impactPoint, float relVel, float impulse, string targetName)
    {
        Debug.Log($"Impacto en {targetName} | Velocidad: {relVel:F2} | Impulso: {impulse:F2}");

        Shot shot = new Shot(launcher, impactPoint, relVel, impulse, targetName);

        // Enviar a Firebase usando RestClient
        RestClient.Post("https://simuladores-58820-default-rtdb.firebaseio.com/shots.json", shot)
            .Then(response => Debug.Log("Disparo guardado en Firebase correctamente"))
            .Catch(error => Debug.LogError("Error al guardar disparo: " + error));
    }
}
