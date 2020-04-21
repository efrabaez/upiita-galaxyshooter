using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //Serialize Data in order to read it and modified form inspector, but not from other game objects.
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Take current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireMovement();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //Get input from keyboard arrows or a|d
        float verticalInput = Input.GetAxis("Vertical"); //Get input from keyboard arrows or w|s
        /*First way
         * transform.Translate(translation: Vector3.right * horizontalInput * _speed * Time.deltaTime);
         * transform.Translate(translation: Vector3.up * verticalInput * _speed * Time.deltaTime);
         */

        //Better way
        transform.Translate(translation: new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);


        /*
         * Player bounds
         */

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0),0);

        if (transform.position.x > 12 || transform.position.x < -12)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }
    }

    void FireMovement() {
        //Space keyu for spawn object
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(_laserPrefab,transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
        }
    }
}
