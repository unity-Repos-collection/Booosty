using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float Delay = 2f;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip SuccessSound;
    
    [SerializeField] ParticleSystem SuccessParticle;
    [SerializeField] ParticleSystem CrashParticle;
    AudioSource As;

    
    
    bool isAlive = false;
    
    void Start() 
    {
    As = GetComponent<AudioSource>();
    
    }
    void OnCollisionEnter(Collision other) 
    {
        if (isAlive){return;}   
    
        switch (other.gameObject.tag)
        {      

            case "Friendly":
                Debug.Log("Hit Friendly");
                break;
        
            case "Finish":
                //Debug.Log("Hit Finish");
                levelsuccess();
                break;
            default:
                //Debug.Log("Explode You Cunt");
                Crash ();
                break;
        }

    }

    void Crash()
    {   
        //add particle effect
        isAlive = true;
        As.Stop();
        As.PlayOneShot(DeathSound);
        CrashParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", Delay);
        
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

    void levelsuccess()
    {   
        isAlive = true;
        As.Stop();
        As.PlayOneShot(SuccessSound);
        SuccessParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", Delay);
    }


}
