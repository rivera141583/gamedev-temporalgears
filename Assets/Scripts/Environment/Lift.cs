using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
	[SerializeField] LightTest_Environment environment;
	[SerializeField] GameObject point_a;
	[SerializeField] GameObject point_b;
	[SerializeField] GameObject point_c;
	[SerializeField] bool cycle = false;
	[SerializeField] float duration = 35f;
	[SerializeField] float waitduration = 2f;

	void FixedUpdate()
    {
        if (environment.SteamPowerActivated && !cycle)
		{
			cycle = true;
			StartCoroutine(Wait1());
		}
	}

	IEnumerator Wait1()
	{
		Debug.Log("wait1");
		float elapsedTime = 0f;
		while (elapsedTime < waitduration)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(MoveMiddle());
	}

	IEnumerator MoveMiddle()
	{
		Debug.Log("MoveMiddle");

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float pos = Mathf.Lerp(transform.localPosition.y, point_a.transform.localPosition.y, elapsedTime / duration);

			transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(Wait2());
	}

	IEnumerator Wait2()
	{
		Debug.Log("wait2");

		float elapsedTime = 0f;
		while (elapsedTime < waitduration)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(MoveUp());
	}

	IEnumerator MoveUp()
	{
		Debug.Log("MoveUp");

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float pos = Mathf.Lerp(transform.localPosition.y, point_b.transform.localPosition.y, elapsedTime / duration);

			transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(Wait3());
	}

	IEnumerator Wait3()
	{
		Debug.Log("wait3");
		float elapsedTime = 0f;
		while (elapsedTime < waitduration)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(MoveMiddle2());
	}

	IEnumerator MoveMiddle2()
	{
		Debug.Log("MoveMiddle2");

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float pos = Mathf.Lerp(transform.localPosition.y, point_a.transform.localPosition.y, elapsedTime / duration);

			transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(Wait4());
	}

	IEnumerator Wait4()
	{
		Debug.Log("wait3");

		float elapsedTime = 0f;
		while (elapsedTime < waitduration)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(MoveDown());
	}

	IEnumerator MoveDown()
	{
		Debug.Log("MoveDown");

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float pos = Mathf.Lerp(transform.localPosition.y, point_c.transform.localPosition.y, elapsedTime / duration);

			transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		cycle = false;
	}
}
