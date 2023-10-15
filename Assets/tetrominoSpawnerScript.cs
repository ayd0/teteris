using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrominoSpawnerScript : MonoBehaviour
{
    private GameObject logicObject;
    private tetrominoLogicScript logicScript;
    public GameObject tetromino;
    // Start is called before the first frame update
    void Start()
    {
        logicObject = GameObject.FindGameObjectWithTag("TetrominoLogicObject");
        logicScript = logicObject.GetComponent<tetrominoLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Vector3 spawnCoords = logicScript.lastPos;
            if (spawnCoords == new Vector3(0,0,0))
            {
                // initial case
                spawnCoords = new Vector3(.1F, .1F, .1F);
                Renderer renderer = tetromino.GetComponent<Renderer>();
                logicScript.tetrominoBounds = renderer.bounds.size;
            } else
            {
                spawnCoords += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
            }
            Instantiate(tetromino, spawnCoords, transform.rotation);
            logicScript.lastPos = spawnCoords;
        }
    }
}
