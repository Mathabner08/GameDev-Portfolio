using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private string itemName = "Moeda";
    [SerializeField] private int scoreValue = 10;

    // Método público para permitir que o Player acesse os dados do item
    public int GetScoreValue()
    {
        return scoreValue;
    }

    public void Collect()
    {
        Debug.Log($"Item coletado: {itemName}");
        
        // Efeito sonoro ou visual poderia entrar aqui
        
        Destroy(gameObject); // Remove o objeto da cena
    }
}
