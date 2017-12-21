using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {

	public CanvasGroup canvasStartScreenDisplay; //This is the canvas group of the start screen
	public CanvasGroup canvasMainDisplay; //This is the canvas group of the main game screen
	public GameObject HeaderTextScreen; //This is the Header text in the start screen canvas
	public GameObject CreditsTextScreen; //This is the Credits text in the start screen canvas
    public GameObject HowToPlayScreen;
	public Text ManagmentButtonStartScreenText; //This is the Management Button text in the start screen canvas
    public Text rulesText; // This is the how to play text

	public int chickenCounter;
	public GameObject levelOnePlatformOneTopLeft;
	public GameObject levelOnePlatformOneBottomLeft;
	public GameObject levelOnePlatformOneTopRight;
	public GameObject levelOnePlatformOneBottomRight;
	private bool breakFirstPlatform = false;

    private int activeSceneIndex;

    // Use this for initialization
    void Start () {
		float time = 1f;
		while(canvasStartScreenDisplay.alpha < 1)
		{
			canvasStartScreenDisplay.alpha += Time.deltaTime / time;
		}

        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if its the credit screen.
        if (activeSceneIndex == 3)
        {
           //check for restart button.
        }
        //not main menu
        if (activeSceneIndex > 0)
        {
            setMainCanvasToAppear();
        }

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void incrementChickenCounter () {
		chickenCounter++;
	}

    public void decrementChickenCounter()
    {
        chickenCounter--;
    }


	//This function is for the "OrderUp! button
	//It starts up the game by removing the start screen and causing the main canvas to appear
	public void orderUpButton() {
		//setStartCanvasToDissapear ();
		//setMainCanvasToAppear ();

        activeSceneIndex++;
        Application.LoadLevel(activeSceneIndex);

    }

	//This removes the start canvas by reducing the alpha to 0
	public void setStartCanvasToDissapear(){
		float time = 1f;
		while(canvasStartScreenDisplay.alpha > 0)
		{
			canvasStartScreenDisplay.alpha -= Time.deltaTime / time;
		}

	}

	//This causes the main canvas to appear by increasing the alpha back 1
	public void setMainCanvasToAppear(){
		float time = 1f;
		while(canvasMainDisplay.alpha < 1)
		{
			canvasMainDisplay.alpha += Time.deltaTime / time;
		}

	}

	//This function is for the "Management" button 
	//This shows the credits section on the start screen and also reverses back
	public void managementButton() {

		if (HeaderTextScreen.activeSelf){
			HeaderTextScreen.SetActive (false);
			CreditsTextScreen.SetActive (true);
			ManagmentButtonStartScreenText.text = "Go Back";
		} else if(HowToPlayScreen.activeSelf) {
            HowToPlayScreen.SetActive(false);
            CreditsTextScreen.SetActive(true);
            ManagmentButtonStartScreenText.text = "Go Back";
            rulesText.text = "How To Play";
        }
        else {
			HeaderTextScreen.SetActive (true);
			CreditsTextScreen.SetActive (false);
			ManagmentButtonStartScreenText.text = "Management";
		}
	}

	public void exitButton() {

		Application.Quit();
	}

	public void restartGame() {
		SceneManager.LoadScene("Main Menu");
	}

    public void howToPlay()
    {
        if (HeaderTextScreen.activeSelf)
        {
            HeaderTextScreen.SetActive(false);
            HowToPlayScreen.SetActive(true);
            rulesText.text = "Go Back";
        } else if (CreditsTextScreen.activeSelf)
        {
            CreditsTextScreen.SetActive(false);
            HowToPlayScreen.SetActive(true);
            rulesText.text = "Go Back";
            ManagmentButtonStartScreenText.text = "Management";
        }
        else
        {
            HeaderTextScreen.SetActive(true);
            HowToPlayScreen.SetActive(false);
            rulesText.text = "How To Play";
        }
    }

}
