using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{


    public GameObject camera;

    private ParticleSystem particle;
    private MeshRenderer mesh;

    private Gyroscope gyro;
    private bool gyroEnabled;

    public float speed;
    Vector3 CamPos,tempPos;
    Vector3 offset;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
        
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
        CamPos.z = transform.position.z + offset.z;
        camera.transform.position = CamPos;

        tempPos = transform.position;

        tempPos.z += speed * Time.deltaTime;

        if (gyroEnabled)
        {
            tempPos.x = tempPos.x - gyro.attitude.x * 0.5f;
            print(gyro.attitude.x);
        }


        transform.position = tempPos;
        speed += 0.0005f;

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
