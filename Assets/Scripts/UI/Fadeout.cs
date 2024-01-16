using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
	Image blackout;

	float duration = 2f;

	// Start is called before the first frame update
	void Start()
    {
        blackout = GetComponent<Image>();
		StartCoroutine(Fade5());
    }

	public void DoFade()
	{
		StartCoroutine(Fade6());
	}
	public void DoFade2()
	{
		StartCoroutine(Fade7());
	}

	IEnumerator Fade5()
	{

		Color startColor = blackout.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

			blackout.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		blackout.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
	}
	IEnumerator Fade6()
	{

		Color startColor = blackout.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			blackout.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		blackout.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
	}
	IEnumerator Fade7()
	{

		Color startColor = blackout.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			blackout.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		blackout.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		SceneManager.LoadScene("Menu");
	}
}
