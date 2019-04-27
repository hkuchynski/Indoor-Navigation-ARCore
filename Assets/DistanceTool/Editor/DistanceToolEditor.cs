/*
 * Created by Wes McDermott - 2011 - the3dninja.com/blog
*/

using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
[CustomEditor(typeof(DistanceTool))]

public class DistanceToolEditor : Editor
{
	DistanceTool _target;
	GUIStyle style = new GUIStyle();
	public static int count = 0;
	
	void OnEnable(){
		//i like bold handle labels since I'm getting old:
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.white;
		_target = (DistanceTool)target;
		
		//lock in a default path name:
		if(!_target.initialized){
			_target.initialized = true;
			_target.distanceToolName = "Distance Tool " + ++count;
			_target.initialName = _target.distanceToolName;
		}
	}
	
	public override void OnInspectorGUI(){		
		
		if(_target.distanceToolName == ""){
			_target.distanceToolName = _target.initialName;
		}
		
		
		//UI:
		EditorGUILayout.BeginVertical();
		
		EditorGUILayout.PrefixLabel("Name");
		_target.distanceToolName = EditorGUILayout.TextField(_target.distanceToolName,GUILayout.ExpandWidth(false));
		
		EditorGUILayout.Separator();
		EditorGUILayout.Separator();
		
		EditorGUILayout.PrefixLabel("Gizmo Radius");
		_target.gizmoRadius =  Mathf.Clamp(EditorGUILayout.Slider(_target.gizmoRadius, 0.1f, 3.0f, GUILayout.ExpandWidth(false)), 0.1f,100);
		
		EditorGUILayout.Separator();

        EditorGUILayout.PrefixLabel("Text Color");
        _target.textColor = EditorGUILayout.ColorField(_target.textColor, GUILayout.ExpandWidth(false));

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();


        EditorGUILayout.PrefixLabel("Tool Color");
		_target.lineColor = EditorGUILayout.ColorField(_target.lineColor,GUILayout.ExpandWidth(false));
		
		EditorGUILayout.Separator();
		EditorGUILayout.Separator();
		
		_target.scaleToPixels = EditorGUILayout.Toggle("Show scale/pixel", _target.scaleToPixels, GUILayout.ExpandWidth(false));
		
		_target.pixelPerUnit = EditorGUILayout.IntField("pixels per unit", _target.pixelPerUnit , GUILayout.ExpandWidth(false));
		
		EditorGUILayout.EndVertical();
		
		//update and redraw:
		if(GUI.changed){
			EditorUtility.SetDirty(_target);			
		}
	}
	
	void OnSceneGUI(){
		Undo.SetSnapshotTarget(_target, "distance tool undo");
		//lables and handles:
		float distance = Vector3.Distance(_target.startPoint, _target.endPoint);
		float scalePerPixel = distance * _target.pixelPerUnit;
        style.normal.textColor = _target.textColor;

        if (_target.scaleToPixels)
		{
			Handles.Label( _target.endPoint, "       Distance from Start point: " + distance + " - Scale per pixel: "+scalePerPixel+"px", style);
			
		}else{
			
			Handles.Label(_target.endPoint, "        Distance from Start point: " + distance, style);
		}
		
		//allow adjustment undo:
		
		_target.startPoint = Handles.PositionHandle(_target.startPoint, Quaternion.identity);
		_target.endPoint = Handles.PositionHandle(_target.endPoint, Quaternion.identity);
	}
}