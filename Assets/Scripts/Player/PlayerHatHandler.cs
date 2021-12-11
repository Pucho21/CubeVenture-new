using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHatHandler : MonoBehaviour
{
    private Transform playerTransform;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, 2.25f, playerTransform.position.z);
    }

    void SpawnSelectedHat()
    {
        if (UserInfoHolder.instance != null) 
        {
            string hatID = UserInfoHolder.instance.hatID;        
            GameObject hatGO = Resources.Load<GameObject>("Hats/" + hatID);
            GameObject spawnedHat = Instantiate(hatGO, transform.position, transform.rotation, transform);
            playerTransform.gameObject.GetComponent<RollCube>().SetHatAnimator(spawnedHat.GetComponent<Animator>());
        }
    }

    public void SetPlayerTransform(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        SpawnSelectedHat();
        enabled = true;
    }
    
}
