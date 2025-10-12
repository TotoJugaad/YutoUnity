using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject firePoint;
	[SerializeField] ParticleSystem fireFx;
	[SerializeField] int shootPower;
	[SerializeField] AudioSource audioSource;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			fireFx.Play();

			audioSource.Play();

			GameObject newBullet = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
			newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower, ForceMode.Impulse);
		}
	}
}