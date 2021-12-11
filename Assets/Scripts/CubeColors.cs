using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorEnum;

public class CubeColors : MonoBehaviour
{

    [SerializeField] private GameObject redCubeSide;
    [SerializeField] private GameObject greenCubeSide;
    [SerializeField] private GameObject blueCubeSide;
    [SerializeField] private GameObject cyanCubeSide;
    [SerializeField] private GameObject magentaCubeSide;
    [SerializeField] private GameObject yellowCubeSide;





    public void EnableColorSide(Collectable.collectableType gemType)
    {
        if(gemType == Collectable.collectableType.redGem)
        {
            redCubeSide.tag = ColorType.Red.ToString();
            redCubeSide.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if (gemType == Collectable.collectableType.greenGem)
        {
            greenCubeSide.tag = ColorType.Green.ToString();
            greenCubeSide.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if (gemType == Collectable.collectableType.blueGem)
        {
            blueCubeSide.tag = ColorType.Blue.ToString();
            blueCubeSide.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (gemType == Collectable.collectableType.cyanGem)
        {
            cyanCubeSide.tag = ColorType.Cyan.ToString();
            cyanCubeSide.GetComponent<MeshRenderer>().material.color = Color.cyan;
        }
        else if (gemType == Collectable.collectableType.purpleGem)
        {
            magentaCubeSide.tag = ColorType.Magenta.ToString();
            magentaCubeSide.GetComponent<MeshRenderer>().material.color = Color.magenta;
        }
        else if (gemType == Collectable.collectableType.yellowGem)
        {
            yellowCubeSide.tag = ColorType.Yellow.ToString();
            yellowCubeSide.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
