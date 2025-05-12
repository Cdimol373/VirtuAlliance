using UnityEngine;

public class PlaceTargetOnPlane : MonoBehaviour
{
    public GameObject targetPrefab;
    public float distanceFromCamera = 7f;

    void Start()
    {
        if (targetPrefab == null) return;

        // Posición frente a la cámara
        Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;

        // Usar la rotación del prefab tal cual está en el editor
        Quaternion targetRotation = targetPrefab.transform.rotation; ;

        Instantiate(targetPrefab, targetPosition, targetRotation);
    }
}


