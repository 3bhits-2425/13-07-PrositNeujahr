using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithTree : MonoBehaviour
{
    public TextMeshProUGUI treeCounterText; // TMP Text zur Anzeige der Baumanzahl
    public GameObject winTextPrefab; // Prefab f�r den Gewonnen-Text
    public Transform canvasTransform; // Der Canvas, auf dem der Text erscheint
    private int treeCount;

    void Start()
    {
        UpdateTreeCount(); // Initialisiere die Baumanzahl
    }

    void OnCollisionEnter(Collision collision)
    {
        // �berpr�fen, ob das Objekt mit dem Baum kollidiert
        if (collision.gameObject.CompareTag("Tree"))
        {
            Destroy(collision.gameObject); // Zerst�re den Baum
            StartCoroutine(DelayedTreeCountUpdate()); // Verz�gerte Aktualisierung der Baumanzahl
        }
    }

    private IEnumerator DelayedTreeCountUpdate()
    {
        yield return new WaitForEndOfFrame(); // Warte bis zum Ende des aktuellen Frames
        UpdateTreeCount(); // Aktualisiere die Baumanzahl
    }

    void UpdateTreeCount()
    {
        treeCount = GameObject.FindGameObjectsWithTag("Tree").Length; // Aktualisiere den Baumz�hler
        treeCounterText.text = "Trees Left: " + treeCount; // Aktualisiere den Text

        if (treeCount == 0)
        {
            SceneManager.LoadScene("winscene");
        }
    }

  
}

