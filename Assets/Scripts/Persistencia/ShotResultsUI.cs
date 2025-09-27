using Proyecto26;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using Newtonsoft.Json; 
using System.Collections.Generic;
using System.Linq;


public class ShotResultsUI : MonoBehaviour
{
    [Header("UI References")]
    public Button showResultsButton;
    public Transform contentParent; // Content con Vertical Layout Group
    public GameObject rowPrefab;    // Prefab de la fila

    private string dbUrl = "https://simuladores-58820-default-rtdb.firebaseio.com/shots.json";

    private void Start()
    {
        showResultsButton.onClick.AddListener(LoadResults);
    }

    public void LoadResults()
    {
        Debug.Log("LoadResults called");

        // GET de Firebase
        RestClient.Get(dbUrl).Then(response =>
        {
            if (string.IsNullOrEmpty(response.Text))
            {
                Debug.Log("No hay datos guardados.");
                return;
            }

            // Deserializar a diccionario
            var resultsDict = JsonConvert.DeserializeObject<Dictionary<string, Shot>>(response.Text);

            if (resultsDict == null || resultsDict.Count == 0)
            {
                Debug.Log("No hay disparos en la base.");
                return;
            }

            // Limpiar contenido anterior
            foreach (Transform child in contentParent)
                Destroy(child.gameObject);

            // Tomar los últimos 4 disparos por tiempo
            var lastShots = resultsDict.Values
                .OrderByDescending(s => s.time) // Asegurate de tener `time` en Shot
                .Take(4)
                .ToList();

            // Instanciar fila por cada disparo
            foreach (var shot in lastShots)
            {
                GameObject row = Instantiate(rowPrefab, contentParent);
                var texts = row.GetComponentsInChildren<TextMeshProUGUI>();

                texts[0].text = "Angle: " + shot.angle.ToString("F1");
                texts[1].text = "Force: " + shot.force.ToString("F1");
                texts[2].text = "Mass: " + shot.mass.ToString("F1");
                texts[3].text = "Hit: " + (shot.hitTarget ? "si" : "no");
                texts[4].text = "Dist: " + shot.distance.ToString("F1");
            }

        })
        .Catch(error => Debug.LogError("GET Error: " + error));
    }
}

