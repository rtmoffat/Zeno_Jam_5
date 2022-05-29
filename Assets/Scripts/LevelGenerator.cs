using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using jl = JSON_Loader;

public class LevelGenerator : MonoBehaviour
{
    public GameObject lightSphere;
    public GameObject bug;
    public GameObject home;
    public TextAsset levels_TA;
    

    void GenerateLevel(int level)
    {
        Vector3 vec = new Vector3();
        for (int i=10;i<600;i+=20)
        {
            
            vec.Set(-5, 1, i);
            Instantiate(lightSphere, vec, lightSphere.transform.rotation);
        }
        Instantiate(bug);
        vec.Set(1, 0, 620);
        Instantiate(home,vec,home.transform.rotation);        
    }
    string loadJSONData()
    {
        string jsondata = "{'Levels':[{'Lights':[{'x':1,'y':2,'z':3},{'x':1,'y':2,'z':3},{'x':1,'y':2,'z':3}],'Home':{'x':1,'y':2,'z':3},'Speed':1},{'Lights':[{'x':1,'y':2,'z':3},{'x':1,'y':2,'z':3},{'x':1,'y':2,'z':3}],'Home':{'x':1,'y':2,'z':3},'Speed':1}]}";
        return jsondata;    
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel(1);
    }
}
