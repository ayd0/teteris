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

        logicScript.tetrominoBounds = tetromino.GetComponent<Renderer>().bounds.size;
        instantiateTetromino(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buildModifierKey))
        {
            Vector3 spawnCoords = logicScript.lastPos;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spawnCoords += new Vector3(-logicScript.tetrominoBounds.x, 0, 0);
                instantiateTetromino(spawnCoords);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                spawnCoords += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
                instantiateTetromino(spawnCoords);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                spawnCoords += new Vector3(0, logicScript.tetrominoBounds.y, 0);
                instantiateTetromino(spawnCoords);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                spawnCoords += new Vector3(0, -logicScript.tetrominoBounds.y, 0);
                instantiateTetromino(spawnCoords);
            }
        }
    }

    void instantiateTetromino(Vector3 spawnCoords)
    {
        Instantiate(tetromino, spawnCoords, transform.rotation);
        logicScript.lastPos = spawnCoords;
    }
}
