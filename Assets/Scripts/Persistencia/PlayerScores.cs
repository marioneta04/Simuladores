using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class PlayerScores : MonoBehaviour
{
    public Text ScoreText;
    public InputField nameText;

    private System.Random random = new System.Random();

    public static int playerScore;
    public static string playerName;

    private void Start()
    {
        playerScore = random.Next(0, 101);
        ScoreText.text = "Score: " + playerScore;

    }

    public void OnSubmit ()
    {
        playerName = nameText.text;
        PostToDataBase();
    }

    private void PostToDataBase()
    {
        User user = new User();
        RestClient.Post("https://simuladores-58820-default-rtdb.firebaseio.com/usuarios.json", user)
            .Then(response => Debug.Log("Datos enviados correctamente"))
            .Catch(error => Debug.LogError("Error al enviar: " + error));
    }

}
