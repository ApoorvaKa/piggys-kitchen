using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestaurantManager : MonoBehaviour
{
    public int money = 0;
    public int money_multiplier = 1;
    public int money_per_second = 0;

    // public list of employees
    public Employee[] employees;

    public Image timerBar;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI[] itemTexts;
    public string[] itemNames;
    public int[] itemAmounts;
    [SerializeField]
    float currentTime, maxTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemTexts.Length; i++) {
            itemTexts[i].text = itemNames[i] + ": " + itemAmounts[i].ToString();
        }
        moneyText.text = "$ " + money.ToString();
        if (currentTime > 0) {
            currentTime -= Time.deltaTime;
            timerBar.fillAmount = currentTime / maxTime;
        } else {
            Debug.Log("Time");
            Time.timeScale = 0;
        }
    }
}