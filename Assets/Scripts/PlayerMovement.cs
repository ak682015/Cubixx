using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;
    public GameObject HomeUI;
    public GameObject SepratedObj;
    public ParticleSystem particle;
    public TrailRenderer trail;
    private Gyroscope gyro;
    private bool gyroEnabled;

    public float speed;
    Vector3 CamPos,tempPos;
    Vector3 offset;

    private void Awake()
    {
        particle.gameObject.GetComponent<ParticleSystemRenderer>().material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void Start()
    {
        gyroEnabled = EnableGyro();                                                                          
        CamPos = camera.transform.position;
        offset = camera.transform.position - transform.position;
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
        tempPos = transform.position;

        tempPos.z += speed * Time.deltaTime;

        if (gyroEnabled)
        {
            tempPos.x = tempPos.x - gyro.attitude.x * 0.5f;
        }


        transform.position = tempPos;
        speed += 0.005f;
        CamPos.z = transform.position.z + offset.z;
        camera.transform.position = CamPos;

        
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
