using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;
    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotSpeed = 2.0f;

    public GameObject WPManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graphs g;
    // Start is called before the first frame update
    void Start()
    {
        wps = WPManager.GetComponent<WPManger>().waypoints;
        g = WPManager.GetComponent<WPManger>().graphs;
        currentNode = wps[0];

        Invoke("GoToRuin", 2);

    }

    public void GoToHeli()
    {
        g.AStar(currentNode, wps[3]);
        currentWP = 0;
    }
    public void GoToRuin()
    {
        g.AStar(currentNode, wps[31]);
        currentWP = 0;
    }
    public void GoTofACTORY()
    {
        g.AStar(currentNode, wps[18]);
        currentWP = 0;
    }
    // Update is called once per frame
    public void LateUpdate()
    {
        if(g.pathList.Count ==0 || currentWP == g.pathList.Count)
            return;

        if (Vector3.Distance(g.pathList[currentWP].getId().transform.position,this.transform.position)<accuracy )
        {
            currentNode = g.pathList[currentWP].getId();
            currentWP++;
        }
        if(currentWP == g.pathList.Count)
        {
            goal = g.pathList[currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,this.transform.position.y,goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
