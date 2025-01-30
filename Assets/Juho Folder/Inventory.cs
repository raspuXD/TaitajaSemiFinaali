using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // To work with UI components
using TMPro;  // To work with TextMeshPro components

public class Inventory : MonoBehaviour
{
    public int Milk = 5;  // Initial milk amount
    public int Bullets = 10;  // Initial bullet count
    public int Money = 0;

    public TMP_Text milkText;  // TextMeshPro reference for milk amount
    public TMP_Text bulletsText;
    public TMP_Text moneyText;// TextMeshPro reference for bullet count

    public InventoryShow show;


    // Called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Milk > 0)
            {
                DecreaseMilk(1);  // Drink one milk
            }
            else
            {
                Debug.Log("No milk to drink!");
            }
        }
        // Update the Milk and Bullets text displays
        UpdateInventoryText();
    }

    // Method to update the Milk and Bullets text displays
    private void UpdateInventoryText()
    {
        if (milkText != null)
        {
            milkText.text = Milk.ToString();  // Update the milk amount text
        }

        if (bulletsText != null)
        {
            bulletsText.text = Bullets.ToString();  // Update the bullets amount text
        }
        moneyText.text = Money.ToString() + "€";
    }

    public void IncreaseMoney(int amount)
    {
        Money += amount;
        show.ActivateThis();
        show.HideInventory();
        Debug.Log("Milk increased! Current milk: " + Milk);
    }


    public void DecreaseMoney(int amount)
    {
        Money -= amount;
        show.ActivateThis();
        show.HideInventory();
    }
    public void IncreaseMilk(int amount)
    {
        Milk += amount;
        show.ActivateThis();
        show.HideInventory();
        Debug.Log("Milk increased! Current milk: " + Milk);
    }

    // Method to decrease milk (e.g., for actions like using milk as a resource)
    public void DecreaseMilk(int amount)
    {
        if (Milk >= amount)
        {
            Milk -= amount;
            show.ActivateThis();
            show.HideInventory();
            Debug.Log("Milk decreased! Current milk: " + Milk);
        }
        else
        {
            Debug.Log("Not enough milk!");
        }
    }

    // Method to increase bullets
    public void IncreaseBullets(int amount)
    {
        Bullets += amount;
        show.ActivateThis();
        show.HideInventory();
        Debug.Log("Bullets increased! Current bullets: " + Bullets);
    }

    // Method to decrease bullets (e.g., for shooting)
    public void DecreaseBullets(int amount)
    {
        if (Bullets >= amount)
        {
            Bullets -= amount;
            show.ActivateThis();
            show.HideInventory();
            Debug.Log("Bullets decreased! Current bullets: " + Bullets);
        }
        else
        {
            Debug.Log("Not enough bullets!");
        }
    }
}
