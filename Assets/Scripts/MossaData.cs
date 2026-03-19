using UnityEngine;
[CreateAssetMenu(fileName = "Nuova Mossa", menuName = "Mossa/Crea nuovo")]
public class MossaData : ScriptableObject
{
    public string nomeMossa;
    public string descrizione;
    public float potenza;
    public int pp;
    public TipoElementale tipo;
    public CategoriaMossa categoria;
    public enum CategoriaMossa
    {
        FISICA,
        SPECIALE,
        STATO
    }

    [Header("Effetti di stato")]
    public StatoAlterato statoDaInfliggere;
    [Range(0, 100)]
    public int probabilitaEffetto;
    
}
