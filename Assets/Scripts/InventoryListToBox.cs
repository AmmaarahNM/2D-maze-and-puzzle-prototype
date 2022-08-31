using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryListToBox : MonoBehaviour, IDragHandler, IEndDragHandler
{
    
    Vector2 mousePos;
    Vector2 initialPos;
    Vector2 initialScale;

    bool inRange;

    public GameManager GM;

    void Start()
    {
        initialPos = transform.position;
        initialScale = transform.localScale;
        
    }

    void Update()
    {
        //RANGE TO DETERMINE WHETHER THE ITEM WIL BE INSIDE THE BOX
        if (transform.position.x >= -4.5 && transform.position.x <= 4.7
            && transform.position.y >= -3 && transform.position.y <= 0.5)
        {
            inRange = true;
        }

        else
        {
            inRange = false;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        Debug.Log(transform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (inRange) 
        {
            transform.localScale = initialScale * 2.5f;

            if (gameObject.name == "smallCipherWheel")
            {
                GM.smallRotateButton.SetActive(true);
            }

            if (gameObject.name == "bigCipherWheel")
            {
                GM.largeRotateButton.SetActive(true);
            }
        }

        else
        {
            transform.position = initialPos;
            transform.localScale = initialScale;

            if (gameObject.name == "smallCipherWheel")
            {
                GM.smallRotateButton.SetActive(false);
            }

            if (gameObject.name == "bigCipherWheel")
            {
                GM.largeRotateButton.SetActive(false);
            }
        }
    }
   
}
