using UnityEngine;

public class Movomento_latera : MonoBehaviour
{
    public float Speed = 5f;
    public float horizontal;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * horizontal * Speed * Time.deltaTime;
    }
}
