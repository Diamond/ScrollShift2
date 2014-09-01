using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public RectTransform xpBarFill;
	public RectTransform hpBarFill;
	public int xp = 0;
	public int xpToNext = 10;
	public int hp = 3;
	public int maxHp = 3;
	
	// Update is called once per frame
	void Update () {
		if (xp >= xpToNext) {
			xpToNext += 5;
			xp = 0;
		}

		BarSizeForValue(xp, xpToNext, xpBarFill);
		BarSizeForValue(hp, maxHp,    hpBarFill);
	}

	void BarSizeForValue(int val, int max, RectTransform barFill) {
		float percent = ((float)val / (float)max);
		float width = 392.0f * percent;
		barFill.sizeDelta = new Vector2(width, barFill.sizeDelta.y);
	}
}
