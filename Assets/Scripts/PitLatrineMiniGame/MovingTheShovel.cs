using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MovingTheShovel : MonoBehaviour
{
    private float movementSpeed = 5f;
    public Button Button;
    private UnityEvent OnClick;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);
    }

    public void Dig()
    {
        transform.position = transform.position + new Vector3(0, -5*movementSpeed*Time.deltaTime, 0);
    }
    
}
