using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorEnum;

public class LaserTrigger : MonoBehaviour
{
    public ColorType druhLaserTriggeru;
    Light triggerLight;

    // Start is called before the first frame update
    void Awake()
    {
        triggerLight = GetComponent<Light>();
        SetLightColor();
    }

    public void SetLightColor()
    {
        Color farba;
        if (druhLaserTriggeru == ColorType.Red)
        {
            farba = Color.red;
        }
        else if (druhLaserTriggeru == ColorType.Blue)
        {
            farba = Color.blue;
        }
        else if (druhLaserTriggeru == ColorType.Green)
        {
            farba = Color.green;
        }
        else if (druhLaserTriggeru == ColorType.Cyan)
        {
            farba = Color.cyan;
        }
        else if (druhLaserTriggeru == ColorType.Magenta)
        {
            farba = Color.magenta;
        }
        else
        {
            farba = Color.yellow;
        }
        triggerLight.color = farba;
    }
    public void OnEnable()
    {
        Debug.Log("TriggerEnabled " + druhLaserTriggeru.ToString());
        EndPoint.instance.ToggleTrigger(druhLaserTriggeru, true);
        triggerLight.intensity = 3;
    }

    public void OnDisable()
    {
        if(EndPoint.instance != null)
        {
            Debug.Log("TriggerDisabled " + druhLaserTriggeru.ToString());
            EndPoint.instance.ToggleTrigger(druhLaserTriggeru, false);
            triggerLight.intensity = 1;
        }
    }
}
