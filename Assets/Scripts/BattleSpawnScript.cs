using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BattleSpawnScript : MonoBehaviour
{
    float width = 4.0f;
    float lenght = 4.0f;
    float widthgap = 50.0f;
    float lenghtgap = 50.0f;
    float rotation = 45.0f;

    public float timer;
    public float spawndelay = 10.0f;
    public float spawnreducerate = 0.01f;
    public float minspawnrate = 3.0f;

    //Objects
    public GameObject jumpenemy;
    public GameObject turretenemy;
    public GameObject box;
    public GameObject boxlight;
    public GameObject barrel;
    public GameObject health;
    public GameObject pistol;
    public GameObject machinegun;
    public GameObject shotgun;
    public GameObject grenadelauncher;

    public int[,] matrixobjects = { { 1, 1, 1, 1}, { 1, 1, 2, 2 }, { 1, 1, 2, 2 }, { 2, 2, 2, 3 } };
    public int[,] matrixenemies = { { 1, 1, 1 }, { 1, 1, 4 }, { 1, 2, 3 }};



    void Start()
    {
        SpawnObjects();
        SpawnEnemies();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > spawndelay ) 
        {
            SpawnObjects();
            SpawnEnemies();
            timer = 0;
            spawndelay -= spawnreducerate;
        }

    }

    void SpawnObjects()
    {
        Debug.Log("Objects");
        Randomise2DMatrix(matrixobjects);
        ShowMatrix(matrixobjects);

        for (int w = 0; w < width; w++)
        {
            for (int l = 0; l < lenght; l++)
            {
                // Random rotation of islands in degrees 0,90,180,270
                float randrot = rotation * UnityEngine.Random.Range(0, 8);

                // set position of island spawn
                Vector3 position = new Vector3((widthgap * w) , 200, lenghtgap * l );

                // Spawn the island from the prefab.
                if (matrixobjects[w, l] == 3)
                {
                    GameObject islandClone = Instantiate(boxlight, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixobjects[w, l] == 2)
                {
                    GameObject islandClone = Instantiate(box, position, Quaternion.Euler(0, randrot, 0));
                }

                if (matrixobjects[w, l] == 1)
                {
                    // nafin
                }
            }
        }
    }
    void SpawnEnemies()
    {
        Debug.Log("Enemy Matrix");
        Randomise2DMatrix(matrixenemies);
        ShowMatrix(matrixenemies);

        for (int w = 0; w < width-1; w++)
        {
            for (int l = 0; l < lenght-1; l++)
            {
                // Random rotation of islands in degrees 0,90,180,270
                float randrot = rotation * UnityEngine.Random.Range(0, 8);

                // set position of island spawn
                Vector3 position = new Vector3(((widthgap * 0.5f)+ (widthgap * w)), 5, (lenghtgap * 0.5f) + (lenghtgap * l));

                // Spawn the island from the prefab.

                if (matrixenemies[w, l] == 3)
                {
                    int randomNumber = UnityEngine.Random.Range(1, 6);
                    if (randomNumber == 1) { GameObject islandClone = Instantiate(pistol, position, Quaternion.Euler(-90, 0, 0)); }
                    if (randomNumber == 2) { GameObject islandClone = Instantiate(shotgun, position, Quaternion.Euler(-90, 0, 0)); }
                    if (randomNumber == 3) { GameObject islandClone = Instantiate(machinegun, position, Quaternion.Euler(-90, 0, 0)); }
                    if (randomNumber == 4) { GameObject islandClone = Instantiate(grenadelauncher, position, Quaternion.Euler(-90, 0, 0)); }
                    if (randomNumber == 4) { GameObject islandClone = Instantiate(health, position, Quaternion.Euler(-90, 0, 0)); }
                    if (randomNumber == 4) { GameObject islandClone = Instantiate(barrel, position, Quaternion.Euler(-90, 0, 0)); }

                }

                if (matrixenemies[w, l] == 3)
                {
                    GameObject islandClone = Instantiate(turretenemy, position, Quaternion.Euler(-90, 0, 0));
                }

                if (matrixenemies[w, l] == 2)
                {
                    GameObject islandClone = Instantiate(jumpenemy, position, Quaternion.Euler(-90, 0, 0));
                }

                if (matrixenemies[w, l] == 1)
                {
                    // nafin
                }
            }
        }
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
}
