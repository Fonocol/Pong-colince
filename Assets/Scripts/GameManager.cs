using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreTextPlayer1;
    [SerializeField] private TextMeshProUGUI scoreTextPlayer2;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScorePlayer1()
    {
        scoreP1++;
        UpdateUI();
    }

    public void AddScorePlayer2()
    {
        scoreP2++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreTextPlayer1 != null) scoreTextPlayer1.text = scoreP1.ToString();
        if (scoreTextPlayer2 != null) scoreTextPlayer2.text = scoreP2.ToString();
    }
}