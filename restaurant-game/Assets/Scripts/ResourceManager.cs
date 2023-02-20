using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Perks Costs")]
    public TextMeshProUGUI StoveCostText;
    public TextMeshProUGUI TipsCostText;
    public TextMeshProUGUI PatienceCostText;

    public int numBread = 0;
    public int numCheese = 0;
    public int numButter = 0;
    public int numTomato = 0;

    // UI INTERACTION
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
    public void OnClickBuyBreadButton(){
        numBread++;
        BreadText.text = numBread.ToString();
    }

    public void OnClickBuyCheeseButton(){
        numCheese++;
        CheeseText.text = numCheese.ToString();
    }

    public void OnClickBuyButterButton(){
        numButter++;
        ButterText.text = numButter.ToString();
    }

    public void OnClickBuyTomatoButton(){
        numTomato++;
        TomatoText.text = numTomato.ToString();
    }

}
