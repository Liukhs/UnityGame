using UnityEngine;

public class StatoIperVeleno : StatoBase
{
    private int turniPassati = 1;

    public override string nome = "Iperveleno";
    public override float DannoFineTurno(PokemonData p)
    {
        float danno = Mathf.Max(1, (int)((p.maxHP / 16f) * turniPassati));

        turniPassati++;

        return danno;
    }
    public override void ApplicaEffettiStatistiche(PokemonData p);
    public override bool PuòAttaccare(PokemonData p)
    {
        return true;
    }
    public override void RimuoviEffetti(PokemonData p)
    {
        
    } 
}
