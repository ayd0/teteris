using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class tetrominoSpawnerScript : MonoBehaviour
{
    private GameObject logicObject;
    private tetrominoLogicScript logicScript;
    public GameObject gameBoundsSpawner;
    public gameBoundsSpawnerScript gbSpawnerScript;
    public GameObject tetromino;
    public KeyCode buildModifierKey = KeyCode.LeftShift;
    public List<GameObject> tetrominoList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Renderer tetrominoRenderer = tetromino.GetComponent<Renderer>();
        logicObject = GameObject.FindGameObjectWithTag("TetrominoLogicObject");
        logicScript = logicObject.GetComponent<tetrominoLogicScript>();

        gameBoundsSpawner = GameObject.FindGameObjectWithTag("GameBoundsSpawnerObject");
        gbSpawnerScript = gameBoundsSpawner.GetComponent<gameBoundsSpawnerScript>();

        // calculate posX
        logicScript.tetrominoBounds = tetrominoRenderer.bounds.size;
        float posX = tetrominoRenderer.bounds.size.x / 2;

        // calculate posY
        Camera mainCamera = Camera.main;
        float tetroSizeY = tetrominoRenderer.bounds.size.y;
        float posY = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        posY -= tetroSizeY / 2 + tetroSizeY;

        instantiateTetromino(new Vector3(posX, posY, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(buildModifierKey))
        {
            Vector3 spawnCoords = logicScript.lastPos;
            Vector4 playArea = gbSpawnerScript.getPlayArea();
            Renderer tetrominoRenderer = tetromino.GetComponent<Renderer>();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!(spawnCoords.x - tetrominoRenderer.bounds.size.x < playArea.x))
                {
                    spawnCoords += new Vector3(-logicScript.tetrominoBounds.x, 0, 0);
                    instantiateTetromino(spawnCoords);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if ((spawnCoords.x + tetrominoRenderer.bounds.size.x < playArea.z))
                {
                    spawnCoords += new Vector3(logicScript.tetrominoBounds.x, 0, 0);
                    instantiateTetromino(spawnCoords);
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if ((spawnCoords.y + tetrominoRenderer.bounds.size.y < playArea.y))
                {
                    spawnCoords += new Vector3(0, logicScript.tetrominoBounds.y, 0);
                    instantiateTetromino(spawnCoords);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!(spawnCoords.y - tetrominoRenderer.bounds.size.y < playArea.w))
                {
                    spawnCoords += new Vector3(0, -logicScript.tetrominoBounds.y, 0);
                    instantiateTetromino(spawnCoords);
                }
            }
        }
    }

    void instantiateTetromino(Vector3 spawnCoords)
    {
        tetrominoList.Add(Instantiate(tetromino, spawnCoords, transform.rotation));
        logicScript.lastPos = spawnCoords;
    }
}
