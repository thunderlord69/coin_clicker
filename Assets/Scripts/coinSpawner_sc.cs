using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class coinSpawner_sc : MonoBehaviour
{

    public GameObject pointPrefab;
    public GameObject centerOfSpawns;
    public GameObject positionToInstantiate;
    public float spawnSpeed;
    public int coinNumGenerate;

    public GameObject gameManager;
    public gameManger_sc gameManger_Sc;
    float delay=0.1f;
    void Start()
    {
        gameManger_Sc = gameManager.GetComponent<gameManger_sc>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger_Sc.enablePlay && gameObject.activeSelf) {
            if (Time.time > delay)
            {
                delay = Time.time + spawnSpeed;
                var coin = Instantiate(pointPrefab, centerOfSpawns.transform.localPosition + Random.insideUnitSphere * 35, Quaternion.identity);
                coin.transform.SetParent(positionToInstantiate.transform, false);
                gameManger_Sc.addCoins(coinNumGenerate);

            }
        }
    }

}
