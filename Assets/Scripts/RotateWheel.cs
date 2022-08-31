using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    float zRotateSmall;
    float zRotateLarge;
    private void Start()
    {
        zRotateLarge = 72;
        zRotateSmall = -36;
    }

    //ROTATES THE WHEELS IN INVENTORY WHEN IN BOX
    private void Update()
    {
        if (gameObject.name == "smallCipherWheel")
        {
            transform.rotation = Quaternion.Euler(0, 0, zRotateSmall);
        }

        if (gameObject.name == "bigCipherWheel")
        {
            transform.rotation = Quaternion.Euler(0, 0, zRotateLarge);
        }

        if (transform.position.x >= -4.5 && transform.position.x <= 4.7
            && transform.position.y >= -3 && transform.position.y <= 0.5)
        {
            if (Input.GetKey(KeyCode.C))
            {
                zRotateSmall += Time.deltaTime * 20;
            }

            if (Input.GetKey(KeyCode.N))
            {
                zRotateLarge += Time.deltaTime * 20;
            }
        }
            
        
    }



}
