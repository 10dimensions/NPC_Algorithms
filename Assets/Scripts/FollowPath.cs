using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FollowPath : MonoBehaviour {

[SerializeField]
private wayPointPath path;

[SerializeField]
private float speed = 20.0f;

[SerializeField]
private float mass = 5.0f;

[SerializeField]
private bool isLooping = true;
private float currentSpeed;
private int currentPathIndex = 0;
private Vector3 targetPoint;
private Vector3 direction;
private Vector3 targetDirection;


private void Start ()
{
// Initialize the direction as the agent's current facing direction
direction = transform.forward;
// We get the firt point along the path
targetPoint = path.GetPoint(currentPathIndex);
}


private void Update ()
{
if(path == null) 
{
return;
}

currentSpeed = speed * Time.deltaTime;

if(TargetReached())
{
if (!SetNextTarget()) 
{
return;
}
}
direction += Steer(targetPoint);
transform.position += direction; //Move the agent according to thedirection
transform.rotation = Quaternion.LookRotation(direction); //Rotate the agent towards the desired direction
}

private bool TargetReached()
{
return (Vector3.Distance(transform.position, targetPoint) <
path.radius);
}

private bool SetNextTarget()
{
bool success = false;
if (currentPathIndex < path.PathLength - 1) {
currentPathIndex++;
success = true;
}
else
{
if(isLooping)
{
currentPathIndex = 0;
success = true;
}
else
{success = false;
}
}
targetPoint = path.GetPoint(currentPathIndex);
return success;
}

public Vector3 Steer(Vector3 target)
{
// Subtracting vector b - a gives you the direction from a to b.
targetDirection = (target - transform.position);
targetDirection.Normalize();
targetDirection*= currentSpeed;
Vector3 steeringForce = targetDirection - direction;
Vector3 acceleration = steeringForce / mass;
return acceleration;
}


}