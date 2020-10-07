namespace Sago.Delegates.Test {

	using UnityEngine;

	public class BombDelegateFactory : MonoBehaviour {

		#region Serialized Fields

		[SerializeField]
		private BombDelegateManager m_BombManager;

		[SerializeField]
		private GameObject m_EffectOnCreation;

		#endregion


		#region Event Subscription

		public void SubscribeToBomb() {
			UnsubscribeFromBomb();
			m_BombManager.CreateBombFunc = CreateBomb;
		}

		public void UnsubscribeFromBomb() {
			m_BombManager.CreateBombFunc = null;
		}


		#endregion


		#region Monobehaviour 

		private void Start() {
			SubscribeToBomb();
		}

		#endregion


		#region Event Handling

		private void CreateBomb() {
			PlayCreationReaction();
		}

		#endregion


		#region Internal Methods

		private void PlayCreationReaction() {
			if (m_EffectOnCreation != null) {
				m_EffectOnCreation.SetActive(true);
				Invoke("DisableEffect", 1);
			}
		}

		private void DisableEffect() {
			if (m_EffectOnCreation != null) {
				m_EffectOnCreation.SetActive(false);
			}
		}

		#endregion
	}
}
