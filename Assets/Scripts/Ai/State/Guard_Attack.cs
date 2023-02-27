using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Attack : MonoBehaviour
{
	private GuardAI AI;
	
	void Awake()
	{
	    AI = GetComponent<GuardAI>();
    }

   
	void Update()
	{
		
    }
}
