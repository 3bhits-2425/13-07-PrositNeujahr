using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithTree : MonoBehaviour
{
    public TextMeshProUGUI treeCounterText; // TMP Text zur Anzeige der Baumanzahl
    public GameObject winTextPrefab; // Prefab für den Gewonnen-Text
    public Transform canvasTransform; // Der Canvas, auf dem der Text erscheint
    private int treeCount;

    void Start()
    {
        UpdateTreeCount(); // Initialisiere die Baumanzahl
    }

    void OnCollisionEnter(Collision collision)
    {
        // Überprüfen, ob das Objekt mit dem Baum kollidiert
        if (collision.gameObject.CompareTag("Tree"))
        {
            Destroy(collision.gameObject); // Zerstöre den Baum
            StartCoroutine(DelayedTreeCountUpdate()); // Verzögerte Aktualisierung der Baumanzahl
        }
    }

    private IEnumerator DelayedTreeCountUpdate()
    {
        yield return new WaitForEndOfFrame(); // Warte bis zum Ende des aktuellen Frames
        UpdateTreeCount(); // Aktualisiere die Baumanzahl
    }

    void UpdateTreeCount()
    {
        treeCount = GameObject.FindGameObjectsWithTag("Tree").Length; // Aktualisiere den Baumzähler
        treeCounterText.text = "Trees Left: " + treeCount; // Aktualisiere den Text

        if (treeCount == 0)
        {
            SceneManager.LoadScene("winscene");
        }
    }

  
}

