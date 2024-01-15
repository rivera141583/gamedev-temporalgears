using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
	public float FollowSpeed = 2f;
	public Transform target;

	public float FixedHeight;
	public float FixedHorizontal;

	public bool FreezeX;
	public bool FreezeY;

	public float maxLeftX;
	public float maxRightX;
	public float maxDownY;
	public float maxUpY;

	// Start is called before the first frame update
	void Start()
    {
        FixedHeight = transform.position.y;
		FixedHeight = transform.position.x;
	}

    // Update is called once per frame
    void Update()
	{
		float toX = target.position.x;
		float toY = target.position.y;
		if (FreezeX)
		{
			toX = FixedHorizontal;
		}
		if (FreezeY)
		{
			toY = FixedHeight;
		}

		if (toX < maxLeftX)
		{
			toX = maxLeftX;
		}
		else if (toX > maxRightX)
		{
			toX = maxRightX;
		}

		if (toY < maxDownY)
		{
			toY = maxDownY;
		}
		else if (toY > maxUpY)
		{
			toY = maxUpY;
		}
		Vector3 newPos = new Vector3(toX, toY, -10f);
		//transform.position = new Vector3 (Mathf.Lerp(transform.position.x, newPos.x, FollowSpeed * Time.deltaTime), FixedHeight, newPos.z);
		transform.position = new Vector3(
				Mathf.Lerp(transform.position.x, newPos.x, FollowSpeed * Time.deltaTime),
				Mathf.Lerp(transform.position.y, newPos.y, FollowSpeed * Time.deltaTime),
				newPos.z
			);
	}
}
