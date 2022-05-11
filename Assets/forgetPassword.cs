using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
public class forgetPassword : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField OTPInput;
    public GameObject LoginPanel;
    public GameObject fpPanel;
    public Button LoginButton; 
    public Button fpButton; 
    public Button sendOTPButton; 
    public Button confirmOTPButton;
    public Text outputText; 


    // Start is called before the first frame update
    void Start()
    {
        int num;
        sendOTPButton.onClick.AddListener(() => {
            num = new System.Random().Next(1000, 9999);
            Debug.Log("ok");
            Debug.Log(num);
            Console.WriteLine("The otp",num);
            string message = "Your OTP is " + num;
            //PasswordInput.text = num;
            var client1 = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("furnituregame2022@gmail.com", "Gotohell"),
                EnableSsl = true
            };
            client1.Send("furnituregame2022@gmail.com", UsernameInput.text, "OTP", message);
            Console.WriteLine("Sent");
            Console.ReadLine();
            sendOTPButton.gameObject.SetActive(false);
            confirmOTPButton.gameObject.SetActive(true);
            OTPInput.gameObject.SetActive(true);
            confirmOTPButton.onClick.AddListener(() => {
                // string number = OTPInput.text;
                Debug.Log(num);
                if(OTPInput.text == num.ToString()){
                    confirmOTPButton.gameObject.SetActive(false);
                    OTPInput.gameObject.SetActive(false);
                    PasswordInput.gameObject.SetActive(true);
                    fpButton.gameObject.SetActive(true);
                }
            });
        });
        fpButton.onClick.AddListener(() => {
            IEnumerator ForgetPassword(string username, string password)
            {
                WWWForm form = new WWWForm();
                form.AddField("loginUser", username);
                form.AddField("loginPass", password);

                using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/forgetpassword.php", form))
                {
                    yield return www.SendWebRequest();

                    if (www.result != UnityWebRequest.Result.Success)
                    {
                        Debug.Log(www.error);
                    }
                    else
                    {
                        outputText.text = (www.downloadHandler.text);
                    }
                }
            }
            StartCoroutine(ForgetPassword(UsernameInput.text, PasswordInput.text));
        });
        LoginButton.onClick.AddListener(() => {
            fpPanel.SetActive(false);
            LoginPanel.SetActive(true);
        });
        
    }
}