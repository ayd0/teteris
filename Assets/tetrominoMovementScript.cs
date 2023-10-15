using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tetrominoMovementScript : MonoBehaviour
{
    private GameObject logicObject;
    private tetrominoLogicScript logicScript;
    private GameObject tSpawnerObject;
    private tetrominoSpawnerScript spawnerScript;
    public GameObject gameBounds;

    // Start is called before the first frame update
    void Start()
    {
        logicObject = GameObject.FindGameObjectWithTag("TetrominoLogicObject");
        logicScript = logicObject.GetComponent<tetrominoLogicScript>();
        tSpawnerObject = GameObject.FindGameObjectWithTag("TetrominoSpawnerObject");
        spawnerScript = tSpawnerObject.GetComponent<tetrominoSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(spawnerScript.buildModifierKey))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.transform.position += new Vector3(0, -logicScript.tetrominoBounds.y, 0);
                logicScript.lastPos = gameObject.transform.position;
                Debug.Log(gameObject.transform.position);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameObject.transform.position += new Vector3(-logicScript.tetrominoBounds.x, 0, 0);
                logicScript.lastPos = gameObject.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
                logicScript.lastPos = gameObject.transform.position;
            }
        }
    }
}
