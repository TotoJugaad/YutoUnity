using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] int score;
	[SerializeField] int life = 10;
	[SerializeField] int clearScore = 10;
	[System.NonSerialized] public bool isGameActive = true;
	[SerializeField] GameObject gameOverText;
	[SerializeField] GameObject gameClearText;
	[SerializeField] TMP_Text scoreText;
	[SerializeField] TMP_Text lifeText;
	[SerializeField] GameObject damageFilter;
	[SerializeField] AudioSource audioSource;
	// Start is called before the first frame update
	void Start()
	{
		scoreText.text = "Score: " + score;
		lifeText.text = "Life: " + life;
	}
	public void ScoreUpdate()
	{
		score++;
		scoreText.text = "Score: " + score;
		if (score >= clearScore) { GameClear(); }
	}
	public void PlayerDamaged()
	{
		life--;
		lifeText.text = "Life: " + life;
		if (life <= 0) { GameOver(); }
		damageFilter.SetActive(true);
		StartCoroutine(DamageFilterDelay());
	}
	IEnumerator DamageFilterDelay()
	{
		yield return new WaitForSeconds(0.2f);
		damageFilter.SetActive(false);
	}
	void GameOver()
	{
		if (isGameActive)
		{
			isGameActive = false;
			gameOverText.SetActive(true);
			StartCoroutine(LoadSceneDelay());
		}
	}
	void GameClear()
	{
		if (isGameActive)
		{
			isGameActive = true;
			gameClearText.SetActive(true);
			StartCoroutine(LoadSceneDelay());
		}
	}
	IEnumerator LoadSceneDelay()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene("Title");
	}
}
