using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] Color32 carWithPackageColor;
    [SerializeField] Color32 normalCarColor;
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;

    bool hasPackage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            gameObject.GetComponent<SpriteRenderer>().color = normalCarColor;
        }
        else if (collision.gameObject.tag == "Boost")
        {
            moveSpeed = 20;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Destroy(collision.gameObject);
            gameObject.GetComponent<SpriteRenderer>().color = carWithPackageColor;
        }

        else if (collision.gameObject.tag == "Obstacles")
        {
            moveSpeed = 5;
        }
    }

}
