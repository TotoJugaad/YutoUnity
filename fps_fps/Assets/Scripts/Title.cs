using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	[SerializeField] AudioClip buttonSE;
	[SerializeField] AudioSource audioSource;
	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public void GameStart()
	{
		audioSource.PlayOneShot(buttonSE);
		StartCoroutine(GameStartDelay());
	}
	IEnumerator GameStartDelay()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("SampleScene");
	}
}
