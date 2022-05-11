using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class itemOwn : MonoBehaviour
{
    public string userID;
    Action<string> _createItemsCallback;
    // Start is called before the first frame update
    void Start()
    {
        _createItemsCallback = (jsonArray) => {
            StartCoroutine(CreateItemsRoutine(jsonArray));
        };
    }

    public void createItems(){
        string UserId = Main.Instance.userInfo.UserID;
        StartCoroutine(Main.Instance.Web.GetItemID(UserId,_createItemsCallback));
    }
    IEnumerator CreateItemsRoutine(string jsonArrayString){
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for(int i =0; i < jsonArray.Count; i++){
            // bool isDone;
            string itemId = jsonArray[i].AsObject["itemID"];
            JSONObject iteminfoJson = new JSONObject();

             Action<string> getInfoCallback = (itemInfo) => {
                // isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                iteminfoJson = tempArray[0].AsObject;
             };
             StartCoroutine(Main.Instance.Web.GetItemOwn(itemId,getInfoCallback));

            //  yield return new WaitUntil(() => isDone == true);

             //Instantiate Gameobject
             GameObject item = Instantiate(Resources.Load("Prefabs/items") as GameObject);
             item.transform.SetParent(this.transform);
             item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;

            // item.transform.Find("Name").GetComponent<Text>().text = iteminfoJson["name"];
            item.transform.Find("price").GetComponent<Text>().text = iteminfoJson["price"];
            item.transform.Find("desc").GetComponent<Text>().text = iteminfoJson["desc"];
        }
        yield return null;
    }
}
