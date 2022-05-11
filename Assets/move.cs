using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class move : MonoBehaviour
{
    public Button Up; 
    public Button Down; 
    public Button Left; 
    public Button Right; 
    public GameObject myObj;
    // public GameObject table;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void moveObj(GameObject table){
        myObj = table;
    }
    // Update is called once per frame
    void Update()
    {
        Up.onClick.AddListener(() => {
            myObj.transform.Translate(0,0,-Time.deltaTime * 3);
        });
        Down.onClick.AddListener(() => {
            myObj.transform.Translate(0,0,Time.deltaTime * 3);
        });
        Left.onClick.AddListener(() => {
            myObj.transform.Translate(-Time.deltaTime * 3,0,0f);
        });
        Right.onClick.AddListener(() => {
            myObj.transform.Translate(Time.deltaTime * 3,0,0f);
        });
        myObj.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 6,Input.GetAxis("Vertical") * Time.deltaTime * 6,0f);
        // print(Time.deltaTime);

        // if (Input.GetMouseButtonDown(0)) {  
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
        //     RaycastHit hit;  
        //     Debug.Log(ray);
        //     // Debug.Log(hit.collider);
        //     Physics.Raycast(ray, out hit);
        //     if(Physics.Raycast(ray, out hit)){
        //         if(hit.collider != null){
        //             Debug.Log(hit.collider.tag);
        //         }
        //     }
        //     // Debug.Log(hit.collider.tag);
             
        // }  
    }
}
