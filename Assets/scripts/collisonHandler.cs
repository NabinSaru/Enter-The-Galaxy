using UnityEngine;
using UnityEngine.SceneManagement;

public class collisonHandler : MonoBehaviour    
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathfx;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        print("Something hit");
        deathfx.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("ReloadScene", levelLoadDelay);
    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
