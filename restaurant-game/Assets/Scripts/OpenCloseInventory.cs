using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{
    public GameObject inventoryButton;
    public GameObject inventoryUI;
    public bool isOpen = false;

    public AudioClip[] clips;
    public AudioSource source;

    void Update() {
        inventoryButton.SetActive(!isOpen);
    }

    public void openInventory() {
        isOpen = true;
        inventoryUI.SetActive(true);
        source.clip = clips[0];
        source.Play();
    }

    public void back() {
        isOpen = false;
        inventoryUI.SetActive(false);
        source.clip = clips[1];
        source.Play();
    }
}
