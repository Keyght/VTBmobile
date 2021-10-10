using Firebase.Database;
using Firebase.Extensions;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add()
    {
        /*PlayerData pD = new PlayerData();
        var jsonNewUser = JsonConvert.SerializeObject(pD);
        FirebaseDatabase.DefaultInstance.GetReference($"user/").SetRawJsonValueAsync(jsonNewUser).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                print("fail");
            }
        }
        );*/
    }
}
