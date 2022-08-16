using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private Vector3 targetPosition;
    [SerializeField]private Animator unitAnimator;
    private void Update() 
    {
        

        //prevents actor from jittering when it reaches end their move
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            //float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            unitAnimator.SetBool("isWalking", true);
        } else 
        {
            unitAnimator.SetBool("isWalking", false);
        }
        

        if (Input.GetMouseButtonDown(0)) 
        {
            Move(MouseWorld.GetPosition());
        }
    }
   private void Move(Vector3 targetPosition)
   {
        this.targetPosition = targetPosition;
   }
}

