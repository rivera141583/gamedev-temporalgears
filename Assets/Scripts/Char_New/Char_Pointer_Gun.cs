using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Pointer_Gun : MonoBehaviour
{

	[SerializeField] Char_Animation animationHandler;
	[SerializeField] GameObject pointer;
	[SerializeField] Char_Pointer pointerScript;
	[SerializeField] GameObject bullet;

	public Vector2 lookDir;
	public Vector3 angl;
	public int gunAngle;

	// Start is called before the first frame update
	void Start()
    {
	}

    // Update is called once per frame
    void Update()
	{
		lookDir = pointerScript.lookDirection;
		angl = pointer.transform.eulerAngles;
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("butt");
			//if (resource.bullets > 0 && resource.gun && player.currentweapon == 1)
			if (true)
			{
				animationHandler.isAttacking = true;
				StartCoroutine(ShootFalse());
				//resource.bullets -= 1;
				GameObject instance = Instantiate(
										bullet,
										transform.position,
										Quaternion.identity
									  );
				instance.transform.rotation = Quaternion.LookRotation(Vector3.forward, pointerScript.mousePos - transform.position);
				Rigidbody2D bulletrg = instance.GetComponent<Rigidbody2D>();
				bulletrg.AddForce(pointerScript.lookDirection.normalized * 3000);
				Destroy(instance, 5);



				if (IsRotationInRange(pointer.transform.eulerAngles.z, 66f, 180f))
				{
					animationHandler.gunAngle = 0;
					animationHandler.direction = false;
					gunAngle = 0;
				}
				else if (IsRotationInRange(pointer.transform.eulerAngles.z, 25f, 66f))
				{
					animationHandler.gunAngle = 1;
					animationHandler.direction = false;
					gunAngle = 1;
				}
				else if (IsRotationInRange(pointer.transform.eulerAngles.z, 0f, 25f))
				{
					animationHandler.gunAngle = 2;
					animationHandler.direction = false;
					gunAngle = 2;
				}
				else if (IsRotationInRange(pointer.transform.eulerAngles.z, 180f, 294f))
				{
					animationHandler.gunAngle = 0;
					animationHandler.direction = true;
					gunAngle = 0;
				}
				else if (IsRotationInRange(pointer.transform.eulerAngles.z, 304, 345f))
				{
					animationHandler.gunAngle = 1;
					animationHandler.direction = true;
					gunAngle = 1;
				}
				else if (IsRotationInRange(pointer.transform.eulerAngles.z, 345f, 361f))
				{
					animationHandler.gunAngle = 2;
					animationHandler.direction = true;
					gunAngle = 2;
				}
			}
		}
	}

	bool IsRotationInRange(float angle, float min, float max)
	{
		//angle = (angle + 360f) % 360f;
		return (angle > min && angle <= max);
	}

	IEnumerator ShootFalse()
	{
		int counter = 1;
		while (counter != 0)
		{
			yield return new WaitForSeconds(0.5f);
			counter--;
		}
		animationHandler.isAttacking = false;
	}
}
