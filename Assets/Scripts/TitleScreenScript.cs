using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public void Play() {
		Application.LoadLevel ("stageselect");
	}

	public void Quit() {
		Application.Quit();
	}
}
