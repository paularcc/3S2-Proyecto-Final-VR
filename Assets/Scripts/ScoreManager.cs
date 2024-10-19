using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    private void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void IncreaseScore() {
        score++;
        UpdateScoreText();
        if (score >= 11) {
            SceneManager.LoadScene(1);
        }
}
}
