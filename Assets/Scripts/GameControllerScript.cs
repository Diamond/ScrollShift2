using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public RectTransform xpBarFill;
	public RectTransform hpBarFill;
	public int xp       = 0;
	public int xpToNext = 3;
	public int hp       = 3;
	public int maxHp    = 3;
	public int level    = 1;
	public int stage    = 1;

	public Text levelDisplay;

	public PlayerScript playerScript;
	public EnemySpawnerScript esScript;
	public WallSpawnerScript wsScript;

	void Start() {
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
		esScript     = GameObject.Find ("EnemySpawner").GetComponent<EnemySpawnerScript>();
		wsScript     = GameObject.Find ("WallSpawner").GetComponent<WallSpawnerScript>();
		LoadProgress();
		esScript.Spawn(stage);
		wsScript.Spawn(stage);
	}
	
	// Update is called once per frame
	void Update () {
		if (xp >= xpToNext) {
			xpToNext += 5;
			xp = 0;
			playerScript.LevelUp();
			level++;
			maxHp = 3 + level;
			hp = maxHp;
		}

		BarSizeForValue(xp, xpToNext, xpBarFill);
		BarSizeForValue(hp, maxHp,    hpBarFill);
		levelDisplay.text = "Stage: " + stage.ToString() + " Player Level: " + level.ToString();
	}

	void BarSizeForValue(int val, int max, RectTransform barFill) {
		float percent = ((float)val / (float)max);
		float width = 392.0f * percent;
		barFill.sizeDelta = new Vector2(width, barFill.sizeDelta.y);
	}

	public void HurtPlayer(int damage=1) {
		hp -= damage;
		if (hp <= 0) {
			playerScript.Die();
		}
	}

	public void HealPlayer(int damage=1) {
		hp += damage;
		if (hp > maxHp) {
			hp = maxHp;
		}
	}

	public void SaveProgress() {
		PlayerPrefs.SetInt("XP", xp);
		PlayerPrefs.SetInt("XPToNext", xpToNext);
		PlayerPrefs.SetInt("MaxHP", maxHp);
		PlayerPrefs.SetInt("Level", level);
		PlayerPrefs.Save();
	}

	public void AddXp(int moarXp) {
		xp += moarXp;
	}

	public void LoadProgress() {
		if (PlayerPrefs.HasKey ("XP")) {
			xp       = PlayerPrefs.GetInt("XP");
			xpToNext = PlayerPrefs.GetInt("XPToNext");
			maxHp    = PlayerPrefs.GetInt("MaxHP");
			level    = PlayerPrefs.GetInt("Level");
			stage    = PlayerPrefs.GetInt("SelectedStage");
			stage++;
			hp       = maxHp;
		}
	}
}
