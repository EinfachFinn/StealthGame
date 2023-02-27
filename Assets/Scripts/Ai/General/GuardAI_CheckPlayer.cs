using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI_CheckPlayer : MonoBehaviour
{
	
	public GuardAI AI;
	private bool DetectTimerBool;
	void Enabled()
	{
		AI = GetComponent<GuardAI>();
	}
	
    // Update is called once per frame
	public void Update()
	{
		

		
		//Calculate CurrentShootRange
		AI.CurrentShootRange = Vector3.Distance(AI.Player.transform.position, AI.GuardCamObject.transform.position);
		if(AI.CurrentShootRange < AI.MaxShootRange) {AI.IsInRange = true;} else{AI.IsInRange = false;}
		
		
		if (AI.DetectedPlayerHead && AI.DetectedPlayerHip || AI.DetectedPlayerHead && AI.DetectedPlayerTorso || AI.DetectedPlayerHip && AI.DetectedPlayerTorso)
		{
			DetectTimerBool = true;
		}
		else
		{
			DetectTimerBool = false;
		}

		
		//if Player is in MaxViewDistance
		if (Vector3.Distance(transform.position,AI.Player.transform.position) < AI.MaxViewDistance) 
		{	
			//Debug.Log("is in ViewDistance");
			Vector3 dirToPlayer = (AI.Player.transform.position - AI.GuardCamObject.transform.position).normalized;
			
				
			float angleBetweenGuardAndPlayer = Vector3.Angle (AI.GuardCamObject.transform.forward, dirToPlayer);
			if (angleBetweenGuardAndPlayer < AI.viewAngle / 2f) 
			{
					
				//Check if detects PlayerPart
				if (!Physics.Linecast (AI.GuardCamObject.transform.position, AI.PlayerDetectHead.position, AI.viewMask)) 
				{
					AI.DetectedPlayerHead = true;
				}
				else
				{
					AI.DetectedPlayerHead = false;

				}
							
				if (!Physics.Linecast (AI.GuardCamObject.transform.position, AI.PlayerDetectTorso.position, AI.viewMask)) 
				{
					AI.DetectedPlayerTorso = true;
				}
				else
				{
					AI.DetectedPlayerTorso = false;

				}		
							
				if (!Physics.Linecast (AI.GuardCamObject.transform.position, AI.PlayerDetectHip.position, AI.viewMask)) 
				{
					AI.DetectedPlayerHip = true;
				}
				else
				{
					AI.DetectedPlayerHip = false;

				}
						
			}
			else
			{
				DetectTimerBool = false;
				AI.DetectedPlayerHip = false;
				AI.DetectedPlayerHead = false;
				AI.DetectedPlayerTorso = false;

			}
		}
		else
		{
			DetectTimerBool = false;
			AI.DetectedPlayerHip = false;
			AI.DetectedPlayerHead = false;
			AI.DetectedPlayerTorso = false;
		}
		
		
		
		
		//Detect Timer
		if (DetectTimerBool == true)
		{
			AI.Light.color =  Color.yellow;
			AI.CurrentDetectTimer -= Time.deltaTime;
			if (AI.CurrentDetectTimer < 0)
			{
				AI.IsInSight = true;
				AI.Light.color = Color.red;
			}
			else
			{
				AI.IsInSight = false;
			}
		}
		else 
		{	AI.IsInSight = false;
			AI.CurrentDetectTimer = AI.DetectTime;
			AI.Light.color = Color.white;
		}
		

	}
	
    
}
