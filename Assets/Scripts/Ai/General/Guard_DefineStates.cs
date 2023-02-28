using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_DefineStates : MonoBehaviour
{
	private float Timer;
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
			AI.State = 0;
		}
		
		if(AI.IsInSight == true && AI.IsInRange == false)
		{
			AI.State = 2;
		}
		//if Guard has Coin etc
		if(AI.IsInSight == false && AI.IsInRange == false)
		{
			Timer += Time.deltaTime;
			if(Timer > 10)
			{
				AI.State = 1;
				AI.MaxViewDistance = SaveViewDistanste; 
				Timer = 0;
				AI.Light.range = AI.MaxViewDistance;
			}
		}else Timer = 0;
	    
		
		
		//Turn on and off scripts
		if(AI.State == 0)
		{
			AI.GuardAttack.enabled = true;
			AI.GuardPatrol.enabled = false;
			AI.GuardChase.enabled = false;
			
		}
		if(AI.State == 1)
		{
			AI.GuardAttack.enabled = false;
			AI.GuardPatrol.enabled = true;
			AI.GuardChase.enabled = false;
			
			
		}
		if(AI.State == 2)
		{
			AI.GuardAttack.enabled = false;
			AI.GuardPatrol.enabled = false;
			AI.GuardChase.enabled = true;
			
			
		}
		
    }
}
