using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
   [SerializeField] private string jogo1;
   [SerializeField] private string jogo2;
   [SerializeField] private string jogo3;
   [SerializeField] private GameObject painelMenu;
   [SerializeField] private GameObject painelOpcoes;
   [SerializeField] private GameObject painelMapa;
             private float esc;


  private void Update()
    {

       esc = Input.GetAxis("esc");
      if(esc > 0){
         SceneManager.LoadScene("MainMenu");
      }

   }

   public void Jogar()
   {
      painelMenu.SetActive(false);
      painelMapa.SetActive(true);
   }

   public void Tutorial()
   {
      SceneManager.LoadScene(jogo1);
   }

   public void Desafio()
   {
      SceneManager.LoadScene(jogo2);
   }
  
   public void Rescue()
   {
      SceneManager.LoadScene(jogo3);
   }

   public void AbrirOpcoes()
   {
      painelMenu.SetActive(false);
      painelOpcoes.SetActive(true);
   }

   public void VoltarOpcoes()
   {
      painelMenu.SetActive(true);
      painelOpcoes.SetActive(false);
   }

   public void VoltarJogar()
   {
      painelMenu.SetActive(true);
      painelMapa.SetActive(false);
   }

   public void SairJogo()
   {
      Debug.Log("Saiu do jogo");
      Application.Quit();
   }
}