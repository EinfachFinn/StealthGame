using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(WaypointVisualizer))]
public class WaypointVisualizerEditor : Editor
{
	private SerializedProperty _waypoints;
	private SerializedProperty _waypointRadius;
	private bool _showWaypoints = true;
    
	private void OnEnable()
	{
		_waypoints = serializedObject.FindProperty("waypoints");
		_waypointRadius = serializedObject.FindProperty("waypointRadius");
	}
    
	public override void OnInspectorGUI()
	{
		serializedObject.Update();
        
		EditorGUILayout.PropertyField(_waypointRadius);
        
		_showWaypoints = EditorGUILayout.Foldout(_showWaypoints, "Waypoints");
		if (_showWaypoints)
		{
			EditorGUI.indentLevel++;
			int newSize = EditorGUILayout.IntField("Size", _waypoints.arraySize);
			if (newSize != _waypoints.arraySize)
			{
				_waypoints.arraySize = newSize;
			}
            
			for (int i = 0; i < _waypoints.arraySize; i++)
			{
				SerializedProperty waypoint = _waypoints.GetArrayElementAtIndex(i);
				EditorGUILayout.PropertyField(waypoint);
			}
            
			EditorGUI.indentLevel--;
		}
        
		serializedObject.ApplyModifiedProperties();
	}
}