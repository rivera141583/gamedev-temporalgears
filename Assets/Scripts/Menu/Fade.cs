using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
	public TextMeshProUGUI text1;
	public TextMeshProUGUI text2;
	public Button button1;
	public Button button2;
	public Image image1;
	public Image image2;
	public TextMeshProUGUI text3;
	public TextMeshProUGUI text4;
	public SpriteRenderer sprite1;
	public SpriteRenderer sprite2;
	public Image blackout;

	float duration = 2f;

	bool part1 = true;
	bool part2 = false;
	bool part3 = false;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(Fade1());
	}

	IEnumerator Fade1()
	{
		Color startColor = text1.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			text1.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		text1.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		StartCoroutine(Fade2());
	}

	IEnumerator Fade2()
	{
		Color startColor = text2.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			text2.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		text2.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		StartCoroutine(Fade3());
	}

	IEnumerator Fade3()
	{
		Color startColor = sprite1.color;
		Color startColor2 = sprite2.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			sprite1.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			sprite2.color = new Color(startColor2.r, startColor2.g, startColor2.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		sprite1.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		sprite2.color = new Color(startColor2.r, startColor2.g, startColor2.b, 1f);
		StartCoroutine(Fade4());
	}
	IEnumerator Fade4()
	{
		Color startColor = image1.color;
		Color startColor2 = text3.color;

		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);

			image1.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			image2.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
			text3.color = new Color(startColor2.r, startColor2.g, startColor2.b, alpha);
			text4.color = new Color(startColor2.r, startColor2.g, startColor2.b, alpha);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		image1.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		image2.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		text3.color = new Color(startColor2.r, startColor2.g, startColor2.b, 1f);
		text4.color = new Color(startColor2.r, startColor2.g, startColor2.b, 1f);
	}

	public void StartGame()
	{
		StartCoroutine(Fade5());
	}

	IEnumerator Fade5()
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
		SceneManager.LoadScene("Map_0_Exposition");
	}
}
