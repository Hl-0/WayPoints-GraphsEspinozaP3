using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction { UNI, BI}
    public GameObject node1;
    public GameObject node2;
    public direction dir;
}

public class WPManger : MonoBehaviour
{

    public GameObject[] waypoints;
    public Link[] links;
    public Graphs graphs = new Graphs();
    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                graphs.AddNode(wp);
            }
            foreach (Link l in links)
            {
                graphs.AddEdge(l.node1, l.node2);
                if (l.dir == Link.direction.BI)
                {
                    graphs.AddEdge(l.node2, l.node1);
                }
            }
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
