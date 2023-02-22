using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject title;
    public GameObject startButton;
    public GameObject tutorialButton;
    public GameObject tutorialMenu;

    public void StartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OpenTutorial() {
        title.SetActive(false);
        startButton.SetActive(false);
        tutorialButton.SetActive(false);
        tutorialMenu.SetActive(true);
    }

    public void CloseTutorial() {
        title.SetActive(true);
        startButton.SetActive(true);
        tutorialButton.SetActive(true);
        tutorialMenu.SetActive(false);
    }
}
