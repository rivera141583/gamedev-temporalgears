using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Short_Attack : MonoBehaviour
{

	[SerializeField] GameObject Short;
	public bool direction = true;

	public Char_Animation animationHandler;

	public ResourceHandler resource;

	[SerializeField] Char_Movement Char;

	float y = 0;

	void Start()
	{
		Short.SetActive(false);
		y = transform.localScale.y;
	}

	void Update()
	{
		if (direction)
		{
			transform.localScale = new Vector3(1, y, 1);
		}
		else
		{
			transform.localScale = new Vector3(-1, y, 1);
		}

		if (Input.GetMouseButtonDown(0))
		{
			Attack();
		}
	}

	public void Attack()
	{
		Short.SetActive(true);
		animationHandler.isAttacking = true;
		Char.isAttacking = true;
		StartCoroutine(BroadAttack());
	}

	IEnumerator BroadAttack()
	{
		int counter = 1;
		while (counter != 0)
		{
			yield return new WaitForSeconds(0.5f);
			counter--;
		}
		Short.SetActive(false);
		animationHandler.isAttacking = false;
		Char.isAttacking = false;

	}
}
