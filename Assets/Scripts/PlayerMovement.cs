using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float pulseFrequency = 1f;
    public float velocity = 1f;

    public Transform spawnPosition;
    
    private float nextPulse = 0;
    private bool pulseAvailable = false;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        InitComponent();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPulse();
      /*  
       if (Input.GetKeyDown(KeyCode.R)) {
            RestartPosition();
        }

    }

    public void RestartPosition()
    {
        transform.position = spawnPosition.position;
        rb.velocity = Vector2.zero;
      */
    }

    private void FixedUpdate()
    {
        FlyPulse();
    }
    private void InitComponent()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void CheckPulse()
    {
        if(Time.time > nextPulse)
        {
            pulseAvailable = true;
        } 
    }

    private void FlyPulse()
    {
        if (pulseAvailable)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(CalculateDirection(), ForceMode2D.Impulse);
            nextPulse = Time.time + pulseFrequency;
            pulseAvailable = false;
        }
        
    }


    private Vector2 CalculateDirection()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return ( 
            new Vector2(
                worldPosition.x - transform.position.x, 
                worldPosition.y - transform.position.y
                ) 
            ).normalized * velocity;
    }
}
