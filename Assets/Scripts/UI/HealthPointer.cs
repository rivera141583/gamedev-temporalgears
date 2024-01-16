using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class HealthPointer : MonoBehaviour
{
	[SerializeField] float speed;

	public float health;
	public float maxhealth;
	float currentangle;
	const float maxangle = 272f;
	const float minangle = 136f;

	UnityEngine.UI.Image image;
	RectTransform imgtransf;

	private Coroutine rotateCoroutine;

	float previousAngle;

	// Start is called before the first frame update
	void Start()
    {
		maxhealth = 100;
		
		image = GetComponent<UnityEngine.UI.Image>();
		imgtransf = GetComponent<RectTransform>();

		currentangle = imgtransf.rotation.z;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		float angle = minangle - ((health * maxangle) / maxhealth);
		if (Math.Abs(angle) != Math.Abs(currentangle))
		{
			if (rotateCoroutine != null && previousAngle != angle)
			{
				StopCoroutine(rotateCoroutine);
			}
			Debug.Log("Angle:" + angle + "; PreviousAngle:" + previousAngle);
			Debug.Log("Angle:" + minangle + " - ((" + health + " * " + maxangle + ") / " + maxhealth + ") = " + angle);
			rotateCoroutine = StartCoroutine(RotateToAngle(angle));
		}
	}

	IEnumerator RotateToAngle(float angle)
	{
		currentangle = angle;
		previousAngle = angle;
		float startAngle = currentangle;
		float elapsedTime = 0f;
		float duration = Mathf.Abs((angle - startAngle) / speed);

		while (elapsedTime < duration)
		{
			float currentAngle = Mathf.Lerp(startAngle, angle, elapsedTime / duration);
			imgtransf.rotation = Quaternion.Euler(0f,0f,currentAngle);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		imgtransf.rotation = Quaternion.Euler(0f, 0f, angle);
	}
}
