using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    //FOV values
    public float radius;
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
    public float FOVheight = 1.0f; 

    // Spotlight
    public GameObject spotlight;
    public float spotlightIntensity = 200f;
    public Vector3 spotlightPositionOffset = new Vector3(0f, 1f, 0f);
    public Vector3 spotlightRotationOffset = new Vector3(10f, 0f, 0f);
    float timer = 0f;

    void Start()
    {
        //FOV
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        // Spotlight
        spotlight = new GameObject("Spotlight");
        spotlight.transform.parent = transform;
        spotlight.transform.localPosition = Vector3.zero;
        spotlight.AddComponent<Light>();
        spotlight.GetComponent<Light>().type = LightType.Spot;
        spotlight.GetComponent<Light>().range = radius;
        spotlight.GetComponent<Light>().spotAngle = angle;
        spotlight.GetComponent<Light>().intensity = spotlightIntensity;
        //public spotlightPositionOffset = new Vector3(0f, 1f, 0f); // move the spotlight 1 unit higher
        //public spotlightRotationOffset = new Vector3(10f, 0f, 0f); // angle the spotlight downwards
        spotlight.transform.position += spotlightPositionOffset; // apply the new position offset
        spotlight.transform.rotation *= Quaternion.Euler(spotlightRotationOffset); // apply the new rotation offset
    }

    private IEnumerator FOVRoutine(){
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while(true){
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck(){
        spotlight.GetComponent<Light>().color = Color.green;
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if(rangeChecks.Length!=0){
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
                    
            }
            else canSeePlayer = false;
        } else {
            canSeePlayer = false;
        }
    }

    void Update() {
        if (canSeePlayer) {
            timer += Time.deltaTime;
            if (timer >= 2f) {
                spotlight.GetComponent<Light>().color = Color.red;
            } else {
                spotlight.GetComponent<Light>().color = Color.yellow;
            }
        } else {
            timer = 0f;
        }
    }
}
