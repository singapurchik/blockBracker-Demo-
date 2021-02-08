using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playScore;
    [SerializeField] int pointForBlock = 83;
    [SerializeField] TextMeshProUGUI playScoreText;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed;

    private void Awake()
    {
       int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        if(gameSessionCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playScoreText.text = playScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void PlayScore()
    {
        playScore += pointForBlock;
        playScoreText.text = playScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
