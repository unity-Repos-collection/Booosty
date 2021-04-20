using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
    switch (other.gameObject.tag)
    {
        case "Friendly":
            Debug.Log("Hit Friendly");
            break;
        
        case "Finish":
            Debug.Log("Hit Finish");
            break;
        
        default:
            Debug.Log("Explode You Cunt");
            break;
    }

        
    }

}
