using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField][Range(200.0f, 750.0f)] float launchSpeed = 350.0f;
    Rigidbody2D rb;
    AudioSource audioSrc;
    GameObject respawnPanel;
    Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
        respawnPanel = GameObject.Find("Respawn Panel");
        respawnPanel.SetActive(false);
        startPosition = rb.position;
        LaunchBall();
    }
    void ResetBall()
    {
        rb.position = startPosition;
        rb.velocity = Vector2.zero;
    }

    void LaunchBall()
    {
        float angle = ((Random.Range(0, 2) * 180) - Random.Range(135, 225)) * Mathf.Deg2Rad;
        rb.AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized * launchSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            ResetBall();
            Time.timeScale = 0.0f;
            respawnPanel.SetActive(true);
            StartCoroutine(ShouldRespawn());
        }
        else
        {
            audioSrc.Play();
        }
    }

    IEnumerator ShouldRespawn()
    {
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }

            yield return null;
        }

        respawnPanel.SetActive(false);
        Time.timeScale = 1.0f;
        LaunchBall();
    }
}
