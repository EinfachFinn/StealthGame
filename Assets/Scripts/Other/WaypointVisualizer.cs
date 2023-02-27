using UnityEngine;
using UnityEditor;

public class WaypointVisualizer : MonoBehaviour
{
	public Transform[] waypoints;
	public float waypointRadius = 0.5f;

	private void OnDrawGizmosSelected()
	{
		if (waypoints == null) return;
        
		Gizmos.color = Color.magenta;
		for (int i = 0; i < waypoints.Length; i++)
		{
			if (waypoints[i] != null)
			{
				Gizmos.DrawSphere(waypoints[i].position, waypointRadius);
                
				if (i < waypoints.Length - 1 && waypoints[i + 1] != null)
				{
					Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
				}
			}
		}
	}
}