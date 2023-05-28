using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOV : MonoBehaviour
{
    public float radius;
    public float angle;
    public GameObject playerRef;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeePlayer;
    public float FOVheight = 1.0f; 
    public static bool caught;
    public float timer = 0f;
    public AIUIManager AIUIManager;

    void Start(){
        caught = false;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        
        AIUIManager = GetComponentInChildren<AIUIManager>();
        targetMask = LayerMask.GetMask("Target");
        obstructionMask = LayerMask.GetMask("Obstruction");
    }

    private IEnumerator FOVRoutine(){
        //float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while(true){
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck(){
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        if(rangeChecks.Length!=0){
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, directionToTarget) < angle / 2){
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
                AIUIManager.UpdateUIOnDetection();
                if(timer >= 2.3f){
                    AIUIManager.UpdateUIOnDetection();
                    caught = true;
                    SceneManager.LoadScene(2);
                }
            } else {
                AIUIManager.UpdateUIOnDetection();
            }
        } else {
            AIUIManager.UpdateUIOnDetection();
            timer = 0f;
        }
    }
}
