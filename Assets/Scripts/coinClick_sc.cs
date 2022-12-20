using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinClick_sc : MonoBehaviour
{
    public GameObject pointPrefab;
    public GameObject positionToInstantiate;
    public GameObject centerOfSpawns;
    public Camera cam;
    private Vector3 spawnPosition;

    public GameObject rotateAround;
    public GameObject gameManager;
    public  gameManger_sc gameManger_Sc;
    private AudioSource source;

    public Quaternion rotationB;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        rotationB = gameObject.transform.rotation;
    }
    void Start()
    {
        
        gameManger_Sc = gameManager.GetComponent<gameManger_sc>();

    }

    // Update is called once per frame
    void Update()
    {

        //Rotate coin in store
       if (gameManger_Sc.storePanel.active)
        {
            rotateAround.transform.Rotate(Vector3.up * (100 * Time.deltaTime));
            transform.SetParent(rotateAround.transform, true);
        }
        else
        {
            transform.parent = null;
            transform.rotation = rotationB;
        }
        
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Debug.Log("ROB");
            Ray ray = cam.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "coin" && gameManger_Sc.enablePlay==true)
                { 
                    var coin = Instantiate(pointPrefab, centerOfSpawns.transform.localPosition + Random.insideUnitSphere * 80, Quaternion.identity);
                    coin.transform.SetParent(positionToInstantiate.transform, false);
                    gameManger_Sc.addCoins(1);
                    source.Play();

                }
            }

        }

    }
}
