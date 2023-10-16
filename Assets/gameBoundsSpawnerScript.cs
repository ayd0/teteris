using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoundsSpawnerScript : MonoBehaviour
{
    public GameObject gameBounds;
    private GameObject spawnedBounds;
    public GameObject tetromino;
    // Start is called before the first frame update
    void Start()
    {
        Renderer tetrominoRenderer = tetromino.GetComponent<Renderer>();
        spawnedBounds = Instantiate(gameBounds, new Vector3(0, 0, 1), transform.rotation);

        // calculate width
        float newWidth = tetrominoRenderer.bounds.size.x * 10;
        Vector3 newScale = spawnedBounds.transform.localScale;
        newScale.x = newWidth;

        //calculate height
        Camera mainCamera = Camera.main;
        float screenHeightWorldSpace = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        screenHeightWorldSpace -= tetrominoRenderer.bounds.size.y;
        newScale.y = screenHeightWorldSpace * 2;

        spawnedBounds.transform.localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector4 getPlayArea()
    {
        Renderer renderer = spawnedBounds.GetComponent<Renderer>();
        float posLeft = -(renderer.bounds.size.x / 2);
        float posDown = -(renderer.bounds.size.y / 2);
        return new Vector3(posLeft, -posLeft, posDown);
    }
}
