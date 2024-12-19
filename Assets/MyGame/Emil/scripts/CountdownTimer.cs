using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeLimit = 30f; // Zeit in Sekunden
    private float timeRemaining; // Verbleibende Zeit
    public Text timerText;       // Textfeld für die Anzeige der Zeit

    void Start()
    {
        // Timer mit dem festgelegten Limit initialisieren
        timeRemaining = timeLimit;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // Verbleibende Zeit verringern
            timeRemaining -= Time.deltaTime;

            // Zeit im Textfeld aktualisieren (auf ganze Zahlen gerundet)
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            // Timer ist abgelaufen
            timerText.text = "Time: 0";
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        // Aktionen ausführen, wenn der Timer abgelaufen ist
        Debug.Log("Die Zeit ist abgelaufen!");
        // Hier kannst du z. B. das Spiel pausieren oder den Spieler verlieren lassen.
    }
}
