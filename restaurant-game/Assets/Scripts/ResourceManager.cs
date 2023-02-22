using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Menus")]
    public GameObject DayCompleteMenu;
    public GameObject IngredientsMenu;
    public GameObject PerksMenu;

    [Header("Day End Gold Values")]
    public TextMeshProUGUI GoldEarnedText;
    public TextMeshProUGUI DailyCostText;
    public TextMeshProUGUI GoldTotalText;

    [Header("Ingredients Numbers")]
    public TextMeshProUGUI BreadText;
    public TextMeshProUGUI CheeseText;
    public TextMeshProUGUI ButterText;
    public TextMeshProUGUI TomatoText;

    public int numBread = 0;
    public int numCheese = 0;
    public int numButter = 0;
    public int numTomato = 0;

    [Header("Perks Costs")]
    public TextMeshProUGUI StoveCostText;
    public TextMeshProUGUI TipsCostText;
    public TextMeshProUGUI PatienceCostText;

    [Header("Perks Levels")]
    public GameObject StoveLevel;
    public GameObject TipsLevel;
    public GameObject PatienceLevel;

    public int StoveLevelNum = 0;
    public int TipsLevelNum = 0;
    public int PatienceLevelNum = 0;

    [Header("Perks Sprites")]
    public Sprite[] Levels;

    public int[] ingredientCosts;
    public int[] perkCosts;
    public GameObject[] coinIcons;
    public Image[] buttons;
    public Sprite fullyUpgraded;
    public RestaurantManager restaurant;

    public AudioSource source;
    public AudioClip[] clips;

    // GENERAL UI INTERACTION
    public void OnClickIngredientsButton(){
        DayCompleteMenu.SetActive(false);
        IngredientsMenu.SetActive(true);
    }

    public void OnClickPerksButton(){
        DayCompleteMenu.SetActive(false);
        PerksMenu.SetActive(true);
    }

    public void OnClickIngredientsMenuBackButton(){
        IngredientsMenu.SetActive(false);
        DayCompleteMenu.SetActive(true);
    }

    public void OnClickPerksMenuBackButton(){
        PerksMenu.SetActive(false);
        DayCompleteMenu.SetActive(true);
    }

    // PURCHASE INGREDIENTS
    public void OnClickBuyBreadButton()
    {
        if (restaurant.money >= ingredientCosts[0]) {
            restaurant.itemAmounts[0] += 1;
            restaurant.money -= ingredientCosts[0];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    public void OnClickBuyCheeseButton(){
        if (restaurant.money >= ingredientCosts[1]) {
            restaurant.itemAmounts[1] += 1;
            restaurant.money -= ingredientCosts[1];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    public void OnClickBuyButterButton(){
        if (restaurant.money >= ingredientCosts[2]) {
            restaurant.itemAmounts[2] += 1;
            restaurant.money -= ingredientCosts[2];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    public void OnClickBuyTomatoButton(){
        if (restaurant.money >= ingredientCosts[3]) {
            restaurant.itemAmounts[3] += 1;
            restaurant.money -= ingredientCosts[3];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    // PURCHASE PERKS
    public void OnClickUpgradeStoveButton(){
        if (StoveLevelNum < 3 && restaurant.money >= perkCosts[StoveLevelNum]){
            restaurant.money -= perkCosts[StoveLevelNum];
            StoveLevelNum++;
            StoveLevel.GetComponent<Image>().sprite = Levels[StoveLevelNum];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    public void OnClickUpgradeTipsButton(){
        if (TipsLevelNum < 3 && restaurant.money >= perkCosts[TipsLevelNum]){
            restaurant.money -= perkCosts[TipsLevelNum];
            TipsLevelNum++;
            TipsLevel.GetComponent<Image>().sprite = Levels[TipsLevelNum];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    public void OnClickUpgradePatienceButton(){
        if (PatienceLevelNum < 3 && restaurant.money >= perkCosts[PatienceLevelNum]){
            restaurant.money -= perkCosts[PatienceLevelNum];
            PatienceLevelNum++;
            PatienceLevel.GetComponent<Image>().sprite = Levels[PatienceLevelNum];
            source.clip = clips[0];
            source.Play();
        } else {
            source.clip = clips[1];
            source.Play();
        }
    }

    void Update() {
        BreadText.text = restaurant.itemAmounts[0].ToString();
        CheeseText.text = restaurant.itemAmounts[1].ToString();
        ButterText.text = restaurant.itemAmounts[2].ToString();
        TomatoText.text = restaurant.itemAmounts[3].ToString();
        if (StoveLevelNum < 3) {
            StoveCostText.text = perkCosts[StoveLevelNum].ToString();
        } else {
            StoveCostText.text = "";
            coinIcons[0].SetActive(false);
            buttons[0].sprite = fullyUpgraded;
        }
        if (TipsLevelNum < 3) {
            TipsCostText.text = perkCosts[TipsLevelNum].ToString();
        } else {
            TipsCostText.text = "";
            coinIcons[1].SetActive(false);
            buttons[1].sprite = fullyUpgraded;
        }
        if (PatienceLevelNum < 3) {
            PatienceCostText.text = perkCosts[PatienceLevelNum].ToString();
        } else {
            PatienceCostText.text = "";
            coinIcons[2].SetActive(false);
            buttons[3].sprite = fullyUpgraded;
        }
    }
}
