using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{

    public GameObject cursorChildObject;
    public GameObject objectToPlace;
    public ARRaycastManager RaycastManager;
    public bool useCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadObj(GameObject obj){
        objectToPlace = obj;
    }
    // Update is called once per frame
    void Update()
    {
        if(useCursor){
            updateCursor();
        }
        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began){
            if(useCursor)
            {
                GameObject.Instantiate(objectToPlace,transform.position,transform.rotation);
            }
            else
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                RaycastManager.Raycast(Input.GetTouch(0).position,hits,UnityEngine.XR.ARSubsystems.TrackableType.Planes);
                if(hits.Count > 0){
                    GameObject.Instantiate(objectToPlace,hits[0].pose.position, hits[0].pose.rotation);
                }
            }
        }
    }
    void updateCursor(){
        Vector2 screenPosition  = Camera.main.ViewportToScreenPoint(new Vector2(0.5f,0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        RaycastManager.Raycast(screenPosition,hits,UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        if(hits.Count > 0){
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
