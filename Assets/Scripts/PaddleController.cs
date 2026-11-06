using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private bool isPlayerOne = true;
    [SerializeField] private float yBoundary = 4f;

    private void Update()
    {
        float direction = 0f;

        if (Keyboard.current != null)
        {
            if (isPlayerOne)
            {
                
                if (Keyboard.current.wKey.isPressed || Keyboard.current.zKey.isPressed) direction = 1f;
                if (Keyboard.current.sKey.isPressed) direction = -1f;
            }
            else
            {
                
                if (Keyboard.current.upArrowKey.isPressed) direction = 1f;
                if (Keyboard.current.downArrowKey.isPressed) direction = -1f;
            }
        }

        // Déplacement vertical
        Vector3 newPosition = transform.position + Vector3.up * direction * speed * Time.deltaTime;

        // Blocage de la raquette dans les limites de l'écran
        newPosition.y = Mathf.Clamp(newPosition.y, -yBoundary, yBoundary);
        transform.position = newPosition;
    }
}