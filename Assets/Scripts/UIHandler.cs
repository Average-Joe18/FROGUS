using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIHandler : MonoBehaviour
{
   private Label scoreLabel;
   private float score;
   public static UIHandler Instance { get; private set; }


   // Awake is called when the script instance is being loaded (in this situation, when the game scene loads)
   private void Awake()
   {
       Instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
       UIDocument uiDocument = GetComponent<UIDocument>();
       scoreLabel = uiDocument.rootVisualElement.Q<Label>("Score");
       score = 0.0f;
       scoreLabel.text = "0";
   }

   void Update()
   {
        //score += Time.deltaTime;
   }

   public void AlterScore(float amount)
   {
        score += amount;
        scoreLabel.text = ((int)score).ToString();

   }


}