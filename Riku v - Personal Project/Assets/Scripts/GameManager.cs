using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float distance;
    public Transform player;

    public TextMeshProUGUI scoreObject;
    public int scoreNumber;
   
  

    void Awake() 
    {
        distance = Vector3.Distance (player.position, transform.position);
    }

    public void EndGame ()    
    {
        if (gameHasEnded == false)
        {
        gameHasEnded = true;
        Debug.Log("GAME OVER!");
        Restart();
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
        
    // Update is called once per frame
    void Update()
    {
        score ();
    }

    void score()
    {
        distance = Vector3.Distance (player.position, transform.position);
        scoreNumber = Mathf.RoundToInt(distance);
        scoreObject.text = scoreNumber.ToString();

        if (scoreNumber > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", scoreNumber);
        }  
    }
}
