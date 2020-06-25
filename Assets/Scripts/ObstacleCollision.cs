using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // Start is called before the first frame update
     public Rigidbody obstacleRB;
     public float upForce = 30000f;
     public float sidewaysForce = 10000f;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //obstacleRB.useGravity = false;
            obstacleRB.AddForce(0, upForce * Time.deltaTime, sidewaysForce * Time.deltaTime);
            other.rigidbody.useGravity = false;
            
        }
    }
}
