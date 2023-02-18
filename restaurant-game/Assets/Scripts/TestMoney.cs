using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoney : MonoBehaviour
{
    public RestaurantManager moneySystem;
    public int amount;
    [SerializeField]
    int itemID;

    public void increaseMoneyTest() {
        moneySystem.money += amount;
    }

    public void decreaseMoneyTest() {
        if (moneySystem.money >= amount) {
            moneySystem.money -= amount;
            moneySystem.itemAmounts[itemID] += 1;
        }
    }
}
