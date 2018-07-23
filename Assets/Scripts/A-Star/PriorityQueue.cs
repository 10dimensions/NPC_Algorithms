using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue 
{

private ArrayList nodes = new ArrayList();
public int Length
{
	get { return nodes.Count; }
}
public bool Contains(object node)
{
	return nodes.Contains(node);
}
public NodeAStar GetFirstNode()
{
	if (nodes.Count > 0)
		{
			return (NodeAStar)nodes[0];
		}
	return null;
}
public void Push(NodeAStar node)
{
	nodes.Add(node);
	nodes.Sort();
}
public void Remove(NodeAStar node)
{
	nodes.Remove(node);
	nodes.Sort();
}

}