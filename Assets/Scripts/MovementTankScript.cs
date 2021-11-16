using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementTankScript : MonoBehaviour
{

	PhotonView view;
	Rigidbody rb;

	// Use this for initialization
	void Start()
	{

		view = GetComponent<PhotonView>();
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (view.isMine)
		{
			//keyboard control
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate(0, x, 0);
			transform.Translate(0, 0, z);
			//mobile control
			float xvalue = CrossPlatformInputManager.GetAxis("Horizontal");
			float yvalue = CrossPlatformInputManager.GetAxis("Vertical");
			Vector3 movement = new Vector3(xvalue, 0, yvalue);
			rb.velocity = movement * 7f;
			if(xvalue!=0&&yvalue!=0)
            {
				transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xvalue, yvalue) * Mathf.Rad2Deg, transform.eulerAngles.z);
            }

		}

	}
}
