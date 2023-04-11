using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_DefineStates : MonoBehaviour
{

	//This Script turns on and off States and Scripts
	public GuardAI AI;
	
	private float SaveViewDistanste;
	
	void Awake()
	{
		SaveViewDistanste = AI.MaxViewDistance;
		AI = GetComponent<GuardAI>();
	}
    // Update is called once per frame
    void Update()
	{
		if(AI.IsInSight == true && AI.IsInRange == true)
		{
			AI.GuardAttack.enabled = true;
		}
		else
		{
			AI.GuardAttack.enabled = false;
		}
		
		if(AI.IsInSight == true)
		{
			AI.State = 2;
			AI.GuardAnimator.SetBool("Chase", true);
		}

		
		
	
	
		if(AI.State == 1)
		{
			AI.GuardAttack.enabled = false;
			AI.GuardPatrol.enabled = true;
			AI.GuardChase.enabled = false;
			Debug.Log("IsInPatrolMode");
		}
		if(AI.State == 2)
		{
			AI.GuardPatrol.enabled = false;
			AI.GuardChase.enabled = true;
			
			
		}
		
	}
    
	public void ChaseEnded()
	{
		AI.State = 1;
		AI.MaxViewDistance = SaveViewDistanste; 
		AI.Light.range = AI.MaxViewDistance;
		Debug.Log("ChaseEnded");
	}
	
}
