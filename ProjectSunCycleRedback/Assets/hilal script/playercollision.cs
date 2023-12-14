using UnityEngine;

public class playercollision : MonoBehaviour
{
    public Playermovement movement;
    public GameManager gameManager;

   
    // Start is called before the first frame update
    void OnCollisionEnter (Collision collisionInfo) {

        if(collisionInfo.collider.name == "END"){
        movement.enabled = false;
        gameManager.CompleteLevel();
    }
    
}
}
