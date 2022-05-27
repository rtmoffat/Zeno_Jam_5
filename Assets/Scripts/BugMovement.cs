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
        transform.Translate(new Vector3(player_action.x, 0, player_action.y) * speed * Time.deltaTime);
    }
}
