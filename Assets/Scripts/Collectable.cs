using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum collectableType
    {
        star,
        coin,
        redGem,
        greenGem,
        blueGem,
        purpleGem,
        cyanGem,
        yellowGem
    }
    public collectableType druh;

    public GameObject collectParticle;
    private void OnTriggerEnter(Collider other)
    {       

        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("collect");

            if (druh == collectableType.coin)
            {
                GameManager.instance.CoinCollected();
                collectParticle.GetComponent<ParticleSystem>().startColor = Color.yellow;
                Destroy(Instantiate(collectParticle, transform.position, Quaternion.Euler(new Vector3(-180, 0, 0))), 2f);
            }
         else if(druh == collectableType.star)
            {
                GameManager.instance.StarCollected();
                collectParticle.GetComponent<ParticleSystem>().startColor = Color.yellow;
                Destroy(Instantiate(collectParticle, transform.position, Quaternion.Euler(new Vector3(-180, 0, 0))), 2f);
            }
         else
            {
                other.gameObject.GetComponent<CubeColors>().EnableColorSide(druh);
                SpawnGemColoredParticle();
                InGameUIPanel.instance.EnableGemImg(druh);
            }           
            Destroy(gameObject);
        }
    }

    void SpawnGemColoredParticle()
    {
        if(druh == collectableType.redGem)
            collectParticle.GetComponent<ParticleSystem>().startColor = Color.red;
        else if (druh == collectableType.blueGem)
            collectParticle.GetComponent<ParticleSystem>().startColor = Color.blue;
        else if (druh == collectableType.cyanGem)
            collectParticle.GetComponent<ParticleSystem>().startColor = Color.cyan;
        else if (druh == collectableType.greenGem)
            collectParticle.GetComponent<ParticleSystem>().startColor = Color.green;
        else if (druh == collectableType.purpleGem)
            collectParticle.GetComponent<ParticleSystem>().startColor = Color.magenta;
        else 
            collectParticle.GetComponent<ParticleSystem>().startColor = Color.yellow;

            Destroy(Instantiate(collectParticle, transform.position, Quaternion.Euler(new Vector3(-180, 0, 0))), 2f);
    }
}
