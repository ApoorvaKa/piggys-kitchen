using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{
    public GameObject inventoryButton;
    public GameObject inventoryUI;
    public bool isOpen = false;

    void Update() {
        inventoryButton.SetActive(!isOpen);
    }

    public void openInventory() {
        isOpen = true;
        inventoryUI.SetActive(true);
    }

    public void back() {
        isOpen = false;
        inventoryUI.SetActive(false);
    }
}
