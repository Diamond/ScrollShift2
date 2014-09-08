using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public void Play() {
		Application.LoadLevel ("stageselect");
	}

	public void Quit() {
		Application.Quit();
	}

	public void ResetProgress() {
		PlayerPrefs.SetInt("XP", 0);
		PlayerPrefs.SetInt("XPToNext", 3);
		PlayerPrefs.SetInt("MaxHP", 3);
		PlayerPrefs.SetInt("Level", 1);
		PlayerPrefs.SetInt("SelectedStage", 1);
		PlayerPrefs.SetInt("CompletedStages", 0);
		PlayerPrefs.Save();
	}
}
