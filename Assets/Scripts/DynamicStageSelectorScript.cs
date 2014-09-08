using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DynamicStageSelectorScript : MonoBehaviour {
	private int stage           = 0;
	private int unlockedStages  = 1;
	private int completedStages = 0;
	public  int totalStages     = 99;

	public List<Transform> stageButtons;
	public Transform       player;
	public Transform       stageButton;
	//public Transform       stageConnector;

	public Text            levelDisplay;
	public Text            hpDisplay;
	public Text            xpDisplay;

	// Use this for initialization
	void Start () {
		completedStages = PlayerPrefs.GetInt ("CompletedStages");
		unlockedStages = completedStages + 1;

		for (int i = 0; i < totalStages; i++) {
			var newStage = Instantiate(stageButton) as Transform;
			newStage.transform.position = new Vector3(i * 2.0f, 0.0f, 0.0f);
			stageButtons.Add (newStage);
		}
		LineRenderer lr = this.GetComponent<LineRenderer>();
		lr.SetPosition(0, new Vector3(0.0f, 0.0f, 0.0f));
		lr.SetPosition(1, new Vector3((totalStages - 1) * 2.0f, 0.0f, 0.0f));

		for (int i = 0; i < stageButtons.Count; i++) {
			if (i < completedStages) {
				stageButtons[i].GetComponent<StageButtonScript>().Complete();
			} else if (i < unlockedStages) {
				stageButtons[i].GetComponent<StageButtonScript>().Unlock();
				stage = i;
			} else {
				stageButtons[i].GetComponent<StageButtonScript>().Lock();
			}
		}

		Input.simulateMouseWithTouches = true;
		LoadProgress ();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = 0.0f;
		player.transform.position = new Vector3((stage * 2.0f) + offset, 0.75f, -2.0f);

		if (Input.GetKeyDown("d")) {
			// Move Right
			if (stage < (unlockedStages - 1) && stage < (stageButtons.Count - 1)) {
				stage++;
			}
		} else if (Input.GetKeyDown("a")) {
			// Move Left
			if (stage > 0) {
				stage--;
			}
		} else if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
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

	void LoadProgress() {
		if (PlayerPrefs.HasKey ("XP")) {
			int xp       = PlayerPrefs.GetInt("XP");
			int xpToNext = PlayerPrefs.GetInt("XPToNext");
			int maxHp    = PlayerPrefs.GetInt("MaxHP");
			int level    = PlayerPrefs.GetInt("Level");
			levelDisplay.text = "Level: " + level.ToString();
			hpDisplay.text    = "HP: " + maxHp.ToString();
			xpDisplay.text    = "XP: " + xp.ToString() + " / " + xpToNext.ToString();
		}
	}
}
