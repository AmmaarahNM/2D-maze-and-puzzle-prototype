using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameManager GM;
    public LevelManager LM;

    //CONTROLS THE BLACK BALL (PLAYER) MOVEMENT
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2);

        }

        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }

        else if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }

        else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }

        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "finalGate")
        {
            gameObject.transform.position = new Vector3(transform.position.x - 0.6f, transform.position.y);
            LM.gateUI.SetActive(true);
            LM.player.SetActive(false);
            //LM.gate2UI true active 
        }
        if (collision.gameObject.tag == "Gate")
        {
            Debug.Log("GateCollision");
            gameObject.transform.position = new Vector3(transform.position.x - 0.6f, transform.position.y);
            GM.gateUI.SetActive(true);
            GM.player.SetActive(false);
            
            //Activate gate locked ui
            //Enter code UI will also be here -- manage this and unlock function in GM. and inventory too
            //UI will have a return button and a check inventory button on it
            //deactivate movement controller when gate UI is active
        }

        
    }
}
