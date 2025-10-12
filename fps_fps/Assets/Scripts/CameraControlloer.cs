using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlloer : MonoBehaviour
{
	float xCameraRotation;
	float yPlayerRotation;
	[SerializeField] float sense;
	[SerializeField] GameObject player;
	// Start is called before the first frame update
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update()
	{
		float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime;

		xCameraRotation -= mouseY * sense / 4;
		yPlayerRotation += mouseX * sense / 4;

		xCameraRotation = Mathf.Clamp(xCameraRotation, -45, 45);

		player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, yPlayerRotation, 0);

		transform.rotation = Quaternion.Euler(xCameraRotation, yPlayerRotation, 0);
	}
}
