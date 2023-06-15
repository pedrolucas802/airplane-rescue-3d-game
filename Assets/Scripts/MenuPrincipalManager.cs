using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
   [SerializeField]private string tutorial1;
   [SerializeField]private string tutorial2;
   [SerializeField]private GameObject painelMenu;
   [SerializeField]private GameObject painelOpcoes;
   [SerializeField]private GameObject painelMapa;

   public void Jogar(){
    painelMenu.SetActive(false);
    painelMapa.SetActive(true);
   }

   public void MapaAviao(){
    SceneManager.LoadScene(tutorial1);
    
   }

   public void MapaHelicoptero(){
    SceneManager.LoadScene(tutorial2);
    
   }

   public void AbrirOpcoes(){
      painelMenu.SetActive(false);
      painelOpcoes.SetActive(true);
   }
   
   public void VoltarOpcoes(){
      painelMenu.SetActive(true);
      painelOpcoes.SetActive(false);
   }

   public void VoltarJogar(){
      painelMenu.SetActive(true);
      painelMapa.SetActive(false);
   }

   public void SairJogo(){
      Debug.Log("Saiu do jogo");
      Application.Quit();
   }
}
