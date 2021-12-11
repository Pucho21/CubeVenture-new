using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorEnum;

public class Door : MonoBehaviour
{
    public ColorType doorColor;

    [Space]
    public bool isDoorTimed;
    [Header("Čas ktorý zostanú dvere otvorené")]
    public float openTime;
    float timeLeft;

    private Coroutine closingCoroutine;



    // Start is called before the first frame update
    void Start()
    {
        SetDoorColor();
    }


    // Update is called once per frame
    void Update()
    {
        if (isDoorTimed)
        {
            if (timeLeft > 0)
                timeLeft -= Time.deltaTime;
            else
                if (closingCoroutine == null)
            {
                closingCoroutine = StartCoroutine(TryClosingDoor());
            }

        }
    }

    void SetDoorColor()
    {
        Color farba = GetDoorColor();
        if (doorColor == ColorType.Red)
        {
            farba = Color.red;
        }
        else if (doorColor == ColorType.Blue)
        {
            farba = Color.blue;
        }
        else if (doorColor == ColorType.Green)
        {
            farba = Color.green;
        }
        else if (doorColor == ColorType.Cyan)
        {
            farba = Color.cyan;
        }
        else if (doorColor == ColorType.Magenta)
        {
            farba = Color.magenta;
        }
        else if (doorColor == ColorType.Yellow)
        {
            farba = Color.yellow;
        }
        else
            farba = new Color32(138, 138, 138, 255);

        transform.tag = doorColor.ToString();
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = farba; // zmena farby dveri
    }
    public Color GetDoorColor()
    {
        Color farba;
        if (doorColor == ColorType.Red)
        {
            farba = Color.red;
        }
        else if (doorColor == ColorType.Blue)
        {
            farba = Color.blue;
        }
        else if (doorColor == ColorType.Green)
        {
            farba = Color.green;
        }
        else if (doorColor == ColorType.Cyan)
        {
            farba = Color.cyan;
        }
        else if (doorColor == ColorType.Magenta)
        {
            farba = Color.magenta;
        }
        else if (doorColor == ColorType.Yellow)
        {
            farba = Color.yellow;
        }
        else
            farba = new Color32(138, 138, 138, 255);

        return farba;
    }

    public void DoorButtonPressed()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        if (isDoorTimed)
        {
            ResetTimeLeftOpen();
            enabled = true;
        }
        AudioManager.instance.PlaySound("click");
        GetComponent<BoxCollider>().enabled = false;
        transform.GetChild(0).GetComponent<Animator>().Play("OpenDoor");
    }

    void CloseDoor()
    {
        GetComponent<BoxCollider>().enabled = true;
        closingCoroutine = null;
        enabled = false;
        transform.GetChild(0).GetComponent<Animator>().Play("CloseDoor");
    }

    IEnumerator TryClosingDoor()
    {
        while (Physics.Raycast(transform.position, Vector3.up, 1f))
        {
            yield return new WaitForSeconds(.5f);
        }
                CloseDoor();
    }

    public void ResetTimeLeftOpen()
    {
        timeLeft = openTime;
    }
}
