namespace Sago.Delegates.Test {

	using UnityEngine;
	using UnityEngine.UI;

	public class BombDelegateFactory : MonoBehaviour {

		#region Serialized Fields

		[SerializeField]
		private BombDelegateManager m_BombManager;

		[SerializeField]
		private int m_Ammo;

		[SerializeField]
		private Text m_DelegateResponseText;

		#endregion


		#region Event Subscription

		public void SubscribeToBomb() {
			UnsubscribeFromBomb();
			m_BombManager.CreateBombFunc = CreateBomb;
			m_BombManager.GetAmmoStats = GetAmmoStats;
			Debug.Log("Subscribing bomb factory ", gameObject);
		}

		public void UnsubscribeFromBomb() {
			m_BombManager.CreateBombFunc = null;
			m_BombManager.GetAmmoStats = null;
		}


		#endregion


		#region Event Handling

		private void CreateBomb() {
			PlayCreationReaction();
		}

		private int GetAmmoStats() {
			return m_Ammo;
		}

		#endregion


		#region Internal Methods

		private void PlayCreationReaction() {
			string createdText;
			createdText = gameObject.name + " Created bomb!";
			Debug.Log(createdText);
			if (m_DelegateResponseText != null) {
				m_DelegateResponseText.text = createdText;
			}
		}


		#endregion
	}
}
