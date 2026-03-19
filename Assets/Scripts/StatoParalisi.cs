using UnityEngine;

public class StatoParalisi : StatoBase
{

    public StatoParalisi()
    {
        nome = "Paralisi";
    }
    
    public override void ApplicaEffettiStatistiche(PokemonData pokemon)
    {
        pokemon.velocita /= 1.5f;
    }

    public override bool PuòAttaccare(PokemonData pokemon)
    {
        return Random.value > 0.25f;
    }

    public override float DannoFineTurno(PokemonData pokemon) => 0;

    public override void RimuoviEffetti(PokemonData pokemon)
    {
        pokemon.velocita *= 1.5f;
    }
}
