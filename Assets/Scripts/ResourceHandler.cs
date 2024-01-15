using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public double health;
	public double maxhealth;
	public double magic;
	public double maxmagic;
	public double steam;
	public double maxsteam;

	public double bullets;
	public double maxbullets;

	bool paused = false;

	public HealthPointer uiHealth;
	public MagicPointer uiMagic;
	public SteamPointer uiSteam;

	public TextMeshProUGUI HealthText;
	public TextMeshProUGUI AmmoText;

	public TextMeshProUGUI Message;

	[SerializeField] public UnityEngine.UI.Image Gauge_0;
	[SerializeField] public UnityEngine.UI.Image Gauge_1;
	[SerializeField] public UnityEngine.UI.Image Gauge_2;
	[SerializeField] public UnityEngine.UI.Image Gauge_3;

	public bool gun = false;
	public bool sword = false;
	public bool steamboots = false;


	public Fadeout fade1; 
	public Fadeout fade2;

	// Start is called before the first frame update
	void Start()
	{
		DisplayMessage("Pres A or D to move. Press spacebar to jump. Press 1, 2, and 3 to switch weapons. Click with left mouse button to attack.", 12);
	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.P))
		{
			health += 10;
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			health -= 10;
		}
		if (Input.GetKeyDown(KeyCode.LeftBracket))
		{
			magic += 10;
		}
		if (Input.GetKeyDown(KeyCode.RightBracket))
		{
			magic -= 10;
		}
		if (Input.GetKeyDown(KeyCode.Semicolon))
		{
			steam += 10;
		}
		if (Input.GetKeyDown(KeyCode.Quote))
		{
			steam -= 10;
		}

		if (health > maxhealth)
		{
			health = maxhealth;
		}
		if (health <= 0)
		{
			StartCoroutine(Die());
			//fade1.DoFade2();
			//fade2.DoFade();
		}
		if (health < 0)
		{
			health = 0;
		}

		if (magic > maxmagic)
		{
			magic = maxmagic;
		}
		if (magic < 0)
		{
			magic = 0;
		}

		if (steam > maxsteam)
		{
			steam = maxsteam;
		}
		if (steam < 0)
		{
			steam = 0;
		}

		if (bullets > maxbullets)
		{
			bullets = maxbullets;
		}
		if (bullets < 0)
		{
			bullets = 0;
		}



		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			if (!paused)
			{
				Message.text = "Paused";
				Message.enabled = true;
				paused = true;
				Time.timeScale = 0;
			}
			else
			{
				Time.timeScale = 1;
				paused = false;
				Message.text = "";
				Message.enabled = false;
			}
		}

		uiHealth.health = (float)health;
		uiHealth.maxhealth = (float)maxhealth;
		uiMagic.magic = (float)magic;
		uiMagic.maxmagic = (float)maxmagic;
		uiSteam.steam = (float)steam;
		uiSteam.maxsteam = (float)maxsteam;

		HealthText.text = ((int)health).ToString();
		AmmoText.text = "x" + ((int)bullets).ToString();
	}

	public void OnPointerEnter(PointerEventData p)
	{
		Color color = new Color(1f, 1f, 1f, Gauge_0.color.a);
		if (Gauge_0.color.a > .25f)
		{
			color.a -= 0.01f;
		}
		else if (Gauge_0.color.a < 0.25f)
		{
			color.a = 0.25f;
		}
		Gauge_0.color = color;
		Gauge_1.color = color;
		Gauge_2.color = color;
		Gauge_3.color = color;
	}

	public void OnPointerExit(PointerEventData p)
	{
		StartCoroutine(FadeIn());
	}

	IEnumerator FadeIn()
	{
		while (Gauge_0.color.a != 1f)
		{
			Color color = new Color(1f, 1f, 1f, Gauge_0.color.a);
			if (Gauge_0.color.a < 1f)
			{
				color.a += 0.01f;
			}
			else if (Gauge_0.color.a > 1f)
			{
				color.a = 1f;
			}
			Gauge_0.color = color;
			Gauge_1.color = color;
			Gauge_2.color = color;
			Gauge_3.color = color;
			yield return null;
		}
	}

	public void DisplayMessage(string message, int seconds)
	{
		Message.enabled = true;
		Message.text = message;
		StartCoroutine(RemoveMessage(seconds));
	}

	IEnumerator RemoveMessage(int seconds)
	{
		int counter = seconds;
		while (counter > 0)
		{
			yield return new WaitForSeconds(1);
			counter--;
		}
		if (counter == 0)
		{
			Message.text = "";
			Message.enabled = false;
		}
	}

	IEnumerator Die ()
	{

		Message.text = "You died";
		Message.enabled = true;
		int counter = 5;
		while (counter > 0)
		{
			yield return new WaitForSeconds(1);
			counter--;
		}
		SceneManager.LoadScene("Menu");
	}
}
