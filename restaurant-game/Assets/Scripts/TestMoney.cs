using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoney : MonoBehaviour
{
    public RestaurantManager moneySystem;
    /*
    [SerializeField]
    int itemID;
    */

    public void increaseMoney(int amount) {
        moneySystem.money += amount;
    }

    public void decreaseMoney(int amount) {
        if (moneySystem.money >= amount) {
            moneySystem.money -= amount;
            //moneySystem.itemAmounts[itemID] += 1;
        }
    }
}
