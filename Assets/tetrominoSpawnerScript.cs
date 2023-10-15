using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrominoSpawnerScript : MonoBehaviour
{
    private GameObject logicObject;
    private tetrominoLogicScript logicScript;
    public GameObject tetromino;
    public KeyCode buildModifierKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        logicObject = GameObject.FindGameObjectWithTag("TetrominoLogicObject");
        logicScript = logicObject.GetComponent<tetrominoLogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnCoords = logicScript.lastPos;
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (spawnCoords == new Vector3(0, 0, 0))
            {
                // initial case
                spawnCoords = new Vector3(.1F, .1F, .1F);
                Renderer renderer = tetromino.GetComponent<Renderer>();
                logicScript.tetrominoBounds = renderer.bounds.size;
            }
            else
            {
                spawnCoords += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
            }
            instantiateTetremino(spawnCoords);
        }
        if (Input.GetKey(buildModifierKey))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spawnCoords += new Vector3(-logicScript.tetrominoBounds.x, 0, 0);
                instantiateTetremino(spawnCoords);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                spawnCoords += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
                instantiateTetremino(spawnCoords);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                spawnCoords += new Vector3(0, logicScript.tetrominoBounds.y, 0);
                instantiateTetremino(spawnCoords);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                spawnCoords += new Vector3(0, -logicScript.tetrominoBounds.y, 0);
                instantiateTetremino(spawnCoords);
            }
        }
    }

    void instantiateTetremino(Vector3 spawnCoords)
    {
        Instantiate(tetromino, spawnCoords, transform.rotation);
        logicScript.lastPos = spawnCoords;
    }
}
