using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RestaurantManager : MonoBehaviour
{
    public int money = 0;
    public int money_per_second = 0;
    public int round = 1;
    int dailyCost = 10, startingGold = 0;

    public GameObject background, dayComplete, gameOver;
    GameObject player;

    public Image timerBar;
    public ResourceManager upgrade;
    public TextMeshProUGUI moneyText, goldEarned, dailyCosts, totalGold, roundText, roundEnd;
    public TextMeshProUGUI[] itemTexts;
    public SubmitDish orders;
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
            itemTexts[i].text = itemAmounts[i].ToString();
        }
        moneyText.text = money.ToString();
        roundText.text = "Round " + round.ToString();
        if (currentTime > 0 && player.GetComponent<Player>().canMove == true) {
            currentTime -= Time.deltaTime;
            if (currentTime/maxTime > 0.5f) {
                timerBar.color = new Color(0,1,0);
            } else if (currentTime/maxTime > 0.25f) {
                timerBar.color = new Color(1,1,0);
            } else {
                timerBar.color = new Color(1,0,0);
            }
            timerBar.fillAmount = currentTime / maxTime;
        } else {
            Debug.Log("Time");
            player.GetComponent<Player>().canMove = false;
            if (money - dailyCost < 0) {
                totalGold.color = new Color(1, 0, 0);
            }
            totalGold.text = money.ToString();
            if (currentTime <= 0) {
                background.SetActive(true);
                dayComplete.SetActive(true);
                dailyCost = (int)Mathf.Pow(2f, (float)round-1f) * 10;
                dailyCosts.text = dailyCost.ToString();
                goldEarned.text = startingGold.ToString() + "+" + (money-startingGold).ToString();
                money -= dailyCost;
            }
            currentTime = maxTime + (upgrade.PatienceLevelNum * 20);
        }
    }

    public void NextRound() {
        if (money >= 0) {
            round += 1;
            player.GetComponent<Player>().canMove = true;
            background.SetActive(false);
            dayComplete.SetActive(false);
            startingGold = money;
            orders.Randomize(round);
        } else {
            Debug.Log("GameOver");
            gameOver.SetActive(true);
            roundEnd.text = "You made it to round " + round.ToString();
            dayComplete.SetActive(false);
        }
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}