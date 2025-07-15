using UnityEngine;
using UnityEngine.UI;
using CookingPrototype.Controllers;
using TMPro;

namespace CookingPrototype.UI {
	public class StartWindow : MonoBehaviour {
		[SerializeField] private Button _playButton;
		[SerializeField] private TMP_Text _goalFoodCount;
		private bool _isInit = false;

		public void Init() {
			var gameplayController = GameplayController.Instance;
			_playButton.onClick.AddListener(() => {
				gameplayController.Restart();
				Hide();
			});
			_isInit = true;
		}

		public void Show() {
			if ( !_isInit ) {
				Init();
			}

			GameplayController gameplayController = GameplayController.Instance;

			_goalFoodCount.text = gameplayController.OrdersTarget.ToString();
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}