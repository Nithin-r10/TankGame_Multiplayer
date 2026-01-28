using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 Movedirection  = new Vector3 (horizontal, 0, vertical);
        transform.Rotate(0, horizontal, 0);
        transform.Translate( Movedirection * speed * Time.deltaTime);
    }
}
