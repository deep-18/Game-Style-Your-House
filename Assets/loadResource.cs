using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class loadResource : MonoBehaviour
{
    // Start is called before the first frame update
    public Button BuyButton; 
    public GameObject myObj1;
    public Text price;
    public move moveF;

    // public void Resources(){
    //     var loadedObject = Instantiate(Resources.Load("Chair 1")) as GameObject;
    // }
    void Start()
    {
        BuyButton.onClick.AddListener(() => {
            IEnumerator RegisterCoin()
            {
                WWWForm form = new WWWForm();
                form.AddField("coins", price.text);
        
                using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/registerCoin.php", form))
                {
                    yield return www.SendWebRequest();
        
                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        Debug.Log(www.downloadHandler.text);
                        // outputText.text = www.downloadHandler.text;
                        Debug.Log(price.text);

                        // textDisplay = www.downloadHandler.text;
                    }
                }
            }
            StartCoroutine(RegisterCoin());
            myObj1.SetActive(true);
            moveF.moveObj(myObj1);
        });
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
