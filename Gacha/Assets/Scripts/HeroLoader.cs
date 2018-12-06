using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLoader : MonoBehaviour
{
				// Event to signal that heroes data from database is loaded
				public delegate void Loaded(ArrayList dataPacket);
				public static event Loaded LoadedHeroes;

				// Use this for initialization
				IEnumerator Start()
				{
								WWW heroesData = new WWW("https://afxgacha.000webhostapp.com/Heroes.php");
								yield return heroesData;

								string data = heroesData.text;
								string[] heroesList = data.Split('~');
								// Each string in heroesList have the following format:
								// userId:userId|heroId:heroId|... etc ...

								ArrayList dataPacket = new ArrayList();
								foreach (string hero in heroesList)
								{
												if (hero != "")
												{
																Debug.Log("hero: " + hero);
																Dictionary<string, string> packet = new Dictionary<string, string>();
																foreach (string keyvalue in hero.Split('|'))
																{
																				string key = keyvalue.Split(':')[0];
																				string value = keyvalue.Split(':')[1];

																				packet[key] = value;
																}
																dataPacket.Add(packet);
												}
								}

								// Heroes data is loaded, signal LoadedHeroes event
								LoadedHeroes(dataPacket);
				}
}
