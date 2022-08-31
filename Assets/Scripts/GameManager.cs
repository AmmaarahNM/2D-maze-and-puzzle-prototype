using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int inventoryCollected;
    public GameObject gateUI;
    public GameObject player;

    public GameObject inventoryUI;

    public InputField codeEntered;
    public GameObject gate;
    bool success;
    public GameObject successUI;

    public GameObject failUI;
    public GameObject quitButton;

    public Text triesLeft;
    int numberOfTries = 3;

    public GameObject[] inventoryItems;

    public GameObject smallRotateButton;
    public GameObject largeRotateButton;

    //LEVEL 1 MANAGER*

    void Update()
    {

        if (numberOfTries == 0)
        {
            Debug.Log("FAAAIIILLL");

        }

        if (success)
        {
            gate.transform.position = Vector3.MoveTowards(gate.transform.position, new Vector2(0.025f, 1.5f), Time.deltaTime);
        }
    }

    //BUTTON FUNCTIONS
    public void ReturnToMaze()
    {
        gateUI.SetActive(false);
        player.SetActive(true);
    }

    public void ViewInventory()
    {
        inventoryUI.SetActive(true);
        quitButton.SetActive(false);
    }

    public void LeaveInventory()
    {
        inventoryUI.SetActive(false);
        quitButton.SetActive(true);
    }

    public void CodeEntered()
    {
        if (codeEntered.text == "6137")
        {
            Debug.Log("SUCCESS!");
            successUI.SetActive(true);
            ReturnToMaze();
            success = true;
            
        }

        else
        {
            if (gateUI.activeSelf == true && codeEntered.text != "")
            {
                if (numberOfTries > 1)
                {
                    numberOfTries--;
                    triesLeft.text = numberOfTries + "/3 attempts left";
                }

                else
                {
                    gateUI.SetActive(false);
                    failUI.SetActive(true);
                    quitButton.SetActive(false);
                    
                }
                   
            }
            
        }
    }

    //ACTIVATES INVENTORY UI WHEN ITEM COLLECTED IN MAZE
    public void ActivateInventory(GameObject found)
    {
        Debug.Log(found.name);

        if (found.name == "codePiece1")
        {
            inventoryItems[3].SetActive(true);
        }

        if (found.name == "codePiece2")
        {
            inventoryItems[0].SetActive(true);
        }

        if (found.name == "codePiece3")
        {
            inventoryItems[4].SetActive(true);
        }

        if (found.name == "cipherClue")
        {
            inventoryItems[2].SetActive(true);
        }

        if (found.name == "smallCircle")
        {
            inventoryItems[5].SetActive(true);
        }

        if (found.name == "bigCircle")
        {
            inventoryItems[1].SetActive(true);
        }
    }
}
