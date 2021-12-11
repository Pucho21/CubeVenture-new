using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectRotator : MonoBehaviour
{
    float rotSpeed = 5;
    public Vector3 rotationSpeed;
    [Range(.5f, 2f)] public float rotationFreezeTime;

    private Vector3 targetRotation;
    private bool rotateTowards = false;

    bool chytena = false;
    bool canRotate = true;
    Coroutine actualCo;

    // ANDROID
    Vector2 startTouchPos;
              
    void Update()
    {
        if (!rotateTowards)
        {
            if (!chytena && canRotate) // ak nedrzim
                transform.Rotate(rotationSpeed * Time.deltaTime);
            else if (chytena)// ak drzim s prstom
            {
#if UNITY_EDITOR                
                //float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                // transform.RotateAround(Vector3.up, -rotX);
#endif
#if UNITY_ANDROID                
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        Quaternion rotationY = Quaternion.Euler(0f, -touch.deltaPosition.x * rotSpeed/6, 0f);
                        transform.rotation = rotationY * transform.rotation;
                    }
                }
#endif
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), 1.5f);
        }
        
    }
    void OnMouseDown()
    {
        if (!IsPointerOverUIObject())
        {
            chytena = true;
            canRotate = false;
        }
    }

    void OnMouseUp()
    {
        if (actualCo != null)
            StopCoroutine(actualCo);

        chytena = false;
        actualCo = StartCoroutine(holdRotation());
    }

    public void OnEnable()
    {
        chytena = false;
        canRotate = true;
    }
    IEnumerator holdRotation()
    {
        yield return new WaitForSeconds(rotationFreezeTime);
        canRotate = true;
    }

    public void SetRotationTowards(Vector3 targetRotation)
    {
        transform.parent.GetComponent<Animator>().Play("PlanetUp");
        this.targetRotation = targetRotation;
        rotateTowards = true;
    }
    public void CancelRotationTowards()
    {
        transform.parent.GetComponent<Animator>().Play("PlanetDown");
        targetRotation = Vector3.zero;
        StartCoroutine(ResetXZRotation());

    }
    IEnumerator ResetXZRotation()
    {
        while(transform.rotation.x !=0 && transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f,transform.rotation.y,0f), 1.5f);
            yield return new WaitForSeconds(.5f);
        }
        rotateTowards = false;
    }    

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
