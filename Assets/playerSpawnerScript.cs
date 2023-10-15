using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Video;

public class playerSpawnerScripts : MonoBehaviour
{
    public GameObject tgPlayer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Instantiate(tgPlayer, new UnityEngine.Vector3(UnityEngine.Random.Range(transform.position.x - 7, transform.position.x + 7), 2, 0), transform.rotation);
        }
    }
}
