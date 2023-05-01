using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorAI : MonoBehaviour
{
    public Transform patrolRouteObject;
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public float rotationSpeed;
    public float gravity = 20f;
    public float stopTime;
    public float timer = 0f; 
    private Rigidbody rb;
    Vector3 target;

    void Start()
    {
        Transform[] waypoints = patrolRouteObject.GetComponentsInChildren<Transform>();
        List<Transform> tempPatrolPoints = new List<Transform>();
        foreach(Transform waypoint in waypoints){
            if(waypoint != patrolRouteObject){
                tempPatrolPoints.Add(waypoint);
            }
        }
        patrolPoints = tempPatrolPoints.ToArray();
        targetPoint = 0;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, patrolPoints[targetPoint].position) < 0.3f){
            timer += Time.deltaTime;
            if (timer >= stopTime) {
                increaseTargetInt();
                timer = 0f;
            } 
        }

        if (Vector3.Distance(transform.position, patrolPoints[targetPoint].position) > 0.3f)
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        Vector3 direction = patrolPoints[targetPoint].position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        rb.AddForce(Vector3.down * gravity);
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}