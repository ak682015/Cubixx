using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 200f;

    private ParticleSystem particle;
    private MeshRenderer mesh;
    private AudioSource collideAudio;

    private Gyroscope gyro;
    private bool gyroEnabled;
    private Quaternion rot;


    private void Awake()
    {
        collideAudio = GetComponent<AudioSource>();
        particle = GetComponentInChildren<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
  
    }

    private void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

 

    void FixedUpdate()
    {
      
        forwardForce += 0.1f;
        forwardForce = Mathf.Clamp(forwardForce, 2000f, 4000f);

     
        if (transform.position.y < -3)
        {
            Invoke("Restart", 1f);
        }
       

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
       
        if(gyroEnabled)
        {
            rb.AddForce(- sidewaysForce * gyro.attitude.x * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        
        if ( Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
        }
        */

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Break());
        }

    }

    private IEnumerator Break()
    {
        collideAudio.PlayDelayed(0.1f);
        particle.Play();
        mesh.enabled = false;


        //gyro.enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax + 2f);

        //Destroy(this.gameObject);
        

        Restart();
        //Invoke("Restart", 1f);


    }


    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
