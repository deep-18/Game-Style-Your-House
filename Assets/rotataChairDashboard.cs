using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotataChairDashboard : MonoBehaviour
{
   public GameObject my3DObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        my3DObj.transform.Rotate(0f,0.1f,0f,Space.Self);

    }
}
