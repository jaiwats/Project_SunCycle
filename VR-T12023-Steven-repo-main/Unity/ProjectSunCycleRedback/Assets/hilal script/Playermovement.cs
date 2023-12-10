using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardforce = 4000f;
    public float sideways= 1000f;
   
   void FixedUpdate () {
    rb.AddForce(0,0, -forwardforce * Time.deltaTime);

   if(Input.GetKey("d")){

    rb.AddForce(-sideways * Time.deltaTime,0,0, ForceMode.VelocityChange);
   }

    if(Input.GetKey("a")){

    rb.AddForce(sideways * Time.deltaTime,0,0,ForceMode.VelocityChange);
   }

   }
   
}
