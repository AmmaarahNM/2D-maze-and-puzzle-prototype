using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public bool onSwitch;
    public GameObject switchText;
    public GameObject inventoryAddition;
    public GameManager GM;
    public LevelManager LM;
    public SceneChanger SC;

    //PLAYER TRIGGER COLLISIONS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "swatch")
        {
            onSwitch = true;
            switchText.SetActive(true);
            Debug.Log("onSwitchTrue");
        }
        
        //LEVEL 2 COLLECTABLES
        if (collision.gameObject.tag == "newCollectables")
        {
            inventoryAddition.SetActive(true);
            StartCoroutine("DeactivateInventoryText");
            LM.ActivateInventory(collision.gameObject);
            
            Destroy(collision.gameObject);
        }

        //LEVEL 1 COLLECTABLES
        if (collision.gameObject.tag == "collectables")
        {
            GM.inventoryCollected++;
            inventoryAddition.SetActive(true);
            StartCoroutine("DeactivateInventoryText");
            Debug.Log("Inventory: " + GM.inventoryCollected);
            
            GM.ActivateInventory(collision.gameObject);
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Finish")
        {
            SC.ChangeScene(3); 
        }

        if (collision.gameObject.tag == "End")
        {
            SC.ChangeScene(0);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "swatch")
        {
            onSwitch = false;
            switchText.SetActive(false);
            Debug.Log("onSwitchFalse");
        }

    }

    private IEnumerator DeactivateInventoryText()
    {
        yield return new WaitForSeconds(2);
        inventoryAddition.SetActive(false);
    }

    
}
