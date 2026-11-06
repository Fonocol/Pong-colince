using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        PongBall ball = other.GetComponent<PongBall>();

        if (ball != null)
        {
            if (isPlayer1Goal)
            {
               
                GameManager.Instance.AddScorePlayer2();
            }
            else
            {
                
                GameManager.Instance.AddScorePlayer1();
            }

            
            ball.ResetBall();
        }
    }
}