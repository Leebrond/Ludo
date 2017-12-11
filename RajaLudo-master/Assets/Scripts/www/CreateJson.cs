using UnityEngine;
using System;


[Serializable]
public class CreateJson
{
    public string user_name;
    public string password;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
    
}
