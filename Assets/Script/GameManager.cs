using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static int lives = 3;

	public GameObject heartOne, heartTwo, heartTree;
	// Use this for initialization
	void Start () 
	{
		heartOne.SetActive(true);
		heartTwo.SetActive(true);
		heartTree.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (lives)
		{
			case 2:
				heartOne.gameObject.SetActive(false);
				break;
			case 1:
				heartOne.gameObject.SetActive(false);
				heartTwo.gameObject.SetActive(false);
				break;
			case 0:
				heartOne.gameObject.SetActive(true);
				heartTwo.gameObject.SetActive(true);
				heartTree.gameObject.SetActive(true);
				SceneManager.LoadScene("Scenes/MainMenu");
				lives = 3;
				break;
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log("Quit game");
			Application.Quit();
		}
	}
}
