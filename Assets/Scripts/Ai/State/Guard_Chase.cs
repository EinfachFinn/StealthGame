using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Guard_Chase : MonoBehaviour
{
	public GuardAI AI;
	public Guard_Attack GuardAttack;
	public NavMeshAgent NavMesh;
	private float turnspeed = 100;

	void Awake()
	{
		AI = GetComponent<GuardAI>();
		NavMesh = GetComponent<NavMeshAgent>();
		GuardAttack = GetComponent<Guard_Attack>();
		
	}

	void TurnToPlayer()
	{
		// calculate the direction from this object to the target object
		Vector3 direction = AI.Player.transform.position - transform.position;

		// create the rotation we need to be in to look at the target
		Quaternion targetRotation = Quaternion.LookRotation(direction);

		// smooth rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);
	}
	void Update()
	{	
		TurnToPlayer();

		if(AI.DetectedPlayerHead || AI.DetectedPlayerHip || AI.DetectedPlayerTorso)
		{
			NavMesh.destination = AI.Player.transform.position;
			
			
		}
		
	}
}
