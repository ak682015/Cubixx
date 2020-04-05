using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2 : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 300f;

    private Gyroscope gyro;
    private bool gyroEnabled;
    private Quaternion rot;

    private float ScreenWidth;


    private void Start()
    {
        ScreenWidth = Screen.width;


    }

    /*
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
        */

    void FixedUpdate()
    {

        forwardForce += 0.5f;
        forwardForce = Mathf.Clamp(forwardForce, 2000f, 4000f); 

        rb.AddForce(0, 0, forwardForce * Time.deltaTime);


        if( transform.position.y < -3 )
        {
            Invoke("Restart", 1f);
        }
        
        /*
        if (gyroEnabled)
        {
            rb.AddForce(-sidewaysForce * gyro.attitude.x * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
        */

        if (Input.touchCount > 0)
        {
           
            Touch touch = Input.GetTouch(0);
            if(touch.position.x > ScreenWidth / 2)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }

            if (touch.position.x < ScreenWidth / 2)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }
            
        }

        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
