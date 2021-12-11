using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public GameObject soundGO;

    private void Awake()
    {
        StartCoroutine(WaitRandomBeforeAnimating());
    }
    public void SpawnSoundGO()
    {
        Destroy(Instantiate(soundGO, transform.position, Quaternion.identity), 1f);
    }

     IEnumerator WaitRandomBeforeAnimating()
    {
        float random = Random.Range(0, 30)/10;
        yield return new WaitForSeconds(random);
        GetComponent<Animator>().enabled = true;
    }
}
