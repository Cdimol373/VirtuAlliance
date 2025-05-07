using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceTarget : MonoBehaviour
{
    public GameObject targetPrefab;  // Prefab de la diana
    private ARRaycastManager raycastManager;  // Componente Raycast
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // Verifica si se tocó la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Vector2 touchPosition = Input.GetTouch(0).position;

            // Raycast de la pantalla hacia el mundo
            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                // Si el raycast toca un plano, coloca la diana allí
                Pose hitPose = hits[0].pose;
                Instantiate(targetPrefab, hitPose.position, hitPose.rotation);
            }
        }
    }
}
