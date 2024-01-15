using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Broad : MonoBehaviour
{
	[SerializeField] GameObject b;
	[SerializeField] float lerpDuration;
	bool rotating;
	public bool direction = true;
	float originalScale;

	public Char_AnimationHandler animationHandler;
	Quaternion endAngle;

	public GameObject sword;

	public ResourceHandler resource;

	private Rigidbody2D body;
	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		originalScale = this.transform.localScale.x;
		endAngle = Quaternion.Euler(0, 0, -80);
		sword.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		body.transform.position = new Vector2(b.transform.position.x, b.transform.position.y);
		if (Input.GetMouseButtonDown(0) && resource.sword)
		{
			animationHandler.isSwinging = true;
			StartCoroutine(Rotate());
			sword.SetActive(true);
			
		}


		if (body.transform.rotation == endAngle)
		{
			animationHandler.isSwinging = false;
			sword.SetActive(false);
		}
		if (direction)
		{
			if (body.transform.rotation == Quaternion.Euler(0, 0, -80) || body.transform.rotation == Quaternion.Euler(0, 0, 80))
			{
				endAngle = Quaternion.Euler(0, 0, -80);
			}
			this.transform.localScale = new Vector3(originalScale, originalScale, originalScale);
		}
		else
		{
			if (body.transform.rotation == Quaternion.Euler(0, 0, -80) || body.transform.rotation == Quaternion.Euler(0, 0, 80))
			{
				endAngle = Quaternion.Euler(0, 0, 80);
			}
			this.transform.localScale = new Vector3(-originalScale, originalScale, originalScale);
		}
	}

	IEnumerator Rotate()
	{
		//Debug.Log("rot: " + DateTime.Now.ToString("HH:mm:ss"));
		rotating = true;
		float timeElapsed = 0;
		Quaternion startRotation = Quaternion.Euler(0, 0, 80);
		Quaternion targetRotation = Quaternion.Euler(0, 0, -80);
		if (direction)
		{
			startRotation = Quaternion.Euler(0, 0, 80);
			targetRotation = Quaternion.Euler(0, 0, -80);
		}
		else
		{
			startRotation = Quaternion.Euler(0, 0, -80);
			targetRotation = Quaternion.Euler(0, 0, 80);
		}
		while (timeElapsed < lerpDuration)
		{
			body.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		body.transform.rotation = targetRotation;
		rotating = false;
	}

	private void Attack()
	{
	}
}
