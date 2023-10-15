using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBoundsSpawnerScript : MonoBehaviour
{
    public GameObject gameBounds;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gameBounds, new Vector3(0, 0, 1), transform.rotation);

        float screenHeight = Screen.height;
        float objectHeight = gameBounds.GetComponent<Renderer>().bounds.size.y;
        float scaleFactor = screenHeight / objectHeight;

        Vector3 originalScale = gameBounds.transform.localScale;
        gameBounds.transform.localScale = new Vector3(originalScale.x * 3F, originalScale.y * scaleFactor, originalScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
