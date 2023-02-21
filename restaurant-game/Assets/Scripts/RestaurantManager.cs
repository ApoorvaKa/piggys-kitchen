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
    public int round = 1;

    public GameObject background, dayComplete;
    GameObject player;

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
            }
            currentTime = maxTime;
        }
    }

    public void NextRound() {
        round += 1;
        player.GetComponent<Player>().canMove = true;
        background.SetActive(false);
        dayComplete.SetActive(false);
    }
}