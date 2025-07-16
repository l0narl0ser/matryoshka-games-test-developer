using System;
using UnityEngine;
using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {
		FoodPlace _place = null;
		float _timer = 0f;
		private float _lastTapTime = 0f;
		private const float DoubleTapThreshold = 0.3f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if ( !IsDoubleTap() )
				return;
			
			if ( _place.CurFood != null && _place.CurFood.CurStatus == Food.FoodStatus.Overcooked ) {
				_place.FreePlace();
			}
		}

		private bool IsDoubleTap() {
			float currentTime = Time.realtimeSinceStartup;
			float delta = currentTime - _lastTapTime;
			_lastTapTime = currentTime;
			return delta <= DoubleTapThreshold;
		}
	}
}