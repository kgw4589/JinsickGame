using UnityEngine;

public class GameOverZone : MonoBehaviour
{
    public GameObject gameOver;
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MainObject"))
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            
            GameManager gameManager = GameManager.Instance;
            gameManager.audioSource.clip = gameManager.gameOverClip;
            gameManager.audioSource.Play();
        }
    }
}
