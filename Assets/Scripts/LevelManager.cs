using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject purpleCol;
    public GameObject blueCol;
    public GameObject yellowCol;
    public GameObject redCol;

    public GameObject gate;

    public GameObject gateUI;
    public GameObject player;
    public GameObject inventoryUI;
    public GameObject quitButton;

    public GameObject successUI;
    bool success;
    public GameObject failUI;
    public Text triesLeft;
    int numberOfTries = 3;

    public GameObject[] inventoryItems;

    public ColourSwitcher CS;

    public Transform treeBlock;
    public Transform eyeBlock;
    public Transform heartBlock;
    public Transform moonBlock;
    public Transform boxBlock;
    public Transform fishBlock;

    public Transform opening1;
    public Transform opening2;
    public Transform opening3;
    public Transform opening4;

    //LEVEL 2 MANAGER*

    void Update()
    {
        //ADJUSTS THE QUESTION MARK COLLECTABLES ACCORDING TO MAZE COLOUR
        if (CS.purpleMaze)
        {
            purpleCol.SetActive(false);
        }

        else
        {
            purpleCol.SetActive(true);
        }

        if (CS.blueMaze)
        {
            blueCol.SetActive(false);
        }

        else
        {
            blueCol.SetActive(true);
        }

        if (CS.yellowMaze)
        {
            yellowCol.SetActive(false);
        }

        else
        {
            yellowCol.SetActive(true);
        }

        if (CS.redMaze)
        {
            redCol.SetActive(false);
        }

        else
        {
            redCol.SetActive(true);
        }

        if (success)
        {
            gate.transform.position = Vector3.MoveTowards(gate.transform.position, new Vector2(0.025f, 2.4f), Time.deltaTime);
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
        gateUI.SetActive(false);
        quitButton.SetActive(false);
    }

    public void LeaveInventory()
    {
        inventoryUI.SetActive(false);
        gateUI.SetActive(true);
        quitButton.SetActive(true);
    }

    //ACTIVATES INVENTORY UI WHEN ITEM COLLECTED IN MAZE
    public void ActivateInventory(GameObject found)
    {
        Debug.Log(found.name);

        if (found.name == "piece1")
        {
            inventoryItems[0].SetActive(true);
        }

        if (found.name == "piece2")
        {
            inventoryItems[1].SetActive(true);
        }

        if (found.name == "piece3")
        {
            inventoryItems[2].SetActive(true);
        }

        if (found.name == "piece4")
        {
            inventoryItems[3].SetActive(true);
        }

        if (found.name == "piece5")
        {
            inventoryItems[4].SetActive(true);
        }

        if (found.name == "piece6")
        {
            inventoryItems[5].SetActive(true);
        }

        if (found.name == "cipherCover")
        {
            inventoryItems[6].SetActive(true);
        }

        if (found.name == "list")
        {
            inventoryItems[7].SetActive(true);
        }
    }

    public void OrganisedEnter()
    {
        if (heartBlock.position == opening1.position && boxBlock.position == opening2.position && eyeBlock.position == opening3.position && treeBlock.position == opening4.position)
        {
            Debug.Log("SUCCESS!");
            successUI.SetActive(true);
            ReturnToMaze();
            success = true; //to adjust gate
        }

        else
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
                //UNSUCCESSFUL - RETURN OR RETRY BUTTONS
            }
        }

    }
}
