using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageSelectorScript : MonoBehaviour {
	private int stage = 0;
	private int unlockedStages = 1;
	private int completedStages = 0;

	public List<Transform> stageButtons;
	public Transform       player;

	// Use this for initialization
	void Start () {
		completedStages = PlayerPrefs.GetInt ("CompletedStages");
		unlockedStages = completedStages + 1;

		for (int i = 0; i < stageButtons.Count; i++) {
			if (i < completedStages) {
				stageButtons[i].GetComponent<StageButtonScript>().Complete();
			} else if (i < unlockedStages) {
				stageButtons[i].GetComponent<StageButtonScript>().Unlock();
			} else {
				stageButtons[i].GetComponent<StageButtonScript>().Lock();
			}
		}

		Input.simulateMouseWithTouches = true;
	}
	
	// Update is called once per frame
	void Update () {
		float offset = -4.0f;
		player.transform.position = new Vector3((stage * 2.0f) + offset, 0.75f, -2.0f);

		if (Input.GetAxis ("Horizontal") == 1) {
			// Move Right
			if (stage < unlockedStages && stage < stageButtons.Count) {
				stage++;
			}
		} else if (Input.GetAxis("Horizontal") == -1) {
			// Move Left
			if (stage > 0) {
				stage--;
			}
		} else if (Input.GetButton("Fire1")) {
			// Select the stage
			PlayerPrefs.SetInt("SelectedStage", stage);
			PlayerPrefs.Save ();
			Application.LoadLevel ("Prototype");
		}
	}

	public void SelectStage(int index) {
		if (index >= 0 && index < unlockedStages) {
			stage = index;
		}
	}
}
