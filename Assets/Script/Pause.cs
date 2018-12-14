using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject ui;

	void Update()
	{
		if (Input.GetKeyDown("p"))
		{
			Toggle();
		}
	}

	public void Toggle() // marche pour le bouton "continue"
	{
		ui.SetActive(!ui.activeSelf); //plus simple pour basculer d'un état à l'autre

		if (ui.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}
}
