using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] GameObject slime;
	[SerializeField] int interval = 2;
	[SerializeField] float spawnRange;
	[Header("to Slime")]
	[SerializeField] GameObject player;
	[SerializeField] GameManager gameManager;
	float timer;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.isGameActive)
		{
			timer += Time.deltaTime;
			if (timer >= interval)
			{
				Vector3 randomPos;
				float randomX = transform.position.x + Random.Range(-spawnRange, spawnRange);
				float randomZ = transform.position.z + Random.Range(-spawnRange, spawnRange);
				randomPos = new Vector3(randomX, transform.position.y, randomZ);
				//afasfdasfva

				GameObject newSlime = Instantiate(slime, randomPos, Quaternion.identity);

				newSlime.GetComponent<Slime>().player = player;
				newSlime.GetComponent<Slime>().gameManager = gameManager;

				timer = 0;
			}
		}
	}
}
