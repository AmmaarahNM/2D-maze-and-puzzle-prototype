using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxOrdering : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Transform opening1;
    public Transform opening2;
    public Transform opening3;
    public Transform opening4;

    Vector2 initialPos;
    Vector2 mousePos;

    void Start()
    {
        initialPos = transform.position;
    }


    public void OnDrag(PointerEventData eventData)
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        Debug.Log(transform.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Vector2.Distance(transform.position, opening1.position) <= 0.2)
        {
            transform.position = opening1.position;
        }

        else if (Vector2.Distance(transform.position, opening2.position) <= 0.2)
        {
            transform.position = opening2.position;
        }

        else if (Vector2.Distance(transform.position, opening3.position) <= 0.2)
        {
            transform.position = opening3.position;
        }

        else if (Vector2.Distance(transform.position, opening4.position) <= 0.2)
        {
            transform.position = opening4.position;
        }

        else
        {
            transform.position = initialPos;
        }
    }
    
}
