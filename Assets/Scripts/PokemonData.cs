using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NuovoPokemon", menuName = "Pokemon/Crea Nuovo")]
public class PokemonData : ScriptableObject
{
    public string nome;
    public float maxHP;
    public float attacco;
    public float difesa;
    public GameObject modelloPrefab;
    public List<MossaData> mosseDisponibili;

}
