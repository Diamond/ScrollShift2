using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	public void Play() {
		Application.LoadLevel ("prototype");
	}

	public void Quit() {
		Application.Quit();
	}
}
