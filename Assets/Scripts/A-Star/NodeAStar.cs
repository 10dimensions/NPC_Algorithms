using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeAStar : IComparable 
{

//Total cost so far for the node
public float gCost;
//Estimated cost from this node to the goal node
public float hCost;
//Is this an obstacle node
public bool bObstacle;
//Parent of the node in the linked list
public NodeAStar parent;
//Position of the node in world space
public Vector3 position;

public NodeAStar()
{
	hCost = 0.0f;
	gCost = 1.0f;
	bObstacle = false;
	parent = null;
}

public NodeAStar(Vector3 pos)
{
	hCost = 0.0f;
	gCost = 1.0f;
	bObstacle = false;
	parent = null;
	position = pos;
}

public void MarkAsObstacle()
{
	bObstacle = true;
}

//IComparable Interface method implementation
public int CompareTo(object obj)
{
	NodeAStar node = (NodeAStar)obj;
	if (hCost < node.hCost)
	{
		return -1;
	}

	if (hCost > node.hCost)
	{
		return 1;
	}

	return 0;
	}
}