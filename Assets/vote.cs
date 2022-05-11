using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class vote : MonoBehaviour
{

    public Button voteA; 
    public Button voteB; 
    private Sprite img1;
    private Sprite img2;
    public GameObject image1;
    public GameObject image2;

    public GameObject voteScreen;
    public GameObject SuccessScreen;
    // Start is called before the first frame update
    void Start()
    {
        // image1 = Resources.Load<Image>("/Screenshotdeep.png");
        // image2 = Resources.Load<Image>("/Screenshotdeep1.png");

        // image1.AddComponent(typeof(Image));
        // img1 = Resources.Load<Sprite>("/Assets/Screenshotdeep");
        // image1.GetComponent<Image>().sprite = img1;
        // Debug.Log("Test script started");
        
        // image2.AddComponent(typeof(Image));
        // img2 = Resources.Load<Sprite>("/Assets/Screenshotdeep");
        // image2.GetComponent<Image>().sprite = img2;
        // Debug.Log("Test script started");

        voteA.onClick.AddListener(() => {
            IEnumerator Vote(int id)
            {
                WWWForm form = new WWWForm();
                form.AddField("voteID", id);
        
                using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/registerVote.php", form))
                {
                    yield return www.SendWebRequest();
        
                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        Debug.Log(www.downloadHandler.text);
                        voteScreen.SetActive(false);
                        SuccessScreen.SetActive(true);
                        // outputText.text = www.downloadHandler.text;
                        // textDisplay = www.downloadHandler.text;
                    }
                }
            }
            StartCoroutine(Vote(1));
        });
        voteB.onClick.AddListener(() => {
            IEnumerator Vote(int id)
            {
                WWWForm form = new WWWForm();
                form.AddField("voteID", id);
        
                using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/registerVote.php", form))
                {
                    yield return www.SendWebRequest();
        
                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        Debug.Log(www.downloadHandler.text);
                        voteScreen.SetActive(false);
                        SuccessScreen.SetActive(true);
                        // outputText.text = www.downloadHandler.text;
                        // textDisplay = www.downloadHandler.text;
                    }
                }
            }
            StartCoroutine(Vote(2));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
