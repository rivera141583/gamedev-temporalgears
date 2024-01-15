using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Pointer : MonoBehaviour
{
	[SerializeField] GameObject bullet;

	public Vector3 mousePos;
	public Vector2 lookDirection;

	void Update()
	{
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		lookDirection = (mousePos - transform.position);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
	}
}
