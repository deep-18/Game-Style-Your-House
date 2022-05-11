using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class Web : MonoBehaviour
{
    // string output;

    void Start()
    {
        // A correct website page.
        StartCoroutine(GetDate("http://localhost/furnituregame/getData.php"));
        StartCoroutine(GetUser("http://localhost/furnituregame/getUsers.php"));
        // StartCoroutine(Login("testuser","123456"));
        // StartCoroutine(RegisterUser("testuser1","123456"));

        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }

   

    public IEnumerator GetDate(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    public IEnumerator GetUser(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
    
    // public IEnumerator Login(string userID, System.Action<string> callback)
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("userID", userID);

    //     using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/getItem.php", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //            byte[] bytes = www.downloadHandler.data;

    //            Texture2D texture = new Texture2D(2,2);
    //            texture.LoadImage(bytes);

    //         //    Sprite sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f,0.5f));
    //         //    callback(sprite);
    //         }
    //     }
    // }

    // public IEnumerator Login(string username, string password,string output)
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("loginUser", username);
    //     form.AddField("loginPass", password);

    //     using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/login.php", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //             output = www.downloadHandler.text;
    //             Debug.Log(www.downloadHandler.text);
    //         }
    //     }
    // }
    
    // public IEnumerator RegisterUser(string username, string password, string email)
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("loginUser", username);
    //     form.AddField("loginPass", password);
    //     form.AddField("loginEmail", email);

    //     using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/registerUser.php", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //             Debug.Log(www.downloadHandler.text);
    //             // textDisplay = www.downloadHandler.text;
    //         }
    //     }
    // }
    // public IEnumerator ForgetPassword(string username, string password)
    // {
    //     WWWForm form = new WWWForm();
    //     form.AddField("loginUser", username);
    //     form.AddField("loginPass", password);

    //     using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/forgetpassword.php", form))
    //     {
    //         yield return www.SendWebRequest();

    //         if (www.result != UnityWebRequest.Result.Success)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //             Debug.Log(www.downloadHandler.text);
    //         }
    //     }
    // }
    public IEnumerator GetItemID(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/getItemID.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }
    public IEnumerator GetItemOwn(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/furnituregame/getItem.php", form))
        {
            // Request and wait for the desired page.
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonArray = www.downloadHandler.text;
                Debug.Log(jsonArray);

                callback(jsonArray);
            }
        }
    }
}
