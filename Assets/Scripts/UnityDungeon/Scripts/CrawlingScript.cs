using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityDungeon;

namespace UnityDungeon
{
	public class CrawlingScript : MonoBehaviour
	{
		public CharacterData player;
		public RoomData currentRoom;
		public RevealText revealText;

		public FightScript fightScript;

	    // Start is called before the first frame update
	    IEnumerator Start()
	    {
			yield return StartCoroutine(ChangeText(currentRoom.description));
			yield return new WaitForSeconds(1);
	    }

		IEnumerator ChooseDoor()
        {
			if(currentRoom.rightRoom == null && currentRoom.leftRoom == null)
            {
				EndGame();
            }
            else
            {
				yield return ChangeText("Choose a door");
            }
        }

		public void OnRightDoorButtonPressed()
		{
			StartCoroutine(SelectRoom(true));
		}

		public void OnLeftDoorButtonPressed()
		{
			StartCoroutine(SelectRoom(false));
		}

		IEnumerable SelectRoom(bool isRightDoorChoosed)
        {
			currentRoom = isRightDoorChoosed ? currentRoom.rightRoom : currentRoom.leftRoom;

			string door = isRightDoorChoosed ? "right" : "left";
			yield return StartCoroutine(ChangeText($"You openned {door} door"));
			yield return new WaitForSeconds(0.5f);
			yield return StartCoroutine(ChangeText(currentRoom.description));
			
			if(currentRoom.oponent != null)
            {
				// fight
            }
            else
            {
				player.HP = Mathf.RoundToInt(player.HP + currentRoom.hpBoost);
				player.DEX = player.DEX + currentRoom.accuracyBoost;
				player.INT = Mathf.RoundToInt(player.INT + currentRoom.intelligenceBoost);
            }
        }

		private void EndGame()
        {
			StartCoroutine("Dungeon complete. Congrats !");
        }

		IEnumerator ChangeText(string text)
        {
			yield return StartCoroutine(revealText.ChangeText(text));
        }
	}
}
