using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;
    public GameObject camera;

    private ParticleSystem particle;
    private MeshRenderer mesh;

    private Gyroscope gyro;
    private bool gyroEnabled;

    Vector3 CamPos;
    Vector3 offset;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        gyroEnabled = EnableGyro();
        CamPos = camera.transform.position;
        offset = camera.transform.position- transform.position;
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
        CamPos= transform.position + offset;
        camera.transform.position = CamPos;
        forwardForce += 0.1f;
        forwardForce = Mathf.Clamp(forwardForce, 2000f, 4000f);


        if (transform.position.y < -3)
        {
            Restart();
        }

       //rb.AddForce(0, 0, forwardForce * Time.deltaTime);
       
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
  

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Break());
        }

    }

    private IEnumerator Break()
    {
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
