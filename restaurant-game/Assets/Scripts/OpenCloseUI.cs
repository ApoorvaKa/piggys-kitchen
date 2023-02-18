using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseUI : MonoBehaviour
{
    public GameObject employeeButton;
    public GameObject shopButton;
    public GameObject employeeUI;
    public GameObject shopUI;
    public bool isOpen = false;

    void Update() {
        employeeButton.SetActive(!isOpen);
        shopButton.SetActive(!isOpen);
    }

    public void openEmployee() {
        isOpen = true;
        employeeUI.SetActive(true);
    }

    public void openShop() {
        isOpen = true;
        shopUI.SetActive(true);
    }

    public void back() {
        isOpen = false;
        employeeUI.SetActive(false);
        shopUI.SetActive(false);
    }
}
