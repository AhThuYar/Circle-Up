using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Player : MonoBehaviour
{
    ScoreManager _score;

    [Header("Player Settings")]
    public float jump;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private new CircleCollider2D collider;
    [SerializeField] private bool activePlayer = true;

    [Header("Player Game Objects")]
    public GameObject PlayerGameObject;
    public GameObject imageGameOver;
    public GameObject PowerBoard;
    public GameObject pauseButton;
    public GameObject groundFloor;

    [Header("Power Up")]
    public Image imagePower;
    public float powerUpDuration = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        _score = FindAnyObjectByType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
        {
            if (!activePlayer)
            {
                return;
            }

            SoundManager.instance.JumpSound();

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            PowerMode();
            Destroy(groundFloor);
        }

        Camera mainCamera = Camera.main;
        float cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;

        if (transform.position.y < cameraBottom - 3f) // 1f buffer
        {
            Time.timeScale = 0f;
            imageGameOver.SetActive(true);
            Destroy(PlayerGameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Circle"))
        {
            StartCoroutine(DeadDelayCoroutine());
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            FindAnyObjectByType<SoundManager>().BoundSound();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            imagePower.fillAmount += 0.1f;
            _score.GetScore();
            FindAnyObjectByType<SoundManager>().ScoreSound();
        }
        Destroy(collision.gameObject);
        Debug.Log("Collision Destroy");
    }

    public IEnumerator DeadDelayCoroutine()
    {
        Debug.Log("Game Over");
        collider.enabled = false;
        activePlayer = false;
        FindAnyObjectByType<SoundManager>().GameOverSound();

        yield return new WaitForSeconds(2f);

        Time.timeScale = 0f;
        imageGameOver.SetActive(true);
        PowerBoard.SetActive(false);
        pauseButton.SetActive(false);
    }
    public void PowerMode()
    {
        if (imagePower.fillAmount >= 1f)
        {
            StartCoroutine(PowerUp());
        }
        else
        {
            Debug.Log("Power Mode Not Ready");
        }
    }
    public IEnumerator PowerUp()
    {
        imagePower.fillAmount = 0f;
        rb.AddForce(new Vector2(0f, jump * 4), ForceMode2D.Impulse);
        collider.enabled = false;
        Debug.Log("Power Mode Activated");

        yield return new WaitForSeconds(3f);

        collider.enabled = true;
    }
}
