using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    Vector3 target;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();

        }
        if (Vector3.Distance(transform.position, patrolPoints[targetPoint].position) > 0.1f)
        {
            // Set isWalking parameter to true
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            // Set isWalking parameter to false
            GetComponent<Animator>().SetBool("isWalking", false);
        }
            Vector3 direction = patrolPoints[targetPoint].position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }


    void increaseTargetInt()
    {
        targetPoint++;
        if(targetPoint >= patrolPoints.Length){
            targetPoint = 0;
        }
    }
}
