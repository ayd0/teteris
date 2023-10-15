using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoundsSpawnerScript : MonoBehaviour
{
    public GameObject gameBounds;
    public GameObject tetromino;
    // Start is called before the first frame update
    void Start()
    {
        GameObject spawnedBounds = Instantiate(gameBounds, new Vector3(0, 0, 1), transform.rotation);

        // calculate width
        float newWidth = tetromino.GetComponent<Renderer>().bounds.size.x * 10;
        Vector3 newScale = spawnedBounds.transform.localScale;
        newScale.x = newWidth;

        //calculate height
        Camera mainCamera = Camera.main;
        float screenHeightWorldSpace = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        newScale.y = screenHeightWorldSpace * 2;
        

        spawnedBounds.transform.localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
