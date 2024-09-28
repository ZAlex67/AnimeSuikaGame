using UnityEngine;

public class TriggerLoss : MonoBehaviour
{
    private float _timer = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _timer += Time.deltaTime;

            if (_timer > GameManager.Instance.TimeTillGameOver)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _timer = 0f;
        }
    }
}