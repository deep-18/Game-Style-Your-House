using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class cart : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject shopPanel;
    public GameObject gamePanel;
    public Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(() => {
            shopPanel.SetActive(false);
            gamePanel.SetActive(true);
        });   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
