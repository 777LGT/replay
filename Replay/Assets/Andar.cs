using UnityEngine;

public class Andar : MonoBehaviour
{
    public float speed = 5f;
    private Replay replay;
    private bool gravando = true;
    private bool fila = false;
  
    void Start()
    {
        replay = new Replay(5000);
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E))
        {
            gravando = false;
            fila = true;
        }
        if (gravando)
            GravarMovimento();
        else if (fila)
            ReproduzirMovimento();
    }
    void GravarMovimento()
    {
        float x = 0;
        float z = 0;

        if (Input.GetKey(KeyCode.W)) z = 1;
        if (Input.GetKey(KeyCode.S)) z = - 1;
        if (Input.GetKey(KeyCode.A)) x = -1;
        if (Input.GetKey(KeyCode.D)) x = 1;

        Vector3 direcao = new Vector3(x, 0, z);
        transform.position += direcao * speed * Time.deltaTime;
        replay.Enfileirar(transform.position);
    }
    void ReproduzirMovimento()
    {
        if (!replay.EstaVazia())
        {
            Vector3 pos = replay.Desenfilera();
            transform.position = pos;   
        }
        else
        {
            fila = false;
        }

    }
}
