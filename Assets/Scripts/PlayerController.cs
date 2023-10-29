using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AudioClip RollingSound;
    [SerializeField]
    private AudioClip shock;
    [SerializeField]
    private float Volume;
   

    public float speed = 500f;
    private float damage;
    private Rigidbody rigidbody;
    private PlayerInputActions action;
    Vector3 movement;
    private int DamageCount;

    void Main()
    {
      
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
              
    }

    void Update()
    {

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
          
            if (Input.GetKey("escape"))
                Application.Quit();
        }
        else
        {
          
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

    }

    void FixedUpdate()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
           
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
         
            rigidbody.AddForce(movement * speed * Time.deltaTime);
           

        }
        else
        {
           
             movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
           
            rigidbody.AddForce(movement * speed * Time.deltaTime);
           
            PlaySoundTrack(RollingSound, Volume);
        }
        //if (movement != Vector3.zero) PlaySoundTrack(RollingSound, Volume);

    }

    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            OnHitDamage();
        }
       
    }

    private void OnHitDamage()
    {
        Debug.Log(damage);
        DamageCount += 1;
  
        PlaySoundTrack(shock, Volume);
        Timer.Instance.ReduceTimer(3);

    }




    private void PlaySoundTrack(AudioClip clip, float vol)
    {
        //AudioSource.PlayOneShot(clip, vol);
        AudioSource.PlayClipAtPoint(clip, this.transform.position, vol);
        Debug.Log(clip.name);
    }

   public void SetSensitivity(Single val)
    {
             speed *= val;
        
    }
}