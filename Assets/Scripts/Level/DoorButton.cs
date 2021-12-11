using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorEnum;

public class DoorButton : MonoBehaviour
{
    public Door connectedDoor; 

    // Start is called before the first frame update
    void Start()
    {
        SetBtnColorAndTag();
    }        

    void SetBtnColorAndTag()
    {
        transform.tag = ""+ connectedDoor.doorColor;
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = connectedDoor.GetDoorColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.tag.Equals("White"))
                connectedDoor.DoorButtonPressed();
        else if(other.CompareTag(transform.tag)) // ak tag strany je rovnaky ako buttonu
        {
            connectedDoor.DoorButtonPressed();
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (transform.tag.Equals("White"))
            connectedDoor.ResetTimeLeftOpen();

        else if (other.CompareTag(transform.tag)) // ak tag strany je rovnaky ako buttonu
        {
            connectedDoor.ResetTimeLeftOpen();
        }
    }
    
}
