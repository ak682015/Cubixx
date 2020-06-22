using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement1 : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce;
    public float sidewaysForce;
    public GameObject camera;

    private ParticleSystem particle;
    private MeshRenderer mesh;
    public float speed;
    private Gyroscope gyro;
    private bool gyroEnabled;

    Vector3 CamPos,tempPos;
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
        tempPos = transform.position;
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
        tempPos = transform.position;

        tempPos.z += speed * Time.deltaTime;
        if(gyroEnabled)
        {
            tempPos.x = tempPos.x - gyro.attitude.x;
            print(gyro.attitude.x);
        }


        transform.position = tempPos;


   

        if (transform.position.y < -3)
        {
            Restart();
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
