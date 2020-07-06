using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] //Serialize Data in order to read it and modified form inspector, but not from other game objects.
    private float _speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
    }

   void MoveUp() {
        transform.Translate(translation: Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 7.5f) {
            if (transform.parent != null) {
                //Destroy parent tripleshot 'cause is empty object
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
