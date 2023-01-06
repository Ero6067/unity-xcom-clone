using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;

    private Vector3 targetPosition;
    private GridPosition gridPosition;

    [SerializeField] private float moveSpeed;
    

    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }
    private void Update() 
    {
        

        //prevents actor from jittering when it reaches end their move
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float moveSpeed = 4f;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            float rotateSpeed = 10f;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);

            unitAnimator.SetBool("isWalking", true);
        } else 
        {
            unitAnimator.SetBool("isWalking", false);
        }
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)

        {
            //Unit Changed Grid Position
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }

    }
   public void Move(Vector3 targetPosition)
   {
        this.targetPosition = targetPosition;
   }
}

