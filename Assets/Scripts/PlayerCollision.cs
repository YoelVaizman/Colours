using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class PlayerCollision : MonoBehaviour
{

    public Rigidbody rb;
    public Color[] colors = { Color.blue, new Color32(143, 0, 254, 1) };
    public Text text;
    public PlayerMovement playerMovement;
    public float impactForce = 250f;
    private int score = 0;
    private int bonus = 0;
    private List<string> alreadyCollided = new List<string>();
    private float pieceSize = 0.5f;
    private float originalForwardForce ;
    public float bonusSpeed = 50f;




    void Start()
    {
        originalForwardForce = playerMovement.forwardForce;
        this.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
        text.text = score.ToString();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Finish")
        {
            Debug.Log("END GAME!");
            FindObjectOfType<GameManeger>().EndGame();

        }
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Renderer rend = collisionInfo.gameObject.GetComponent<Renderer>();
            if (transform.GetComponent<Renderer>().material.color == rend.material.color)
            {
               
                if (newCollition(collisionInfo.collider.name))
                {
                    
                    alreadyCollided.Add(collisionInfo.collider.name);
                    expliode(collisionInfo.gameObject, pieceSize);
                    bonus++;
                    score = score + 10 * bonus;
                    text.text = score.ToString();
                    this.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
                    rb.AddForce(0, 0, impactForce);
                    playerMovement.forwardForce = originalForwardForce + (bonus * bonusSpeed);
                    Debug.Log(playerMovement.forwardForce);
                }
            }
            else 
            { 
                if (newCollition(collisionInfo.collider.name))
                {
                    bonus = 0;
                    playerMovement.forwardForce = originalForwardForce;
                }
            }
            
        }


    }
    
    bool newCollition(string name)
    {
        if(alreadyCollided != null)
        {
            for (int i = 0; i < alreadyCollided.Count; i++)
            {
                if (alreadyCollided[i] == name)
                {
                    return false;
                }
            }
        }

        return true;

    }

    void OnCollisionStay(Collision collisionInfo)
    {
        
    }

    void OnCollisionExit(Collision collisionInfo)
    {
       
    }

    void expliode(GameObject collisionInfo, float pieceSize)
    {
        
        Vector3 position = collisionInfo.transform.position;
        Vector3 scale = collisionInfo.transform.localScale;
        Color color = collisionInfo.gameObject.GetComponent<Renderer>().material.color;
        Destroy(collisionInfo);

        int maxPieceInX = (int)(scale.x / pieceSize);
        //Debug.Log(maxPieceInX);
        int maxPieceInY = (int)(scale.y / pieceSize);
        //Debug.Log(maxPieceInY);
        int maxPieceInZ = (int)(scale.z / pieceSize) ;
        //Debug.Log(maxPieceInZ);

        for (int x = 0 ; x < maxPieceInX; x++)
         {
             for (int y = 0; y < maxPieceInY; y++ )
             {
                 for (int z = 0 ; z < maxPieceInZ; z++)
                 {
                    createPiece(position, color, new Vector3(x * pieceSize, y * pieceSize, z * pieceSize), pieceSize);
                 }
             }
         }


    }

    void createPiece(Vector3 position, Color pieceColor  , Vector3 picecPosition,  float pieceSize)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.transform.position = position + picecPosition - new Vector3(0.5f, 0.5f, 0.5f);//TODO- fix 0.5
        piece.transform.localScale = new Vector3(pieceSize, pieceSize, pieceSize);

        Renderer rend = piece.GetComponent<Renderer>();
        rend.material.color = pieceColor;


        Rigidbody rigidbody = piece.AddComponent<Rigidbody>();
        rigidbody.mass = 0;
        //Destroy(gameObject, 5);
        //rigidbody.useGravity = false;

    }
    
}
