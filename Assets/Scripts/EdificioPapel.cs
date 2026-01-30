using UnityEngine;

public class EdificioPapel : MonoBehaviour
{
    int stock;
    float tiempoTranscurrido;
    float intervaloGeneracion;

    public void    Awake()
    {
        this.stock = 0;
        this.intervaloGeneracion = 3f; // Genera un papel cada 3 segundos
    }

    public void    Update()
    {
        this.tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= intervaloGeneracion)
            this.increaseStock();
    }

    public int getStock()
    {
        return (this.stock);
    }

    public int collectStock()
    {
        int collected = this.getStock();
        this.stock = 0;
        return (collected);
    }

    void increaseStock()
    {
        this.stock++;
        this.tiempoTranscurrido = 0;
    }
}
