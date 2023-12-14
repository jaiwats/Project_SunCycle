
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Gamemanager2 gameManager;
    void onTriggerEnter ()
    {
        gameManager.completelevel();
        
    }
}
