using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BugMovement : MonoBehaviour
{
    public Vector2 player_action;
    public float speed;


    public void OnMove(InputValue input)
    {
        player_action = input.Get<Vector2>();
        Debug.Log("Moving!" +player_action.ToString());
    }
    
    // Update is called once per frame
    void Update()
    {
        GameObject closest=FindClosestEnemy();

        if ((closest != null) && (closest.GetComponent<LightController>().isOn))
        {
            //Debug.Log("hi "+closest.name+" at "+closest.transform.position.ToString());
            //transform.position=Vector3.MoveTowards(transform.position, closest.transform.position,(speed*Time.deltaTime));
        }
        else
        {
            //transform.position=Vector3.MoveTowards(transform.position, transform.position, 0.0f);
        }
        //transform.Translate(new Vector3(player_action.x, 0, player_action.y) * speed * Time.deltaTime);
        
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Light");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            if (!go.GetComponent<LightController>().isOn)
            {
                continue;
            }
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
