using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

private UnityEngine.AI.NavMeshAgent[] navAgents;
public Transform targetMarker;
private void Start ()
{
	navAgents = FindObjectsOfType(typeof(UnityEngine.AI.NavMeshAgent)) as UnityEngine.AI.NavMeshAgent[];
}

private void UpdateTargets ( Vector3 targetPosition )
{
	foreach(UnityEngine.AI.NavMeshAgent agent in navAgents)
	{
		agent.destination = targetPosition;
	}
}

private void Update ()
{
	if(GetInput())
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		
		if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
		{
			Vector3 targetPosition = hitInfo.point;
			UpdateTargets(targetPosition);
			targetMarker.position = targetPosition;
		}
	}
}

private bool GetInput()
{
	if (Input.GetMouseButtonDown(0))
	{
		return true;
	}
	
		return false;
}

private void OnDrawGizmos()
{
	Debug.DrawLine(targetMarker.position, targetMarker.position +
	Vector3.up * 5, Color.red);
}

}