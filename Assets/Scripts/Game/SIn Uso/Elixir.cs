using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elixir : MonoBehaviour
    {
        public int ELIXIR_MAX = 10;

        public float elixirAmount;
        public float elixirRegenAmount;

        public Elixir()
        {
            elixirAmount = 0;
            elixirRegenAmount = 1f;
        }

        public void Update()
        {
            elixirAmount += elixirRegenAmount * Time.deltaTime;
        }

        public void TrySpendElixir(int amount)
        {
            if (elixirAmount >= amount)
            {
                elixirAmount -= amount;
            }
        }

        public float GetElixirNormalized()
        {
            return elixirAmount / ELIXIR_MAX;
        }
    }
