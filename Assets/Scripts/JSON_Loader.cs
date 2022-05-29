
using UnityEngine;

[System.Serializable]
public class JSON_Loader
{
    public static JSON_Loader getJSONObject(TextAsset ta)
    {       
        return JsonUtility.FromJson<JSON_Loader>(ta.text);
    }
}