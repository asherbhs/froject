using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private float speed = 0.1f;

	// Start is called before the first frame update
	void Start() {}

	// Update is called once per frame
	void Update()
	{
		// move according to user input
		transform.Translate
		(
			Input.GetAxis("Horizontal") * speed, // x
			Input.GetAxis("Vertical")   * speed, // y
			0 // z (none since it's a 2d game)
		);
	}
}
