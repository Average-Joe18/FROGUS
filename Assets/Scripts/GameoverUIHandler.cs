using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Data.Common;

public class GameoverUIHandler : MonoBehaviour
{
   private VisualElement gameoverPanel;
   private bool restart;
   private float restartTimer;
   public static GameoverUIHandler Instance { get; private set; }


   // Awake is called when the script instance is being loaded (in this situation, when the game scene loads)
   private void Awake()
   {
       Instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
       UIDocument uiDocument = GetComponent<UIDocument>();
       gameoverPanel = uiDocument.rootVisualElement.Q<VisualElement>("Gameover");
       gameoverPanel.style.opacity = 0.0f;
       restartTimer = 3.0f;
       restart = false;
   }

   void Update()
   {
        if (restart)
        {
            restartTimer -= Time.deltaTime;

            if (restartTimer <= 0)
            {
                restart = false;
                restartTimer = 3.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
   }

   public void showGameover()
   {
        gameoverPanel.style.opacity = 1.0f;
        restart = true;

   }

   public void hideGameover()
   {
        gameoverPanel.style.opacity = 0.0f;

   }


}
