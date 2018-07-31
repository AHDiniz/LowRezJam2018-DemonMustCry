using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackSystem : MonoBehaviour
{
	public bool isCircle = true, isRect = false;
	public int meleeDamage;
	public float circleRadius;
	public float rectX, rectY;
	public Transform meleePosition;
	public float meleeCooldown;
	public LayerMask enemiesLayer;

	private float meleeTimer;

	private void Update()
	{
		MeleeAttack();
	}

	private void MeleeAttack()
	{
        if (meleeTimer <= 0 && Input.GetButtonDown("Fire1"))
		{
			meleeTimer = meleeCooldown;
			Collider2D[] enemies;
			if (isCircle && !isRect)
				enemies = Physics2D.OverlapCircleAll(meleePosition.position, circleRadius, enemiesLayer);
			else if (!isCircle && isRect)
                enemies = Physics2D.OverlapBoxAll(meleePosition.position, new Vector2(rectX, rectY), enemiesLayer, 0);
		}
		else
			meleeTimer -= Time.deltaTime;
	}
}
