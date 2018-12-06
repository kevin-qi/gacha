using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeroText : MonoBehaviour
{
				GameObject parentHero;
				Text text;
				// Use this for initialization
				void Awake()
				{
								HeroStats.StatsUpdate += UpdateText;
								text = GetComponent<Text>();
								parentHero = transform.parent.parent.gameObject;
				}

				private void UpdateText()
				{
								var script = parentHero.GetComponent<HeroStats>();
								int atk = script.GetAttack();
								int def = script.GetDefense();
								int hp = script.GetHealth();
								int spd = script.GetSpeed();
								int turnbar = script.GetTurnbar();
								string name = script.GetName();

								text.text = name + "\n" + "HP: " + hp + "\n" + "Turnbar: " + turnbar;
				}
}
