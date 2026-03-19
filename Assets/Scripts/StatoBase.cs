using UnityEngine;

public abstract class StatoBase
{
    public string nome;
    public abstract void ApplicaEffettiStatistiche(PokemonData pokemon);
    public abstract bool PuòAttaccare(PokemonData pokemon);
    public abstract float DannoFineTurno(PokemonData pokemon);
    public abstract void RimuoviEffetti(PokemonData pokemon);
}