using UnityEngine;
using System.Collections;

public class RollCube : MonoBehaviour
{
    public int speed = 300;
    bool isMoving = false;

    [Space]
    public LayerMask collisionLayer;
    public float raycastRange;

    private Animator hatAnimator;

    void Update()
    {
        if (isMoving)
        {
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (CanRollInDirection(Vector3.right))
                StartCoroutine(Roll(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (CanRollInDirection(Vector3.left))
                StartCoroutine(Roll(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (CanRollInDirection(Vector3.forward))
                StartCoroutine(Roll(Vector3.forward));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if(CanRollInDirection(Vector3.back))
                StartCoroutine(Roll(Vector3.back));
        }

    }
    /*
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.forward * raycastRange, Color.yellow); 
        Debug.DrawRay(transform.position, Vector3.back * raycastRange, Color.red);
        Debug.DrawRay(transform.position, Vector3.left * raycastRange, Color.blue);
        Debug.DrawRay(transform.position, Vector3.right * raycastRange, Color.green);
    }
    */


    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;

        AnimateHat();

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction + Vector3.down;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        RoundCubePosition();
        isMoving = false;
        
    }

    void RoundCubePosition()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
    }

    bool CanRollInDirection(Vector3 direction)
    {       
        if (Physics.Raycast(transform.position, direction, raycastRange, collisionLayer))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void SetHatAnimator(Animator hatAnimator)
    {
        this.hatAnimator = hatAnimator;
    }

    void AnimateHat()
    {
        Debug.Log("Pustam animaciu hatky");
        hatAnimator.Play("HatJump");
    }

    

}
