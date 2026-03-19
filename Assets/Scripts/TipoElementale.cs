using UnityEngine;

public enum TipoElementale
{
    NORMALE, 
    LOTTA,
    VOLANTE,
    VELENO,
    TERRA,
    ROCCIA,
    COLEOTTERO,
    SPETTRO,
    ACCIAO,
    FUOCO,
    ACQUA,
    ERBA, 
    ELETTRO,
    PSICO,
    GHIACCIO,
    DRAGO,
    BUIO

}

public static class TipoExtensions
{
    public static float GetEfficacia(this TipoElementale attaccante, TipoElementale difensore)
    {
       return attaccante switch
       {
            TipoElementale.NORMALE => difensore switch
            {
                TipoElementale.ROCCIA or
                TipoElementale.ACCIAO => 0.5f,
                _=>1.0f
            },
            TipoElementale.LOTTA => difensore switch
            {
                TipoElementale.NORMALE or
                TipoElementale.ROCCIA or
                TipoElementale.ACCIAO or
                TipoElementale.GHIACCIO or
                TipoElementale.BUIO => 2.0f,
                TipoElementale.VOLANTE or
                TipoElementale.VELENO or
                TipoElementale.COLEOTTERO or
                TipoElementale.PSICO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.VOLANTE => difensore switch
            {
                TipoElementale.LOTTA or
                TipoElementale.COLEOTTERO or
                TipoElementale.ERBA => 2.0f,
                TipoElementale.ROCCIA or
                TipoElementale.ACCIAO or
                TipoElementale.ELETTRO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.VELENO => difensore switch
            {
                TipoElementale.ERBA => 2.0f,
                TipoElementale.VELENO or
                TipoElementale.TERRA or
                TipoElementale.ROCCIA or
                TipoElementale.SPETTRO => 0.5f,
                TipoElementale.ACCIAO => 0.0f,
                _ => 1.0f
            },
            TipoElementale.TERRA => difensore switch
            {
                TipoElementale.VELENO or
                TipoElementale.ROCCIA or
                TipoElementale.ACCIAO or
                TipoElementale.FUOCO or
                TipoElementale.ELETTRO => 2.0f,
                TipoElementale.COLEOTTERO or
                TipoElementale.ERBA => 0.5f,
                TipoElementale.VOLANTE => 0.0f,
                _ => 1.0f
            },
            TipoElementale.ROCCIA => difensore switch
            {
                TipoElementale.VOLANTE or
                TipoElementale.COLEOTTERO or
                TipoElementale.FUOCO or
                TipoElementale.GHIACCIO => 2.0f,
                TipoElementale.LOTTA or
                TipoElementale.TERRA or
                TipoElementale.ACCIAO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.COLEOTTERO => difensore switch
            {
                TipoElementale.ERBA or
                TipoElementale.PSICO or
                TipoElementale.BUIO => 2.0f,
                TipoElementale.LOTTA or
                TipoElementale.VOLANTE or
                TipoElementale.VELENO or
                TipoElementale.SPETTRO or
                TipoElementale.ACCIAO or
                TipoElementale.FUOCO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.SPETTRO => difensore switch
            {
                TipoElementale.SPETTRO or
                TipoElementale.PSICO => 2.0f,
                TipoElementale.ACCIAO or
                TipoElementale.BUIO => 0.5f,
                TipoElementale.NORMALE => 0.0f,
                _ => 1.0f
            },
            TipoElementale.ACCIAO => difensore switch
            {
                TipoElementale.ROCCIA or
                TipoElementale.GHIACCIO => 2.0f,
                TipoElementale.ACCIAO or
                TipoElementale.FUOCO or
                TipoElementale.ACQUA or
                TipoElementale.ELETTRO => 0.5f,
                _ => 1.0f
            }, 
            TipoElementale.FUOCO => difensore switch
            {
                TipoElementale.COLEOTTERO or
                TipoElementale.ACCIAO or
                TipoElementale.ERBA or
                TipoElementale.GHIACCIO => 2.0f,
                TipoElementale.ROCCIA or
                TipoElementale.FUOCO or
                TipoElementale.ACQUA or
                TipoElementale.DRAGO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.ACQUA => difensore switch
            {
                TipoElementale.TERRA or
                TipoElementale.ROCCIA or
                TipoElementale.FUOCO => 2.0f,
                TipoElementale.ACQUA or
                TipoElementale.ERBA or
                TipoElementale.DRAGO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.ERBA => difensore switch
            {
                TipoElementale.TERRA or
                TipoElementale.ROCCIA or
                TipoElementale.ACQUA => 2.0f,
                TipoElementale.VOLANTE or
                TipoElementale.VELENO or
                TipoElementale.COLEOTTERO or
                TipoElementale.ACCIAO or
                TipoElementale.FUOCO or
                TipoElementale.ERBA or
                TipoElementale.DRAGO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.ELETTRO => difensore switch
            {
                TipoElementale.VOLANTE or
                TipoElementale.ACQUA => 2.0f,
                TipoElementale.ERBA or
                TipoElementale.ELETTRO or
                TipoElementale.DRAGO => 0.5f,
                TipoElementale.TERRA => 0f,
                _ => 1.0f
            },
            TipoElementale.PSICO => difensore switch
            {
                TipoElementale.LOTTA or
                TipoElementale.VELENO => 2.0f,
                TipoElementale.ACCIAO or
                TipoElementale.PSICO => 0.5f,
                TipoElementale.BUIO => 0f,
                _ => 1.0f
            },
            TipoElementale.GHIACCIO => difensore switch
            {
                TipoElementale.VOLANTE or
                TipoElementale.TERRA or
                TipoElementale.ERBA or
                TipoElementale.DRAGO => 2.0f,
                TipoElementale.ACCIAO or
                TipoElementale.FUOCO or
                TipoElementale.ACQUA or
                TipoElementale.PSICO => 0.5f,
                _ => 1.0f
            },
            TipoElementale.DRAGO => difensore switch
            {
                TipoElementale.DRAGO => 2.0f,
                TipoElementale.ACCIAO => 0.5f,
                _ => 1.0f 
            },
            TipoElementale.BUIO => difensore switch
            {
                TipoElementale.PSICO or
                TipoElementale.SPETTRO => 2.0f,
                TipoElementale.LOTTA or
                TipoElementale.ACCIAO or
                TipoElementale.BUIO => 0.5f,
                _ => 1.0f 
            },
            _ => 1.0f
       }; 
    }
}