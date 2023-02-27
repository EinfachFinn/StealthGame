﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard_Patrol : MonoBehaviour
{
	[SerializeField]private Transform[] waypoints; // an array of waypoints to patrol between
	private float moveSpeed; // the speed at which to move between waypoints
	[SerializeField]private float waypointRadius = 0.5f; // the radius within which the AI will consider a waypoint "reached"
	[SerializeField]private float waitTime = 3f; // the time the AI will wait at each waypoint
	[SerializeField]private float lookAroundTime = 2f; // the time the AI will spend looking around at each waypoint

	private NavMeshAgent NavMesh; // the NavMeshAgent component attached to this gameobject
	private int currentWaypointIndex = 0; // the index of the current waypoint in the waypoints array
	private bool waiting = false; // a flag to indicate whether the AI is waiting at a waypoint
	private float waitStartTime; // the time at which the AI started waiting at the current waypoint

	void Start()
	{
		NavMesh = GetComponent<NavMeshAgent>();
		moveSpeed = NavMesh.speed;
		SetDestination();
	}

	void Update()
	{
		if (waiting) // if the AI is currently waiting
		{
			if (Time.time - waitStartTime >= lookAroundTime) // if the look-around time has elapsed
			{
				waiting = false;
				SetDestination();
			}
		}
		else if (NavMesh.remainingDistance <= waypointRadius && !NavMesh.pathPending) // if the AI has reached the current waypoint
		{
			waiting = true;
			waitStartTime = Time.time;
			StartCoroutine(LookAround());
		}
	}

	void SetDestination()
	{
		NavMesh.SetDestination(waypoints[currentWaypointIndex].position);
		NavMesh.speed = moveSpeed;
	}

	IEnumerator LookAround()
	{
		float lookAngle = 0f;

		while (waiting)
		{
			Quaternion lookRotation = Quaternion.Euler(0f, lookAngle, 0f);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

			lookAngle += Time.deltaTime * 90f / lookAroundTime;

			yield return null;
		}

		currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
		SetDestination();
	}
}