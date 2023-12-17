using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // public float speed = 5f; // Hareket hızı
    // public float sensitivity = 2f; // Fare hassasiyeti
    public Transform playerTransform;
    public Transform maleTransform;
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    public float sensitivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  if (Input.GetKey(KeyCode.W))
        // {
        //     transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // }

        // // A tuşuna basılırsa sola hareket
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.Translate(Vector3.left * speed * Time.deltaTime);
        // }

        // // S tuşuna basılırsa geri hareket
        // if (Input.GetKey(KeyCode.S))
        // {
        //     transform.Translate(Vector3.back * speed * Time.deltaTime);
        // }

        // // D tuşuna basılırsa sağa hareket
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.Translate(Vector3.right * speed * Time.deltaTime);
        // }

        // // Fare pozisyonlarındaki değişimi al
        // float mouseX = Input.GetAxis("Mouse X");

        // // Kamerayı sağa veya sola döndür
        // transform.Rotate(Vector3.up * mouseX * sensitivity);
        // Klavye girişini al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Karakteri hareket ettir
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        maleTransform.Translate(movement);

        // Mouse X eksenindeki fare hareketini al
        float mouseX = Input.GetAxis("Mouse X");

        // Kamerayı sağa veya sola döndür
        playerTransform.Rotate(Vector3.up * mouseX * sensitivity);
    }
}
