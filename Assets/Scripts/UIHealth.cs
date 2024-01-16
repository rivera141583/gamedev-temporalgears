using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
	[SerializeField] float lerpDuration;

	public double health;
	public double maxhealth;
	double currentangle;
	const double maxangle = 272;
	const double minangle = 136;

    // Start is called before the first frame update
    void Start()
    {
		maxhealth = 100;
		currentangle = this.transform.rotation.z;
	}

    // Update is called once per frame
    void Update()
    {

		double angle = minangle - ((health * maxangle) / maxhealth);
		if (angle != currentangle)
		{
			Debug.Log("Angle:" + minangle + " - ((" + health + " * " + maxangle + ") / " + maxhealth + ") = " + angle);
			StartCoroutine(Rotate(angle));
		}
	}

	IEnumerator Rotate(double angle)
	{
		float timeElapsed = 0;
		Quaternion startRotation = Quaternion.Euler(0, 0, (float)currentangle);
		Quaternion targetRotation = Quaternion.Euler(0, 0, (float)angle);
		while (timeElapsed < lerpDuration)
		{
			this.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		this.transform.rotation = targetRotation;
		currentangle = angle;
	}

}
