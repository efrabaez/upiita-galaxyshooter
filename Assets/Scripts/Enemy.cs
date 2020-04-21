using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] //Serialize Data in order to read it and modified form inspector, but not from other game objects.
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveDown();
    }

    void MoveDown()
    {
        transform.Translate(translation: Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7, 0);
        }
    }

    //Trigger this function when Object start to collide with other object
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null) 
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }    
    }
}
