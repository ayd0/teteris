using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class tetrominoMovementScript : MonoBehaviour
{
    private GameObject logicObject;
    private tetrominoLogicScript logicScript;
    private GameObject tSpawnerObject;
    private tetrominoSpawnerScript spawnerScript;
    public GameObject gameBounds;
    public GameObject gameBoundsSpawner;
    public gameBoundsSpawnerScript gbSpawnerScript;

    // Start is called before the first frame update
    void Start()
    {
        logicObject = GameObject.FindGameObjectWithTag("TetrominoLogicObject");
        logicScript = logicObject.GetComponent<tetrominoLogicScript>();
        tSpawnerObject = GameObject.FindGameObjectWithTag("TetrominoSpawnerObject");
        spawnerScript = tSpawnerObject.GetComponent<tetrominoSpawnerScript>();
        gameBoundsSpawner = GameObject.FindGameObjectWithTag("GameBoundsSpawnerObject");
        gbSpawnerScript = gameBoundsSpawner.GetComponent<gameBoundsSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(spawnerScript.buildModifierKey))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Renderer tRenderer = gameObject.GetComponent<Renderer>();
                Vector3 playArea = gbSpawnerScript.getPlayArea();
                float lowestY = spawnerScript.tetrominoList.Min(el => el.transform.position.y) - tRenderer.bounds.size.y / 2;

                if (!detectBoundsCollision(playArea.z, lowestY, tRenderer.GetComponent<Renderer>().bounds.size.y))
                {
                    gameObject.transform.position += new Vector3(0, -logicScript.tetrominoBounds.y, 0);
                    logicScript.lastPos = gameObject.transform.position;
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Renderer tRenderer = gameObject.GetComponent<Renderer>();
                Vector3 playArea = gbSpawnerScript.getPlayArea();
                float lowestX = spawnerScript.tetrominoList.Min(el => el.transform.position.x) - tRenderer.bounds.size.x / 2;

                if (!detectBoundsCollision(playArea.x, lowestX, tRenderer.GetComponent<Renderer>().bounds.size.x))
                {
                    gameObject.transform.position += new Vector3(-logicScript.tetrominoBounds.x, 0, 0);
                    logicScript.lastPos = gameObject.transform.position;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Renderer tRenderer = gameObject.GetComponent<Renderer>();
                Vector3 playArea = gbSpawnerScript.getPlayArea();
                float highestX = spawnerScript.tetrominoList.Max(el => el.transform.position.x) - tRenderer.bounds.size.x / 2;

                if (!detectBoundsCollision(playArea.x, -highestX, tRenderer.GetComponent<Renderer>().bounds.size.x))
                {
                    gameObject.transform.position += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
                    logicScript.lastPos = gameObject.transform.position;
                }
            }
        }
    }

    private bool detectBoundsCollision(float bounds, float pos, float tetro)
    {
        return (Mathf.Abs(bounds - pos) < tetro);
    }
}
