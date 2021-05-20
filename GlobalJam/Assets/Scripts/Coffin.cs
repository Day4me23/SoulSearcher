using UnityEngine;

public class Coffin : MonoBehaviour
{
    public GameObject open;
    public GameObject close;
    private void Awake()
    {
        close.SetActive(true);
        open.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.hasKey)
        {
            Open();
            GameManager.instance.EndGame();
        }
        else
        {

        }
    }
    void Open()
    {
        open.SetActive(true);
        close.SetActive(false);
    }
}
