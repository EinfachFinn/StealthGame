﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour
{
	
	[Header("State ")]
	[Range(0,2)]
	public int State = 1;
	[Space]
	[SerializeField] private string State0 = "Attack";
	[SerializeField] private string State1 = "Patrol";
	[SerializeField] private string State2 = "Chase";
	[Space]
	[Space]
	[Space]
	
	
	[Header("Stats")]
	public float MaxShootRange;
	public float MaxViewDistance;
	public float viewAngle;
	public LayerMask viewMask;
	public GameObject GuardCamObject;
	public float DetectTime;
	public Animator GuardBehaviour;
	[Space]
	[Space]
	[Space]

	[Header("Debug")]
	[Header("Debug: Detect")]
	public float CurrentDetectTimer;
	public bool IsInSight;
	public bool DetectedPlayerHead;
	public bool DetectedPlayerTorso;
	public bool DetectedPlayerHip;
	[Header("Debug: Shoot Distance ")]
	public float CurrentShootRange;
	public bool IsInRange;
	[Space]
	[Space]
	[Space]
	
	
	
	[Header("SetUp")]
	
	[Header("Player")]
	public GameObject Player;
	public Transform PlayerDetectHead;
	public Transform PlayerDetectTorso;
	public Transform PlayerDetectHip;
	[Header("OtherStuff")]
	public Light Light;
	public Guard_Chase GuardChase;
	public Guard_Attack GuardAttack;
	public GuardAI_CheckPlayer GuardCheck;
	public Guard_Patrol GuardPatrol;
	
	void Awake()
	{
		GuardCheck = GetComponent<GuardAI_CheckPlayer>();
	
	
		GuardAttack = GetComponent<Guard_Attack>();
		GuardPatrol = GetComponent<Guard_Patrol>();
		GuardChase = GetComponent<Guard_Chase>();
		
	}
	
	
    // Update is called once per frame
    void Update()
	{
	
	
	}

}