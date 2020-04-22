using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] //Serialize Data in order to read it and modified form inspector, but not from other game objects.
    private float _speed = 5.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _nextFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        //Take current position = new position (0,0,0)
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");

        }

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();
        }
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

    void FireLaser() 
    {
        //Space key for spawn object
        _nextFire = Time.time + _fireRate;
        Instantiate(_laserPrefab,transform.position + new Vector3(0,1.05f,0), Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

    }


}
