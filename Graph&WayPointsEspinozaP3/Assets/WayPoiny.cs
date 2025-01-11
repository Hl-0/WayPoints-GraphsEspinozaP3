using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class WayPoiny : MonoBehaviour
{
    public GameObject[] wayPoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotspeed = 10.0f;
    public float LookAhead = 10.0f;

    GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;

        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }
    void ProgressTracker()
    {

        if (Vector3.Distance(tracker.transform.position, this.transform.position) > LookAhead) return;

        if (Vector3.Distance(tracker.transform.position, wayPoints[currentWP].transform.position) < 3)
            currentWP++;

        if (currentWP >= wayPoints.Length)
            currentWP = 0;

        tracker.transform.LookAt(wayPoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed + 20)* Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

 
        Quaternion LookatWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, LookatWP, rotspeed * Time.deltaTime);    

        this.transform.Translate(0,0, speed * Time.deltaTime);
    }
}
