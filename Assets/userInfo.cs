using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public string UserName;
    public string Level;
    public string Coins;
    public string UserPassword;
    public string UserID;

    public void setInfo(string username,string password){
        UserName = username;
        UserPassword = password;
    }
    public void setID(string id){
        UserID = id;
    }
    
}
