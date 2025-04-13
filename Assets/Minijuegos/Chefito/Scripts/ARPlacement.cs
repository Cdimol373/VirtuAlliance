using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{
    public GameObject objectToPlace;
    public ARRaycastManager raycastManager;

    private GameObject spawnedObject;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0 && spawnedObject == null)
        {
            Touch touch = Input.GetTouch(0);
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            }
        }
    }
}
