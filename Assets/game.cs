using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class game : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopPanel;
    public GameObject gamePanel;
    public Button shopButton;
    public Button dashboardButton; 
    public Button saveButton; 
    public GameObject DashboardPanel;
    public GameObject GamePanel;
    // public Text userID;
    private IEnumerator Screenshot(){
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24 , false);
        texture.ReadPixels(new Rect(0,0,Screen.width, Screen.height),0,0);
        texture.Apply();
        //PC
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Screenshot.jpg", bytes);
        Destroy(texture);
    }
    IEnumerator getUser()
            {
                WWWForm form = new WWWForm();
        
                using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/getUserID.php", form))
                {
                    yield return www.SendWebRequest();
        
                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        Debug.Log(www.downloadHandler.text);
                        yield return new WaitForEndOfFrame();
                        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24 , false);
                        texture.ReadPixels(new Rect(0,0,Screen.width, Screen.height),0,0);
                        texture.Apply();
                        //PC
                        byte[] bytes = texture.EncodeToPNG();
                        File.WriteAllBytes(Application.dataPath + "/Screenshot" + www.downloadHandler.text +".jpg", bytes);
                        Destroy(texture);
                        byte[] byteArray = File.ReadAllBytes(Application.dataPath + "/Screenshot" + www.downloadHandler.text +".jpg");
                        // outputText.text = www.downloadHandler.text;
                        // textDisplay = www.downloadHandler.text;
                    }
                }
            }
    IEnumerator SendFile(){
        WWWForm form = new WWWForm();
        // form.AddBinaryData("myImage", bytes, "myImage.png", "image/png");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/storeImage.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
    void Start()
    {
        shopButton.onClick.AddListener(() => {
            shopPanel.SetActive(true);
            gamePanel.SetActive(false);
        });        
        dashboardButton.onClick.AddListener(() => {
            DashboardPanel.SetActive(true);
            GamePanel.SetActive(false);
        });
        saveButton.onClick.AddListener(() => {
        //    StartCoroutine("Screenshot");
           StartCoroutine("getUser");
            
            // Debug.Log(id);

            // //You can then load it to a texture
            // // Texture2D tex = new Texture2D(2, 2);
            // // tex.LoadImage(imageAsset.bytes);

            // //Or you can send the binary data to any web server
            StartCoroutine("SendFile");
        });
        //You can load the image as a byte array

    }

    // // Update is called once per frame
    void Update()
    {
        
    }
}
