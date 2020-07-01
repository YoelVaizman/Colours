﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public Transform ground;
    public Vector3 obstacleScale = new Vector3(2, 1, 1);
    public Color[] colors = { Color.blue, new Color32(143, 0, 254, 1) };//purple
    //not finish need to make it more dimamic !! 

                        
    
    // Start is called before the first frame update
    void Start()
    {
        int SpacesBetweenRowsZ = 20;
        float rowY = ground.localScale.y ;
        float rowX = (ground.localScale.x - obstacleScale.x) / 2 * -1;
        float rowZ = (ground.localScale.z - obstacleScale.z) / 2 * -1;
        float andOfGround = ground.localScale.z / 2;
        Vector3 finishLineScale = new Vector3(ground.localScale.x, 10, 2);
        Debug.Log("X= " + ground.localScale.x.ToString() + "Y = " + ground.localScale.y.ToString() + "Z=" +ground.localScale.z.ToString());
        Vector3 finishLinePosition = new Vector3(0, ground.localScale.y + (finishLineScale.y/2), ground.localScale.z/2 - finishLineScale.z);
        Debug.Log(finishLinePosition);
        createFinishLine(finishLinePosition, finishLineScale);
        Vector3 rowPosition = new Vector3(rowX, rowY, rowZ);
        int maximumRows = (int)((ground.localScale.z /  obstacleScale.z) / SpacesBetweenRowsZ);
        int maximumObstacleInRow = (int)(ground.localScale.x / obstacleScale.x) - 2;
        maximumObstacleInRow = maximumObstacleInRow - 1; // minus the finish line object
        int x = 0;
        for ( int j = 0; j < maximumRows; j++)
        {
            rowPosition.z += Random.Range(10, SpacesBetweenRowsZ+j);
            createRowOfObstacles(rowPosition , x);
            x += maximumObstacleInRow;
            rowPosition.x = rowX;
           
        }

    }
    
    void createFinishLine(Vector3 finishLinePosition, Vector3 finishLineScale)
    {
        GameObject obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obstacle.tag = "Finish";
        obstacle.name = "finishLine";
        Renderer rend = obstacle.GetComponent<Renderer>();
        rend.transform.localScale = finishLineScale;
        rend.transform.position = finishLinePosition;
        Rigidbody rb = obstacle.AddComponent<Rigidbody>();
        rb.mass =999;
        BoxCollider boxCollider = obstacle.AddComponent<BoxCollider>();
        boxCollider.material.staticFriction = 99;
        boxCollider.material.dynamicFriction = 99;
    }

    void createRowOfObstacles(Vector3 rowPosition ,int num)
    {
        float chanceOfCreatingNewObstacle = 0.5f;// number between 0.0 to 1.0
        float groundEdge = ground.localScale.z / 2;
        float newRowLocation = rowPosition.z + obstacleScale.z;
        int maximumObstacleInRow = (int)(Mathf.Floor(ground.localScale.x / obstacleScale.x));
        int existingObstacles = 0;
        int x = num;
        //Checking if the next row is not overbord
        if (newRowLocation < groundEdge)
        {
            for (int i = 0; i < maximumObstacleInRow; i++)
            {
                if (Random.value <= chanceOfCreatingNewObstacle && existingObstacles < maximumObstacleInRow - 1)
                {
                    CubeCreator(rowPosition, colors[Random.Range(0, colors.Length)], x.ToString());
                    existingObstacles += 1;
                    x++;
                }
                rowPosition.x += obstacleScale.x;
            }
        }
     
    }

    void CubeCreator(Vector3 cubePosition, Color cubeColor, string name)
    {
        GameObject obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obstacle.tag = "Obstacle";
        obstacle.name = name;
        Renderer rend = obstacle.GetComponent<Renderer>();
        //rend.material = new Material(Shader.Find("Specular"));
        rend.material.color = cubeColor;
        rend.transform.localScale = obstacleScale;
        rend.transform.position = cubePosition;//put objet in to the game
        Rigidbody rb = obstacle.AddComponent<Rigidbody>();
        rb.mass = 4;
        BoxCollider boxCollider = obstacle.AddComponent<BoxCollider>();
        boxCollider.material.staticFriction = 0;
        boxCollider.material.dynamicFriction = 0;
       
        //Instantiate(obstacle, cubePosition, Quaternion.identity);//put objet in to the game

    }
// Update is called once per frame
void Update()
    {
        
    }
}
