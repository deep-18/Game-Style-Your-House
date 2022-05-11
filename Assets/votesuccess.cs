using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class votesuccess : MonoBehaviour
{
    public GameObject voteScreen;
    public GameObject SuccessScreen;
    public Button Close;
    // Start is called before the first frame update
    void Start()
    {
        Close.onClick.AddListener(() => {
            voteScreen.SetActive(true);
            SuccessScreen.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
