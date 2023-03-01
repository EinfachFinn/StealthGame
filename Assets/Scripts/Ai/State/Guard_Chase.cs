using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Guard_Chase : MonoBehaviour
{
	[SerializeField] private float Timer;
	public GuardAI AI;
	public Guard_Attack GuardAttack;
	public Guard_DefineStates GuardStates;
	public NavMeshAgent NavMesh;
	private float turnspeed = 100;
	//public float ChaseMaxViewDistance = 8;

	void Awake()
	{
		AI = GetComponent<GuardAI>();
		NavMesh = GetComponent<NavMeshAgent>();
		GuardAttack = GetComponent<Guard_Attack>();
		GuardStates = GetComponent<Guard_DefineStates>();
		
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
			//public float ChaseMaxViewDistance = 8;AI.MaxViewDistance = ChaseMaxViewDistance;
			AI.Light.range = AI.MaxViewDistance;
			AI.GuardAnimator.SetBool("Chase", true);
			
		}
		else if (NavMesh.remainingDistance < 0.5f)
		{
			AI.GuardAnimator.SetBool("Chase", false);
			AI.GuardAnimator.SetTrigger("LookAround");
		
				Timer += Time.deltaTime;
			if(Timer > 11)
				{
					AI.GuardAnimator.SetBool("Chase", false);
					GuardStates.ChaseEnded();
				
				}
		}else Timer = 0;
		
		
		
	}
}
