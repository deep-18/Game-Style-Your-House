using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.XR.ARFoundation;
public class ARView : MonoBehaviour
{
    public Button ARButton; 
    public GameObject myObj1;
    public GameObject ARPanel;
    public GameObject ShopPanel;
    public ARCursor arCursor;
    // Start is called before the first frame update
    void Start()
    {   
        ARButton.onClick.AddListener(() => {
            arCursor.loadObj(myObj1);
            ShopPanel.SetActive(false);
            ARPanel.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
