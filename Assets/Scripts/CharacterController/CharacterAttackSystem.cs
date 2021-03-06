﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackSystem : MonoBehaviour
{
	public int meleeDamage;
	public int health;
	public float circleRadius;
	public Transform meleePosRight, meleePosLeft;
	public float meleeCooldown;
	public LayerMask enemiesLayer;

	private float meleeTimer;
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		MeleeAttack();
	}

	private void MeleeAttack()
	{
        if (meleeTimer <= 0)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				meleeTimer = meleeCooldown;
				Collider2D[] enemies = (spriteRenderer.flipX) ? Physics2D.OverlapCircleAll(meleePosLeft.position, circleRadius, enemiesLayer) : Physics2D.OverlapCircleAll(meleePosRight.position, circleRadius, enemiesLayer);
				for (int i = 0; i < enemies.Length; i++)
				{
					Enemy enemy = enemies[i].GetComponent<Enemy>();
					if (enemy != null)
						enemy.TakeDamage(meleeDamage);
				}
			}
			meleeTimer = meleeCooldown;
		}
		else
			meleeTimer -= Time.deltaTime;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(meleePosLeft.position, circleRadius);
        Gizmos.DrawWireSphere(meleePosRight.position, circleRadius);
	}
}
