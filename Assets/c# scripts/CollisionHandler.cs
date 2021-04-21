using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    
    
    
    void OnCollisionEnter(Collision other) 
    {
    
    
    switch (other.gameObject.tag)
    {
        case "Friendly":
            Debug.Log("Hit Friendly");
            break;
        
        case "Finish":
            //Debug.Log("Hit Finish");
            NextLevel();
            break;
        default:
            //Debug.Log("Explode You Cunt");
            Invoke("ReloadLevel", 1f);
            break;
    }
    }
    void NextLevel()
    {   
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = CurrentSceneIndex + 1;
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;    
        } 
        SceneManager.LoadScene(NextSceneIndex);
    

    }
    void ReloadLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }




}
