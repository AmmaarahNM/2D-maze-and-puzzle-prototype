using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSwitcher : MonoBehaviour
{
    public GameObject purpleWalls;
    public GameObject yellowWalls;
    public GameObject redWalls;
    public GameObject blueWalls;

    public bool purpleMaze;
    public bool yellowMaze;
    public bool redMaze;
    public bool blueMaze;

    public Camera mainCam;
    public Color purple;
    public Color yellow;
    public Color red;
    public Color blue;

    public SwitchTrigger ST;

    //THIS SCRIPT CHANGES THE BACKGROUND COLOUR AND DEACTIVATES AND ACTIVATES MAZE WALLS ACCORDINGLY
    private void Start()
    {
        purpleMaze = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ST.onSwitch) 
        {
            ChangeBools();
        }

        if (purpleMaze)
        {
            PurpleMaze();
        }

        else if (yellowMaze)
        {
            YellowMaze();
        }

        else if (redMaze)
        {
            RedMaze();
        }

        else if (blueMaze)
        {
            BlueMaze();
        }
        
    }

    void ChangeBools()
    {
        if (purpleMaze == true)
        {
            purpleMaze = false;
            yellowMaze = true;
        }

        else if (yellowMaze == true)
        {
            yellowMaze = false;
            redMaze = true;
        }

        else if (redMaze == true)
        {
            redMaze = false;
            blueMaze = true;
        }

        else if (blueMaze == true)
        {
            blueMaze = false;
            purpleMaze = true;
        }
    }

    void PurpleMaze()
    {
        mainCam.backgroundColor = purple;
        purpleWalls.SetActive(false);
        blueWalls.SetActive(true);
    }

    void YellowMaze()
    {
        mainCam.backgroundColor = yellow;
        yellowWalls.SetActive(false);
        purpleWalls.SetActive(true);
    }

    void RedMaze()
    {
        mainCam.backgroundColor = red;
        redWalls.SetActive(false);
        yellowWalls.SetActive(true);
    }

    void BlueMaze()
    {
        mainCam.backgroundColor = blue;
        blueWalls.SetActive(false);
        redWalls.SetActive(true);
    }

}
