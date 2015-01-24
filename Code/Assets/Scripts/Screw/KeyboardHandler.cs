﻿using UnityEngine;
using System.Collections;

public class KeyboardHandler : MonoBehaviour {

	public TimerRun Timer;
	public KeyCode Screw = KeyCode.W;
	public KeyCode DontScrew = KeyCode.E;

	public Transform ScrewItem;
	public Transform ScrewDriver;
	public Transform WoodPlank;
	public Transform Hand;

	public bool ScrewPressed = false;
	public bool DontScrewPressed = false;
	
	public KeyCode WinKey = KeyCode.W;
	public KeyCode LoseKey = KeyCode.E;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GetComponent<TimerRun>().InstructionsTimeLeft > 0)
		{
			return;
		}
		
		if (ScrewPressed || DontScrewPressed)
		{
			if (ScrewPressed)
			{
				ScrewItem.Rotate(Vector3.forward,-5);
				ScrewDriver.Rotate(Vector3.up,-5);
			}
			else 
			{
				ScrewItem.gameObject.SetActive(false);
				ScrewDriver.gameObject.SetActive(false);
				Hand.gameObject.SetActive(false);

				//-0.4
				if (WoodPlank.transform.position.y > -0.4f)
				{
					Vector3 pos = WoodPlank.transform.position;
					pos.y -= 0.1f;
					WoodPlank.transform.position = pos;
				}
			}
			return;
		}
		
		if (Input.GetKeyDown(Screw))
		{
			ScrewPressed = true;

			if (Screw == WinKey)
			{
				// Signal WON
				Debug.Log("You win...");
				
				this.GetComponent<TimerRun>().MissionComplete = true;
			}
		}
		
		if (Input.GetKeyDown(DontScrew))
		{
			DontScrewPressed = true;

			
			if (DontScrew == WinKey)
			{
				// Signal WON
				Debug.Log("You win...");
				
				this.GetComponent<TimerRun>().MissionComplete = true;
			}
		}
	}
}
