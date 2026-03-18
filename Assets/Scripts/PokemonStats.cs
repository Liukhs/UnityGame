using UnityEngine;

public class PokemonStats : MonoBehaviour
{
    public PokemonData datiBase;
    public float hpAttuali;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        hpAttuali = datiBase.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
