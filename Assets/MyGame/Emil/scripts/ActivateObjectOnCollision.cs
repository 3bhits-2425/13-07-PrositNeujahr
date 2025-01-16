using UnityEngine;

public class ActivateObjectOnCollision : MonoBehaviour
{
    public GameObject objectToActivate; // Das GameObject, das aktiviert werden soll

    private void OnCollisionEnter(Collision collision)
    {
        // Überprüfen, ob das kollidierende Objekt der "Button" ist
        if (collision.gameObject.CompareTag("Button"))
        {
            // Aktiviere das GameObject, wenn es deaktiviert ist
            if (!objectToActivate.activeSelf)
            {
                objectToActivate.SetActive(true);
                Debug.Log("Object activated!");
            }
        }
    }
}