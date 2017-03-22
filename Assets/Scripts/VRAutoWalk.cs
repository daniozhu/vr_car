using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAutoWalk : MonoBehaviour {

	public float speed = 1.0f;

	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject mainCamera = GameObject.Find ("Main Camera");
		if (mainCamera == null)
			return;
		
		Vector3 movement = Vector3.zero;

		if (Input.GetKey (KeyCode.UpArrow)) {
			movement = mainCamera.transform.TransformDirection (Vector3.forward);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			movement = mainCamera.transform.TransformDirection (Vector3.back);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			movement = mainCamera.transform.TransformDirection (Vector3.left);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			movement = mainCamera.transform.TransformDirection (Vector3.right);
		}

		if (movement != Vector3.zero)
			controller.SimpleMove (movement * speed);
	}
}
