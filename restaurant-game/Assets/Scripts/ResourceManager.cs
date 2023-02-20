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

    [Header("Gold Values")]
    public TextMeshProUGUI GoldEarnedText;
    public TextMeshProUGUI DailyCostText;
    public TextMeshProUGUI GoldTotalText;

    [Header("Ingredients")]
    public TextMeshProUGUI BreadText;
    public TextMeshProUGUI CheeseText;
    public TextMeshProUGUI ButterText;
    public TextMeshProUGUI TomatoText;

    public int numBread = 0;
    public int numCheese = 0;
    public int numButter = 0;
    public int numTomato = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
