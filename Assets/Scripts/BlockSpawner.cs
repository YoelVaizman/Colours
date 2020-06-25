using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject blockObstacle;

    // Start is called before the first frame update
    void Start()
    {
        
        
       /* Color[] colors = { Color.red, Color.gray, Color.green };
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for ( int i = 0; i < spawnPoints.Length; i++)
        {
            if(randomIndex != i)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Renderer rend = cube.GetComponent<Renderer>();
                rend.material = new Material(Shader.Find("Specular"));
                rend.material.color = colors[i];
                Instantiate(cube, spawnPoints[i].position, Quaternion.identity );


                //blockObstacle.transform.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", colors[i]);//!!!!!
                //Instantiate(blockObstacle, spawnPoints[i].position, Quaternion.identity );
            }
        }*/
    }
    void ObstacleCreator()
    {
        GameObject obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer rend = obstacle.GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
        //rend.transform.position = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
