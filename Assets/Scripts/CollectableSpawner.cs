using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [Space]
    [Header("Coins")]
    [SerializeField] GameObject starGO;

    [Space]
    [Header("Coins")]
    [SerializeField] GameObject coinGO;
    [Space]
    [SerializeField] GameObject redGemGO;
    [SerializeField] GameObject greenGemGO;
    [SerializeField] GameObject blueGemGO;
    [SerializeField] GameObject cyanGemGO;
    [SerializeField] GameObject magentaGemGO;
    [SerializeField] GameObject yellowGemGO;
    

    

    // Start is called before the first frame update
    void Awake()
    {
        int stars = SpawnStars();
        int coins = SpawnCoins();
        InGameUIPanel.instance.SetMaxCollectablesValues(stars,coins);
        SpawnGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGems()
    {
        int randomIndex = Random.Range(0, transform.GetChild(2).transform.childCount);
        Vector3 spawnPoint = transform.GetChild(2).transform.GetChild(randomIndex).position;
        Instantiate(redGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(3).transform.childCount);
         spawnPoint = transform.GetChild(3).transform.GetChild(randomIndex).position;
        Instantiate(greenGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(4).transform.childCount);
         spawnPoint = transform.GetChild(4).transform.GetChild(randomIndex).position;
        Instantiate(blueGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(5).transform.childCount);
         spawnPoint = transform.GetChild(5).transform.GetChild(randomIndex).position;
        Instantiate(cyanGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(6).transform.childCount);
         spawnPoint = transform.GetChild(6).transform.GetChild(randomIndex).position;
        Instantiate(magentaGemGO, spawnPoint, Quaternion.identity);

         randomIndex = Random.Range(0, transform.GetChild(7).transform.childCount);
         spawnPoint = transform.GetChild(7).transform.GetChild(randomIndex).position;
        Instantiate(yellowGemGO, spawnPoint, Quaternion.identity);
    }

<<<<<<< HEAD:Cubeventure/Assets/Scripts/Level/CollectableSpawner.cs
    int SpawnCoins()
    {    
        GameObject coinGO =  Resources.Load<GameObject>("Collectables/Coin2");
=======
    void SpawnCoins()
    {        
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel):Cubeventure/Assets/Scripts/CollectableSpawner.cs
        List<int> indexArray = new List<int>();
        int coinsChildCount = transform.GetChild(1).transform.childCount;

            int randIndex;
        for(int i=0;i< coinsChildCount; i++)
        {
            randIndex = Random.RandomRange(0, coinsChildCount);

            while (indexArray.Contains(randIndex))
            {
                randIndex = Random.RandomRange(0, coinsChildCount);
            }

            indexArray.Add(randIndex);
        }
        for(int i=0;i<indexArray.Count;i++)
        {
            Vector3 spawnPoint = transform.GetChild(1).transform.GetChild(indexArray[i]).position;
            Instantiate(coinGO, spawnPoint, Quaternion.identity);
        }
        return coinsChildCount;
    }

    int SpawnStars()
    {
        List<int> indexArray = new List<int>();
        int starsChildCount = transform.GetChild(0).transform.childCount;

        int randIndex;
        for (int i = 0; i < starsChildCount; i++)
        {
            randIndex = Random.RandomRange(0, starsChildCount);

            while (indexArray.Contains(randIndex))
            {
                randIndex = Random.RandomRange(0, starsChildCount);
            }

            indexArray.Add(randIndex);
        }
        for (int i = 0; i < indexArray.Count; i++)
        {
            Vector3 spawnPoint = transform.GetChild(0).transform.GetChild(indexArray[i]).position;
            Instantiate(starGO, spawnPoint, Quaternion.identity);
        }
        return starsChildCount;
    }
}
