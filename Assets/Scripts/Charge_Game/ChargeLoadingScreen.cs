using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargeLoadingScreen : MonoBehaviour
{
   public void CargarPantalla()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
