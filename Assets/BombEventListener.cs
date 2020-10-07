namespace Sago.Events.Test {

	using System.Collections.Generic;
	using UnityEngine;

	public class BombEventListener : MonoBehaviour {

		#region Serialized Fields

		[SerializeField]
		private List<BombEventDispatcher> m_Bombs;

		[SerializeField]
		private GameObject m_EffectOnReaction;

		#endregion


		#region Event Subscription

		public void SubscribeToBombs() {
			UnsubscribeFromBombs();
			foreach (var bomb in m_Bombs) {
				bomb.DidExplode += OnBombDidExplode;
			}
		}

		public void UnsubscribeFromBombs() {
			foreach (var bomb in m_Bombs) {
				bomb.DidExplode -= OnBombDidExplode;
			}
		}

		#endregion


		#region Monobehaviour 

		private void Start() {
			SubscribeToBombs();
		}

		#endregion


		#region Event Handling

		private void OnBombDidExplode(BombEventDispatcher bomb) {
			PlayExplosionReaction();
		}

		#endregion


		#region Internal Methods

		private void PlayExplosionReaction() {
			if (m_EffectOnReaction != null) {
				m_EffectOnReaction.SetActive(true);
				Invoke("DisableEffect", 1);
			}
		}

		private void DisableEffect() {
			if (m_EffectOnReaction != null) {
				m_EffectOnReaction.SetActive(false);
			}
		}

		#endregion
	}
}
