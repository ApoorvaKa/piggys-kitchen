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
    public List<Employee> employees;

    public Image timerBar;
    public TextMeshProUGUI moneyText;
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
        moneyText.text = "$ " + money.ToString();
        currentTime -= Time.deltaTime;
        timerBar.fillAmount = currentTime / maxTime;
    }
}