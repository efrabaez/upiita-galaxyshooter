using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //Serialize Data in order to read it and modified form inspector, but not from other game objects.
    private float _speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Take current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //Get input from keyboard arrows or a|d
        float verticalInput = Input.GetAxis("Vertical"); //Get input from keyboard arrows or w|s
        //First way
        //transform.Translate(translation: Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(translation: Vector3.up * verticalInput * _speed * Time.deltaTime);

        //Better way
        transform.Translate(translation: new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
    }
}
