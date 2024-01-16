using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exposition : MonoBehaviour
{
	[SerializeField] List<TextMeshProUGUI> texts;
	[SerializeField] int duration;
    // Start is called before the first frame update
    void Start()
	{
		StartCoroutine(FadeIn(0));
	}



	IEnumerator FadeIn(int index)
	{
		Color startColor = texts[index].color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			texts[index].color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		texts[index].color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		StartCoroutine(Persist(index));
	}

	IEnumerator Persist(int index)
	{
		Color startColor = texts[index].color;

		float elapsedTime = 0f;
		while (elapsedTime < duration * 4)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		StartCoroutine(FadeOut(index));
	}

	IEnumerator FadeOut(int index)
	{
		Color startColor = texts[index].color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

			texts[index].color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		texts[index].color = new Color(startColor.r, startColor.g, startColor.b, 0f);

		if (index+1 < texts.Count)
		{

			StartCoroutine(FadeIn(index + 1));
		}
		else
		{
			Debug.Log("Done");
			SceneManager.LoadScene("Light_Test");
		}
	}
}
