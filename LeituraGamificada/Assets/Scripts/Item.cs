using UnityEngine;
using System.Collections;

namespace Custom
{
    public class Item
    {

        public enum ItemTipo
        {
            ARMA,
            ARMADURA
        }

        public enum ItemElemento
        {
            FOGO,
            GELO,
            ELETRICIDADE,
            VENENO
        }

        public string nome;
        public int paginasTotal;
        public int paginasLidas;
        public int capitulosTotal;
        public int capitulosLidos;
        public int nivelBase;

        public ItemTipo tipo;
        public int ataque;
        public int defesa;
        public int agilidade;
        public int estamina;
        public ItemElemento elemento;

        public int indiceVisual = 0;


        private bool habilidadeLiberada = false;

        private static int valorGeradorAtributo = 10;

        public static Item GenerateNewItem(string p_nome, int p_paginasTotal, int p_paginasLidas, int p_capitulosTotal, int p_capitulosLidos, int p_nivelBase)
        {
            Item __tempItem = new Item();
            Random.seed = p_nome.GetHashCode();

            __tempItem.nome = p_nome;
            __tempItem.paginasTotal = p_paginasTotal;
            __tempItem.paginasLidas = p_paginasLidas;
            __tempItem.capitulosTotal = p_capitulosTotal;
            __tempItem.capitulosLidos = p_capitulosLidos;
            __tempItem.nivelBase = p_nivelBase;

            __tempItem.tipo = (ItemTipo)(Random.Range(0, System.Enum.GetNames(typeof(ItemTipo)).Length));
            __tempItem.elemento = (ItemElemento)(Random.Range(0, System.Enum.GetNames(typeof(ItemElemento)).Length));
            __tempItem.ataque = Random.Range((p_nivelBase - 1) * valorGeradorAtributo, p_nivelBase * valorGeradorAtributo);
            __tempItem.defesa = Random.Range((p_nivelBase - 1) * valorGeradorAtributo, p_nivelBase * valorGeradorAtributo);
            __tempItem.agilidade = Random.Range((p_nivelBase - 1) * valorGeradorAtributo, p_nivelBase * valorGeradorAtributo);
            __tempItem.estamina = Random.Range((p_nivelBase - 1) * valorGeradorAtributo, p_nivelBase * valorGeradorAtributo);

            return __tempItem;
        }        
    }    
}
