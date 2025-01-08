using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoiny : MonoBehaviour
{
    public GameObject[] wayPoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotspeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, wayPoints[currentWP].transform.position) < 10) 
            currentWP++;

        if (currentWP >= wayPoints.Length)
            currentWP = 0;

        //this.transform.LookAt(wayPoints[currentWP].transform.position);


        Quaternion LookatWP = Quaternion.LookRotation(wayPoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, LookatWP, rotspeed * Time.deltaTime);    

        this.transform.Translate(0,0, speed * Time.deltaTime);
    }
}
