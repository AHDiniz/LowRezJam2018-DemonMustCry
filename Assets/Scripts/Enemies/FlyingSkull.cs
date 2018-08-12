using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSkull : Enemy
{
	public float speed;

	private void Start()
	{

	}

	private void Update()
	{
		transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider2D col)
	{
		if (col.gameObject.layer == 10)
		{
			// col.gameObject.GetComponent<>
		}
	}
}
