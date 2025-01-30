using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBubble : MonoBehaviour
{
    public InventoryShow show;
    public Inventory inve;
    public GameObject theBubble, theName;
    bool canPressE;

    public bool isKalle, isJuho;

    [Header("Kai Teleport")]
    public Transform whereTo;
    public GameObject playerPref;
    public CowSpawner spawner;

    private void Update()
    {
        if(canPressE)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (isKalle)
                {
                    if(inve.Money >= 3)
                    {
                        inve.DecreaseMoney(3);
                        inve.IncreaseBullets(4);
                    }
                }
                else if (isJuho)
                {
                    if (inve.Milk >= 1)
                    {
                        inve.DecreaseMilk(1);
                        inve.IncreaseMoney(5);
                    }
                }
                else
                {
                    if(inve.Money >= 100)
                    {
                        Teleport();
                    }
                }
            }
        }
    }

    void Teleport()
    {
        playerPref.transform.position = whereTo.position;
        spawner.DestroyAllCows();
        Destroy(spawner);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            theBubble.SetActive(true);
            canPressE = true;
            show.ActivateThis();
            theName.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            theBubble.SetActive(false);
            canPressE=false;
            show.HideInventory();
            theName.SetActive(true);
        }
    }
}
