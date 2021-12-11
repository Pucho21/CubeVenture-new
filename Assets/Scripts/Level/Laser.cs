using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ColorEnum;

public class Laser : MonoBehaviour
{

    private int _maxBounce = 8;

    private int _count;
    private LineRenderer _laser;
    public ColorType laserType;

    [SerializeField]
    private Vector3 _offSet;

    private LaserTrigger hitLaserTrigger;

    private void Start()
    {
        _laser = GetComponent<LineRenderer>();
        SetLaserType();

    }
    private void Update()
    {
        _count = 0;
        CastLaser(transform.position + _offSet, transform.forward);
    }
    private void CastLaser(Vector3 position, Vector3 direction)
    {
        _laser.SetPosition(0, transform.position + _offSet);

        for (int i = 0; i < _maxBounce; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (_count < _maxBounce - 1)
            {
                _count++;
            }
            if (Physics.Raycast(ray, out hit,300))
            {

                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                _laser.SetPosition(_count, hit.point);

                if (hit.transform.tag != "Mirror")
                {
                    if (hit.transform.tag == "LaserEnd") // ak trafim laserEnd
                    {
                        LaserTrigger hitLaserTrigger = hit.transform.gameObject.GetComponent<LaserTrigger>();
                        if (hitLaserTrigger.druhLaserTriggeru == laserType) // ak trafim spravny laserEnd
                        {
                            this.hitLaserTrigger = hitLaserTrigger;
                            this.hitLaserTrigger.enabled = true;
                        }                        
                    }
                    else if (hitLaserTrigger != null)
                    {
                        hitLaserTrigger.enabled = false;
                        hitLaserTrigger = null;
                    }
                    for (int j = (i + 1); j < _maxBounce; j++)
                        {
                            _laser.SetPosition(j, hit.point);

                        }
                    break;
                    
                }
                else
                {

                    _laser.SetPosition(_count, hit.point);
                }
            }
            else
            {

                _laser.SetPosition(_count, ray.GetPoint(300));

            }


        }

    }

    public void SetLaserType()
    {
        Color farba;
        if (laserType == ColorType.Red)
        {
            farba = Color.red;
        }
        else if (laserType == ColorType.Blue)
        {
            farba = Color.blue;
        }
        else if (laserType == ColorType.Green)
        {
            farba = Color.green;
        }
        else if (laserType == ColorType.Cyan)
        {
            farba = Color.cyan;
        }
        else if (laserType == ColorType.Magenta)
        {
            farba = Color.magenta;
        }
        else
        {
            farba = Color.yellow;
        }
        GetComponent<Light>().color = farba;
        transform.tag = laserType.ToString();
        _laser.startColor = farba; // zmena farby laseru
        _laser.endColor = farba; // zmena farby laseru
    }

}
