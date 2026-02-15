using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Configurações")]
    // A sensibilidade do mouse. O [Range] cria um slider na Unity para facilitar o ajuste.
    [Range(50f, 500f)]
    [SerializeField] private float mouseSensitivity = 100f;

    [Header("Referências")]
    // Precisamos saber quem é o corpo do jogador para girá-lo
    [SerializeField] private Transform playerBody;

    private float xRotation = 0f; // Variável para controlar o olhar vertical

    void Start()
    {
        // Trava o cursor no centro da tela e o deixa invisível (padrão de jogos FPS)
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Coleta a entrada do mouse
        // Multiplicamos por Time.deltaTime para que a velocidade seja independente dos FPS
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 2. Calcula a rotação vertical (Olhar para cima e para baixo)
        xRotation -= mouseY; // Subtraímos porque na Unity o eixo invertido é o padrão para rotação X

        // Clamp (Grampear): Impede que o jogador quebre o pescoço dando uma volta completa (360º)
        // Limitamos entre -90 graus (olhar pro chão) e 90 graus (olhar pro céu)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // 3. Aplica a rotação na CÂMERA (apenas eixo X local)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 4. Aplica a rotação no CORPO do Player (apenas eixo Y - girar para os lados)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
