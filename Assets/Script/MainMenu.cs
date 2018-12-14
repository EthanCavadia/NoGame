using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Update () 
	{
		
	}

	public void StartGame()
	{
		Debug.Log("Button Pressed");
		SceneManager.LoadScene("Scenes/FirstLvl");
		Time.timeScale = 1f;
	}

	public void ExitGame()
	{
		Debug.Log("Quit the game");
		Application.Quit();
	}
}
