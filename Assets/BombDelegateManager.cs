namespace Sago.Delegates.Test {

	using UnityEngine;
	using UnityEngine.UI;

	public class BombDelegateManager : MonoBehaviour {

		#region Delegates

		// a `System.Action` property without event communicates that this class is expecting someone else to provide an implementation here
		// since this class only supports one way to create bombs, it's expecting exactly one implementation to be assigned 
		// you should _never_ use the `event` keyword in this case
		// it has nothing to do with events, it's a structural pattern for abstracting part of an implementation
		// (you could achieve something similar with an abstract method and expecting subclasses to provide an implementation)
		public System.Action CreateBombFunc {
			get;
			set;
		}

		public System.Func<int> GetAmmoStats {
			get;
			set;
		}

		#endregion


		#region Serialized Fields

		[SerializeField]
		private Text m_DelegateResponseText;

		#endregion


		#region Public Methods
		public void CreateBomb() {
			if (this.CreateBombFunc != null) {
				this.CreateBombFunc();
			}
		}

		public void GetAmmo() {
			if (this.GetAmmoStats != null) {
				string ammoResponse;
				ammoResponse = "Ammo: " + GetAmmoStats();
				Debug.Log(ammoResponse);
				if (m_DelegateResponseText != null) {
					m_DelegateResponseText.text = ammoResponse;
				}
			}
		}

		#endregion
	}
}
