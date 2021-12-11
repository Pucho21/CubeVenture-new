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
    
    private void FixedUpdate()
    {
        Vector3 raycastPos = new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z);
        Debug.DrawRay(raycastPos, Vector3.forward * raycastRange, Color.yellow); 
        Debug.DrawRay(raycastPos, Vector3.back * raycastRange, Color.red);
        Debug.DrawRay(raycastPos, Vector3.left * raycastRange, Color.blue);
        Debug.DrawRay(raycastPos, Vector3.right * raycastRange, Color.green);
    }
    


    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;

        AnimateHat();

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction + Vector3.down;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        AudioManager.instance.PlaySound("movePlayer");

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
        RaycastHit hit;
        if (Physics.SphereCast(transform.position,.5f,direction, out hit, raycastRange, collisionLayer))
        {
            if (hit.transform.gameObject.layer == 10) // ak hitnem movable
            {
                return (hit.transform.gameObject.GetComponent<MovableObject>().SlideInDirection(direction));
            }
            else  // inak ak hitnem prekazku
            {
                return false;

            }
        }
        else
        {
            return true;
        }
    }

    public void SetHatAnimator(Animator hatAnimator)
    {
        this.hatAnimator = hatAnimator;
        Debug.Log("NENASTAVUJEM HAT ANIMATOR");
    }

    void AnimateHat()
    {
        if (hatAnimator != null)
            hatAnimator.Play("HatJump");
    } 
    
    public void StopPlayerMovement()
    {
        enabled = false;
    }

    public void PlayerKilled()
    {
        gameObject.GetComponent<Animator>().Play("CubeDissapear");
        StopPlayerMovement();
        isMoving = false;
    }

    public void PlayerSpawned()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Animator>().Play("CubeAppear");
        isMoving = false;
        enabled = true;
    }

}
