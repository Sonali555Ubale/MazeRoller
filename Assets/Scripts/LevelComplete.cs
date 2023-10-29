using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_AudioSource.Play();
            Invoke("CompleteLevel", 1f);
        }
    }


    private void CompleteLevel()
    {
        
        SceneManager.LoadScene(3);
    }

}
