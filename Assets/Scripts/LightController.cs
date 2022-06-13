using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LightController : MonoBehaviour
{
    public float pullSpeed;
    public bool isOn;
    public void Awake()
    {
        this.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.gray);
        this.pullSpeed = 0.07f;
        this.isOn = false;
    }
    void SwapColors(GameObject obj)
    {
        Debug.Log("Swapping colors for obj "+obj.name);
        Debug.Log("ison=" + obj.GetComponent<LightController>().isOn);
        if (obj.GetComponent<LightController>().isOn)
        {
            obj.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.gray);
            obj.GetComponent<LightController>().isOn = false;
            Debug.Log("Deactivated light");
        }
        else
        {
            obj.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
            obj.GetComponent<LightController>().isOn = true;
            Debug.Log("Activated lighgt");
            GameObject pObj=GameObject.Find("Bug_Sphere");
            pObj.transform.position = Vector3.MoveTowards(pObj.transform.position, obj.transform.position, pullSpeed * Time.deltaTime);
        }
    }
    public void OnClick()
    {
        Debug.Log("I clicked something!");
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null)
            {
                Debug.Log("hi raycasted" + hit.transform.gameObject.GetInstanceID());
                if (hit.transform.gameObject.name == "Light_Sphere")
                {
                    Debug.Log("Color=" + hit.transform.gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor"));
                    SwapColors(hit.transform.gameObject);
                }
            }
        }
    }
}

