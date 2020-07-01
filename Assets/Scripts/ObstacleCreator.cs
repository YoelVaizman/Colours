using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public Transform ground;
    public Vector3 obstacleScale = new Vector3(2, 1, 1);
    public Color[] colors = { Color.blue, new Color32(143, 0, 254, 1) };//purple
    private float SpacesBetweenRowOfObstacle = 20f;
    private float startInterval = 25f;
    private float endInterval = 200f;
    //not finish need to make it more dimamic !! 



    // Start is called before the first frame update
    void Start()
    {
        
        float rowY = ground.localScale.y ;
        float rowX = (ground.localScale.x - obstacleScale.x) / 2 * -1;
        float rowZ = (ground.localScale.z - obstacleScale.z) / 2 * -1 + startInterval;
        float andOfGround = ground.localScale.z / 2;
        Vector3 rowPosition = new Vector3(rowX, rowY, rowZ);
        int maximumRows = (int)((ground.localScale.z - startInterval - endInterval) /  (obstacleScale.z + SpacesBetweenRowOfObstacle)+2);// minus the finish line object
        int maximumObstacleInRow = (int)(ground.localScale.x / obstacleScale.x) - 2;
        int objectName = 0;
        for ( int j = 0; j < maximumRows; j++)
        {
            //rowPosition.z += Random.Range(10, (int)SpacesBetweenRowOfObstacle );
            createRowOfObstacles(rowPosition , objectName);
            objectName += maximumObstacleInRow;
            rowPosition.z += SpacesBetweenRowOfObstacle;
            rowPosition.x = rowX;
           
        }

    }
    
    void createRowOfObstacles(Vector3 rowPosition ,int objectName)
    {
        float chanceOfCreatingNewObstacle = 0.5f;// number between 0.0 to 1.0
        float groundEdge = ground.localScale.z / 2;
        float newRowLocation = rowPosition.z + obstacleScale.z;
        int maximumObstacleInRow = (int)(Mathf.Floor(ground.localScale.x / obstacleScale.x));
        int existingObstacles = 0;
        //Checking if the next row is not overbord
        if (newRowLocation < groundEdge)
        {
            for (int i = 0; i < maximumObstacleInRow; i++)
            {
                if (Random.value <= chanceOfCreatingNewObstacle && existingObstacles < maximumObstacleInRow - 1)
                {
                    CubeCreator(rowPosition, colors[Random.Range(0, colors.Length)], objectName.ToString());
                    existingObstacles += 1;
                    objectName++;
                }
                rowPosition.x += obstacleScale.x;
            }
        }
        else
        {
            Debug.Log("OVER the edge!!!");
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
