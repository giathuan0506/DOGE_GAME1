using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{

    public GameObject boom;
    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    private GameObject Sheep;
    // Use this for initialization
    void Start()
    {
        UpdateBoomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastBoomTime + boomTime)
        {
            ThroughBoom();
        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    void ThroughBoom()
    {
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;

        bom.GetComponent<BoomController>().target = Sheep.transform.position;

        UpdateBoomTime();
    }
}