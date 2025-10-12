using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] bool canDamage = true;
	[SerializeField] int damageInterval = 1;
	[Header("Settings")]
	[SerializeField] float speed;
	[SerializeField] float jumpSpeed;
	[SerializeField] bool isGround;
	float timer;
	[Space(10)]
	[SerializeField] CharacterController controller;
	[SerializeField] GameManager gameManager;

	Vector3 moveDirection;
	Vector3 velocity;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		float moveX = Input.GetAxis("Horizontal") * Time.deltaTime;
		float moveZ = Input.GetAxis("Vertical") * Time.deltaTime;
		moveDirection = transform.right * moveX + transform.forward * moveZ;
		/*moveDirection = new Vector3(moveX, 0, moveZ);*/
		moveDirection = moveDirection.normalized;
		controller.SimpleMove(moveDirection * speed);
		
		if (Input.GetButtonDown("Jump")&& isGround)
		{
			velocity.y = jumpSpeed;
		}
		/*if (Input.GetButtonDown("Fire1"))*/
		velocity.y += Physics.gravity.y * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		//Damage 
		if (!canDamage)
		{
			timer += Time.deltaTime;
			if (timer >= damageInterval)
			{
				canDamage = true;
				timer = 0;
			}
		}
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			isGround = true;
		}
		if (other.gameObject.CompareTag("Enemy") && canDamage) 
		{
			gameManager.PlayerDamaged();
			canDamage = false;
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy") && canDamage)
		{
			gameManager.PlayerDamaged();
			canDamage = false;
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			isGround = false;
		}
	}
}
