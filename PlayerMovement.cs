using UnityEngine;

// Este atributo garante que o Unity adicione automaticamente um CharacterController se não houver um.
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Verificação de Chão")]
    [SerializeField] private Transform groundCheck; // Arraste um objeto vazio posicionado nos pés do player
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask; // Defina o que é "chão" nas Layers

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ApplyGravity();
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        // Pega o input do teclado (WASD ou Setas)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Cria o vetor de movimento baseado na direção para onde o player está olhando
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        // Só pula se estiver no chão e apertar o botão de pulo (Espaço)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Fórmula física de pulo: v = raiz(h * -2 * g)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        // Verifica se está tocando o chão usando uma esfera invisível nos pés
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantém o player "grudado" no chão, forçando levemente para baixo
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
