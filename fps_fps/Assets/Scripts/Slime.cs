using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] GameObject damageFx;
	[SerializeField] NavMeshAgent navMeshAgent;
	[SerializeField] public GameObject player;
	[SerializeField] public GameManager gameManager;
	[SerializeField] bool isDead;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.isGameActive)
		{
			navMeshAgent.SetDestination(player.transform.position);
		}
		else
		{
			navMeshAgent.isStopped = true;
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Bullet") && !isDead)
		{
			isDead = true;
			navMeshAgent.isStopped = true;
			Instantiate(damageFx, transform.position, Quaternion.identity);
			animator.SetBool("isDead", true);
			StartCoroutine(DeadDelay());
			gameManager.ScoreUpdate();
		}
	}
	IEnumerator DeadDelay()
	{
		yield return new WaitForSeconds(1);
		Destroy(gameObject);
	}
}
