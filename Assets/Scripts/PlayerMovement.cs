using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce =1300f;
    public float acceleration = 0.5f;
    public float sidewaysForce = 100f;
    public float sidewaysSpeed = 10f;

    // Update is called once per frame
    //Fixed Update because we are using it to mess with physics
    void FixedUpdate()
    {
        float x = sidewaysSpeed * Time.fixedDeltaTime ;
        //Add forward force
        
        
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);//ForceMode.VelocityChange
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector3.right * x); //Vector3.right == (1,0,0)
            //rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.MovePosition(rb.position + Vector3.left * x);
            //rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0, ForceMode.VelocityChange);
        }
      
    }
}
