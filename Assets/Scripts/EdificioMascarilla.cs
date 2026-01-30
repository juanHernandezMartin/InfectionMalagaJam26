using UnityEngine;

public class EdificioMascarilla : MonoBehaviour
{
    int stock;
    float tiempoTranscurrido;

    public void    Awake()
    {
        this.stock = 0;
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

}
