using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BC_NPC_Traffic_WaypointManagerWindow : EditorWindow
{
    [MenuItem("Tool/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<BC_NPC_Traffic_WaypointManagerWindow>();
    }

    public Transform waypointRoot;

    //목적지 그리는거
    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

        if(waypointRoot == null)
        {
            EditorGUILayout.HelpBox("Root transform must be selected. please assing a root transform", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawButtons();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }

    void DrawButtons()
    {
        if(GUILayout.Button("Waypoint 생성"))
        {
            CreateWaypoint();
        }
        if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<BC_NPC_Traffic_Waypoint>())
        {
            if(GUILayout.Button("Waypoint 교차점 생성"))
            {
                CreateBranch();
            }
            if(GUILayout.Button("이전 Waypoint 생성"))
            {
                CreateWaypointBefore();
            }
            if (GUILayout.Button("다음 Waypoint 생성"))
            {
                CreateWaypointAfter();
            }
            if (GUILayout.Button("Waypoint 제거"))
            {
                RemoveWaypoint();
            }
        }
    }

    void CreateWaypoint()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(BC_NPC_Traffic_Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        BC_NPC_Traffic_Waypoint waypoint = waypointObject.GetComponent<BC_NPC_Traffic_Waypoint>();
        if(waypointRoot.childCount > 1)
        {
            waypoint.previousWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<BC_NPC_Traffic_Waypoint>();
            waypoint.previousWaypoint.nextWaypoint = waypoint;
            //waypoint 동일한 방향으로 지정해야함 
            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }

        Selection.activeGameObject = waypoint.gameObject;
    }

    void CreateWaypointBefore()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(BC_NPC_Traffic_Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        BC_NPC_Traffic_Waypoint newWaypoint = waypointObject.GetComponent<BC_NPC_Traffic_Waypoint>();

        BC_NPC_Traffic_Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<BC_NPC_Traffic_Waypoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        if (selectedWaypoint.previousWaypoint != null)
        {
            newWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
            selectedWaypoint.previousWaypoint.nextWaypoint = newWaypoint;
        }
        newWaypoint.nextWaypoint = selectedWaypoint;

        selectedWaypoint.previousWaypoint = newWaypoint;

        newWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

        Selection.activeGameObject = newWaypoint.gameObject; 
    }

    void CreateWaypointAfter()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(BC_NPC_Traffic_Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        BC_NPC_Traffic_Waypoint newWaypoint = waypointObject.GetComponent<BC_NPC_Traffic_Waypoint>();

        BC_NPC_Traffic_Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<BC_NPC_Traffic_Waypoint>();

        waypointObject.transform.position = selectedWaypoint.transform.position;
        waypointObject.transform.forward = selectedWaypoint.transform.forward;

        newWaypoint.previousWaypoint = selectedWaypoint;

        if (selectedWaypoint.nextWaypoint != null)
        {
            selectedWaypoint.nextWaypoint.previousWaypoint = newWaypoint.previousWaypoint = selectedWaypoint;

            newWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;

            Selection.activeGameObject = newWaypoint.gameObject;

        }
    }
    void RemoveWaypoint()
    {
        BC_NPC_Traffic_Waypoint selectedWaypoint = Selection.activeGameObject.GetComponent<BC_NPC_Traffic_Waypoint>();

        if(selectedWaypoint.nextWaypoint != null)
        {
            selectedWaypoint.nextWaypoint.previousWaypoint = selectedWaypoint.previousWaypoint;
        }
        if (selectedWaypoint.previousWaypoint != null)
        {
            selectedWaypoint.previousWaypoint.nextWaypoint = selectedWaypoint.previousWaypoint;
            Selection.activeGameObject = selectedWaypoint.previousWaypoint.gameObject;
        }

        DestroyImmediate(selectedWaypoint.gameObject);

    }
    void CreateBranch()
    {
        GameObject waypointObject = new GameObject("Waypoint" + waypointRoot.childCount, typeof(BC_NPC_Traffic_Waypoint));
        waypointObject.transform.SetParent(waypointRoot, false);

        BC_NPC_Traffic_Waypoint waypoint = waypointObject.GetComponent<BC_NPC_Traffic_Waypoint>();

        BC_NPC_Traffic_Waypoint branchedFrom = Selection.activeGameObject.GetComponent<BC_NPC_Traffic_Waypoint>();
        branchedFrom.branches.Add(waypoint);

        waypoint.transform.position = branchedFrom.transform.position;
        waypoint.transform.forward = branchedFrom.transform.forward;

        Selection.activeGameObject = waypoint.gameObject;
    }
}
