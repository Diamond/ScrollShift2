using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageButtonScript : MonoBehaviour {

	public  Sprite lockedSprite;
	public  Sprite unlockedSprite;
	public  Sprite completeSprite;
	public  int    stageNumber = 1;
	private DynamicStageSelectorScript _ssScript;

	void Start() {
		_ssScript = GameObject.Find ("StageSelector").GetComponent<DynamicStageSelectorScript>();
	}

	public void Lock() {
		this.GetComponent<SpriteRenderer>().sprite = lockedSprite;
	}

	public void Unlock() {
		this.GetComponent<SpriteRenderer>().sprite = unlockedSprite;
	}

	public void Complete() {
		this.GetComponent<SpriteRenderer>().sprite = completeSprite;
	}

	void OnMouseDown() {
		_ssScript.SelectStage(stageNumber);
	}
}
