using UnityEngine;

public class Movement : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    Vector2 movement;
    Vector2 mousePos;
    public float speed = 3;
    public Camera cam;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
        rigidbody.rotation = angle;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("NodeUp"))
            GameManager.instance.RoomChange(1, false);
        if (collision.transform.CompareTag("NodeDown"))
            GameManager.instance.RoomChange(2, false);
        if (collision.transform.CompareTag("NodeLeft"))
            GameManager.instance.RoomChange(3, false);
        if (collision.transform.CompareTag("NodeRight"))
            GameManager.instance.RoomChange(4, false);

        if (collision.transform.CompareTag("Key"))
        {

            GameManager.instance.hasKey = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Candle"))
        {
            GameManager.instance.envGen.roomList[GameManager.instance.roomListNumber].candleConsumed = true;
            GetComponent<Candle>().Gain(8);
            Destroy(collision.gameObject);
        }
    }
}