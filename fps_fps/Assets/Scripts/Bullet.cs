using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] int lifeTime = 2;
	//[SerializeField] GameObject bulletHitFx;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject, lifeTime);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnCollisionEnter(Collision collision)
	{
		//Instantiate(bulletHitFx, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
