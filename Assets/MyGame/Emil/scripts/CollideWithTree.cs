using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithTree : MonoBehaviour
{
    public TextMeshProUGUI treeCounterText;
    public GameObject winTextPrefab; 
    public Transform canvasTransform;
    private int treeCount;

    void Start()
    {
        UpdateTreeCount(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Tree"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(DelayedTreeCountUpdate());
        }
    }

    private IEnumerator DelayedTreeCountUpdate()
    {
        yield return new WaitForEndOfFrame(); 
        UpdateTreeCount(); 
    }

    void UpdateTreeCount()
    {
        treeCount = GameObject.FindGameObjectsWithTag("Tree").Length;
        treeCounterText.text = "Trees Left: " + treeCount; 

        if (treeCount == 0)
        {
            SceneManager.LoadScene("winscene");
        }
    }

  
}

