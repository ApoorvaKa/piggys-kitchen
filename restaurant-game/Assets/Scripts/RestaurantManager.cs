using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RestaurantManager : MonoBehaviour
{
    public int money = 0;
    public int money_per_second = 0;
    public int round = 1;
    int dailyCost = 10;

    public GameObject background, dayComplete;
    GameObject player;

    public Image timerBar;
    public TextMeshProUGUI moneyText, goldEarned, dailyCosts, totalGold;
    public TextMeshProUGUI[] itemTexts;
    public string[] itemNames;
    public int[] itemAmounts;
    [SerializeField]
    float maxTime;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemTexts.Length; i++) {
            itemTexts[i].text = itemNames[i] + ": " + itemAmounts[i].ToString();
        }
        moneyText.text = "$ " + money.ToString();
        if (currentTime > 0 && player.GetComponent<Player>().canMove == true) {
            currentTime -= Time.deltaTime;
            timerBar.fillAmount = currentTime / maxTime;
        } else {
            Debug.Log("Time");
            player.GetComponent<Player>().canMove = false;
            if (currentTime <= 0) {
                background.SetActive(true);
                dayComplete.SetActive(true);
                goldEarned.text = money.ToString();
                dailyCost = (int)Mathf.Pow(2f, (float)round-1f) * 10;
                dailyCosts.text = dailyCost.ToString();
                money -= dailyCost;
                totalGold.text = money.ToString();
            }
            currentTime = maxTime;
        }
    }

    public void NextRound() {
        if (money >= 0) {
            round += 1;
            player.GetComponent<Player>().canMove = true;
            background.SetActive(false);
            dayComplete.SetActive(false);
        } else {
            Debug.Log("GameOver");
        }
    }
}