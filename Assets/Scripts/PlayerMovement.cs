using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 200f;

    private Gyroscope gyro;
    private bool gyroEnabled;
    private Quaternion rot;
        

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
