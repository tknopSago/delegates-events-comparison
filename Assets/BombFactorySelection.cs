namespace Sago.Delegates.Test {
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	public class BombFactorySelection : MonoBehaviour {

		#region Serialized Fields

		[SerializeField]
		private Dropdown m_FactorySelection;

		[SerializeField]
		private List<BombDelegateFactory> m_BombFactories;

		#endregion


		private void Start() {
			if (m_BombFactories.Count > 0) {
				SubscribeFactory(0);
			}
			m_FactorySelection.onValueChanged.AddListener(SelectFactory);
		}

		public void SelectFactory(int idx) {
			if (m_BombFactories.Count > idx) {
				SubscribeFactory(idx);
			}
		}

		private void SubscribeFactory(int idx) {
			BombDelegateFactory bombDelegateFactory;
			bombDelegateFactory = m_BombFactories[idx];
			bombDelegateFactory.SubscribeToBomb();
		}
	}

}
