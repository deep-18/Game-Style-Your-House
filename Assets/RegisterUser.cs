using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class RegisterUser : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField EmailInput;
    public Button RegisterButton; 
    public Button LoginButton; 
    public GameObject RegisterPanel;
    public GameObject LoginPanel;
    public Text outputText;

    // Start is called before the first frame update
    void Start()
    {
        RegisterButton.onClick.AddListener(() => {
            IEnumerator RegisterUser(string username, string password, string email)
            {
                WWWForm form = new WWWForm();
                form.AddField("loginUser", username);
                form.AddField("loginPass", password);
                form.AddField("loginEmail", email);
        
                using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/registerUser.php", form))
                {
                    yield return www.SendWebRequest();
        
                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        Debug.Log(www.downloadHandler.text);
                        outputText.text = www.downloadHandler.text;
                        // textDisplay = www.downloadHandler.text;
                    }
                }
            }
            StartCoroutine(RegisterUser(UsernameInput.text, PasswordInput.text, EmailInput.text));
        });
        LoginButton.onClick.AddListener(() => {
            RegisterPanel.SetActive(false);
            LoginPanel.SetActive(true);
        });
    }

 
}
