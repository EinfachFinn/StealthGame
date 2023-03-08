using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Attack : MonoBehaviour
{
	private GuardAI AI;
	private int range = 30;
	private bool canShootAtPlayer = true;
	public AudioSource enemyFire;
	public GameObject player;
	private int damage = 10;
	
	
	void Awake()
	{
	    AI = GetComponent<GuardAI>();
    }

	void ShootAtPlayer()
	{
		Ray rayFrom = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(rayFrom, out hit, range))
		{

			if (hit.collider.CompareTag("Player"))
			{

				if (canShootAtPlayer)
				{

					StartCoroutine(FireGun());

				}

			}

		}

	}

	IEnumerator FireGun()
	{

		canShootAtPlayer = false;

		gameObject.GetComponent<Animator>().Play("Shoot");

		enemyFire.Play();

		yield return new WaitForSeconds(1.2f);

		canShootAtPlayer = true;

	}
	
	
	void Update()
	{
		
    }
}
