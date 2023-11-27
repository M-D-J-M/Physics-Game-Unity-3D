using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IslandSpawn : MonoBehaviour
{
    float height = 4.0f;
    float width = 5.0f;
    float lenght = 5.0f;
    float heightgap = 30.0f;
    float widthgap = 50.0f;
    float lenghtgap = 50.0f;
    float rotation = 45.0f;
    float offset;
    Vector3 objectoffset;

    public GameObject player;
    private float playermaxheight;
    private float level;
    private float levelspawned;

    // Islands
    public GameObject island;
    public GameObject bigisland;
    public GameObject smallisland;
    public GameObject fastisland;
    public GameObject jumpisland;
    public GameObject slowisland;
    public GameObject spinpadisland;
    public GameObject spinlogisland;
    

    //Objects
    public GameObject jumpenemy;
    public GameObject turretenemy;
    public GameObject barrel;
    public GameObject health;
    public GameObject cannon;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject machinegun;
    public GameObject grenadelauncher;
    bool objectchanged = false;
    bool islandchanged = false;

    public float changerate = 2f;
    public float changeratetimer;

    public int[,] matrixislands = { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 5, 6, 6, 1, 1 }, { 2, 3, 4, 5, 6 } };
    public int[,] matrixobjects = { { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 3, 4, 1 }, { 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1 } };


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playermaxheight = 0.0f;
        level = 0.0f;
        levelspawned = 0.0f;
        changeratetimer = 0.0f;
}

    void Update()
    {
        // records maxheight
        if (player.transform.position.y > playermaxheight) { playermaxheight = player.transform.position.y; }

        // Increase level depending on player height
        if (level < ((playermaxheight / heightgap)-1)) { level ++; }

        // spawn new islands
        if (levelspawned < (level + height)) { SpawnIslands(); ChangeObject(); ChangeIsland(); }
    }

    void SpawnIslands() 
    {
        Debug.Log("Island Matrix" + level);
        Randomise2DMatrix(matrixislands);
        ShowMatrix(matrixislands);

        //Debug.Log("Objects MAtrix" + level);
        Randomise2DMatrix(matrixobjects);
        //ShowMatrix(matrixobjects);

        for (int w = 0; w < width; w++)
        {
            for (int l = 0; l < lenght; l++)
            {
                //offset position between levels
                if (levelspawned % 2 == 1) offset = widthgap / 2;
                else offset = 0.0f;

                // Random rotation of islands in degrees 0,90,180,270
                float randrot = rotation * UnityEngine.Random.Range(0, 8);
                //Debug.Log(randrot);

                // set position of island spawn
                Vector3 position = new Vector3((widthgap * w) + (offset), (heightgap * levelspawned) , lenghtgap * l + (offset));

                // Spawn the island from the prefab.
                if (matrixislands[w, l] == 8)
                {
                    GameObject islandClone = Instantiate(smallisland, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 7)
                {
                    GameObject islandClone = Instantiate(island, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 6)
                {
                    GameObject islandClone = Instantiate(fastisland, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 5)
                {
                    GameObject islandClone = Instantiate(jumpisland, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 4)
                {
                    GameObject islandClone = Instantiate(spinlogisland, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 3)
                {
                    GameObject islandClone = Instantiate(spinpadisland, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 2)
                {
                    GameObject islandClone = Instantiate(slowisland, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixislands[w, l] == 1)
                {
                    GameObject islandClone = Instantiate(bigisland, position, Quaternion.Euler(0, randrot, 0));
                }

                // Spawn the objects from the prefab.

                objectoffset = new Vector3(0f, 5f, 0f);

                // other spawn
                if (matrixobjects[w, l] == 4)
                {
                    int randomother = UnityEngine.Random.Range(1, 3);
                    if (randomother == 1) { GameObject islandClone = Instantiate(cannon, position + objectoffset*2, Quaternion.Euler(0, randrot, 0)); }
                    if (randomother == 2) { GameObject islandClone = Instantiate(barrel, position + objectoffset, Quaternion.Euler(0, randrot, 0)); }
                }
                // good spawn
                if (matrixobjects[w, l] == 3)
                {
                    int randomgood = UnityEngine.Random.Range(1, 6);
                    if (randomgood == 1) { GameObject islandClone = Instantiate(health, position + objectoffset, Quaternion.Euler(0, 0, 0)); }
                    if (randomgood == 2) { GameObject islandClone = Instantiate(pistol, position + objectoffset*4, Quaternion.Euler(-90, 0, 0)); }
                    if (randomgood == 3) { GameObject islandClone = Instantiate(shotgun, position + objectoffset*4, Quaternion.Euler(-90, 0, 0)); }
                    if (randomgood == 4) { GameObject islandClone = Instantiate(machinegun, position + objectoffset * 4, Quaternion.Euler(-90, 0, 0)); }
                    if (randomgood == 5) { GameObject islandClone = Instantiate(grenadelauncher, position + objectoffset*4, Quaternion.Euler(-90, 0, 0)); }
                }
                // bad spawn
                if (matrixobjects[w, l] == 2)
                {
                    int randombad = UnityEngine.Random.Range(1, 3);
                    if (randombad == 1) { GameObject islandClone = Instantiate(jumpenemy, position + objectoffset, Quaternion.Euler(0, randrot, 0)); }
                    if (randombad == 2) { GameObject islandClone = Instantiate(turretenemy, position + objectoffset, Quaternion.Euler(0, randrot, 0)); }
                }

                if (matrixobjects[w, l] == 1)
                {
                    // do nothing
                }
            }
        }
        levelspawned++;
        changeratetimer++;
        objectchanged = false;
        islandchanged = false;
    }


    void ShowMatrix(int[,] matrixa) 
    {

        for (int j = 0; j < matrixa.GetLength(1); j++)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrixa.GetLength(0); i++)
            {
                sb.Append(matrixa[i, j]);
                sb.Append(" ");
            }
            Debug.Log(sb.ToString());
        }
        Debug.Log("-----------");
    }

    void Randomise2DMatrix(int[,] matrixa) 
    {
        // Get the dimensions.
        int num_rows = matrixa.GetUpperBound(0) + 1;
        int num_cols = matrixa.GetUpperBound(1) + 1;
        int num_cells = num_rows * num_cols;

        // Randomize the array.
        System.Random rand = new System.Random();
        for (int i = 0; i < num_cells - 1; i++)
        {
            // Pick a random cell between i and the end of the array.
            int j = rand.Next(i, num_cells);

            // Convert to row/column indexes.
            int row_i = i / num_cols;
            int col_i = i % num_cols;
            int row_j = j / num_cols;
            int col_j = j % num_cols;

            // Swap cells i and j.
            int temp = matrixa[row_i, col_i];
            matrixa[row_i, col_i] = matrixa[row_j, col_j];
            matrixa[row_j, col_j] = temp;
        }

    }

    void ChangeObject() 
    { 
        
        if (!objectchanged && changeratetimer >= changerate) 
        {
            for (int j = 0; j < matrixobjects.GetLength(1); j++)
            {
                for (int i = 0; i < matrixobjects.GetLength(0); i++)
                {
                    if (!objectchanged)
                    {
                        if (matrixobjects[i, j] == 1) 
                        {
                            //int randomNumber = UnityEngine.Random.Range(2,5);
                            //Debug.Log(randomNumber);
                            matrixobjects[i, j] = 2;
                            objectchanged = true;
                            changeratetimer = 0.0f;
                        }
                    }

                }
            }
        }
    }

    void ChangeIsland()
    {

        if (!islandchanged)
        {
            for (int j = 0; j < matrixislands.GetLength(1); j++)
            {
                for (int i = 0; i < matrixislands.GetLength(0); i++)
                {
                    if (!islandchanged)
                    {
                        if (matrixislands[i, j] == 1)
                        {
                            matrixislands[i, j] = 7;
                            islandchanged = true;
                        }

                        if (matrixislands[i, j] == 7)
                        {
                            matrixislands[i, j] = 8;
                            islandchanged = true;
                        }
                    }

                }
            }
        }
    }
}
