using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int totalScore = 0;

    // Unity chama isso automaticamente quando entra em um Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Tenta pegar o script "Collectible" do objeto que encostamos
        // Se o objeto não tiver o script, a variável será null
        Collectible item = other.GetComponent<Collectible>();

        if (item != null)
        {
            totalScore += item.GetScoreValue();
            item.Collect(); // Manda o item se autodestruir
            
            Debug.Log($"Pontuação Total: {totalScore}");
        }
    }
}
