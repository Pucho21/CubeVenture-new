using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint instance;
    public  Transform playerTransform;
    public PlayerHatHandler hatHandler;
    Light portalLight;



    void Awake()
    {
        instance = this;
        portalLight = transform.GetChild(0).GetComponent<Light>();
        PlayerRespawn();
        hatHandler.SetPlayerTransform(playerTransform);
    }


    IEnumerator SpawnPlayer()
    {
        portalLight.enabled = true;
        Animator portalAnim = GetComponent<Animator>();
        portalAnim.Play("FadeInPortal");
        yield return new WaitForSeconds(1f);

        playerTransform.position = transform.position;
        playerTransform.rotation = Quaternion.Euler(new Vector3(90,0,0));
        playerTransform.gameObject.GetComponent<RollCube>().PlayerSpawned();

        FadeScreen.instance.FadeInScreen();



        portalAnim.Play("FadeOutPortal");
        yield return new WaitForSeconds(1f);
        portalLight.enabled = false;
    }

    public void PlayerRespawn()
    {        
        StartCoroutine(SpawnPlayer());
    }
    

   
}
