using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Attack : MonoBehaviour
{
	public int damage = 100;
	public float waitTime = 2f;
	public Transform playerTransform;
	public GameObject muzzleFlashPrefab;
	public Transform muzzleFlashSpawnPoint;
	public AudioClip shootSound;

	private bool isShooting = false;
	private AudioSource audioSource;
	private GameObject muzzleFlash;

	private void Start()
	{
		// Get AudioSource component
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		// Check if player transform is set
		if (playerTransform == null)
		{
			return;
		}

		// Shoot raycast at player
		RaycastHit hit;
		if (Physics.Raycast(transform.position, playerTransform.position - transform.position, out hit))
		{
			// If raycast hits player and we're not already shooting, start shooting
			if (hit.transform.CompareTag("Player") && !isShooting)
			{
				StartCoroutine(Shoot());
			}
		}
	}

	IEnumerator Shoot()
	{
		// Set flag to indicate we're shooting
		isShooting = true;

		// Spawn muzzle flash prefab at muzzle flash spawn point and set it as a child of the enemy
		muzzleFlash = Instantiate(muzzleFlashPrefab, muzzleFlashSpawnPoint.position, muzzleFlashSpawnPoint.rotation, transform);

		// Play shoot sound
		audioSource.PlayOneShot(shootSound);
		playerTransform.GetComponentInChildren<PlayerStats>().Damage(damage);

		// Wait for waitTime seconds
		yield return new WaitForSeconds(waitTime);

		// Destroy muzzle flash
		Destroy(muzzleFlash);

		// Reset flag to indicate we're no longer shooting
		isShooting = false;
	}
}
