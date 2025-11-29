using UnityEngine;

public class Replay : MonoBehaviour
{
    private Vector3[] dados;
    private int inicio;
    private int fim;
    private int capacidade;
    
    public Replay(int tamanho)
    {
        capacidade = tamanho;
        dados = new Vector3[tamanho];
        inicio = 0;
        fim = 0;
    }
    public bool EstaVazia()
    {
        return inicio == fim;
    }
    public bool EstaCheia()
    {
        return (fim + 1) % capacidade == inicio;
    }
    public void Enfileirar(Vector3 valor)
    {
        if (EstaCheia()) return;

        dados[fim] = valor;
        fim = (fim +1) % capacidade;
    }
    public Vector3 Desenfilera()
    {
        if (EstaVazia()) return Vector3.zero;

        Vector3 valor = dados[inicio];
        inicio = (inicio + 1) % capacidade;
        return valor;
    }
}
