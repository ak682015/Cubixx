using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;
    public GameObject HomeUI;
    public ParticleSystem particle;
    public TrailRenderer trail;
    private Gyroscope gyro;
    private bool gyroEnabled;

    public float speed;
    Vector3 CamPos,tempPos;
    Vector3 offset;

    private void Awake()
    {
        particle.gameObject.GetComponent<ParticleSystemRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
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

    }

    private void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(End());
        }

    }
    
    IEnumerator End()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        trail.enabled = false;
        particle.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }


}
