using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private SceneLoader sceneLoader;
    private int blocksAmount;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddBlock()
    {
        blocksAmount++;
    }

    public void BlockDestroyed()
    {
        blocksAmount--;
        if (blocksAmount < 1)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
