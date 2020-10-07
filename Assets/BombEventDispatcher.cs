namespace Sago.Events.Test {

	using UnityEngine;
	public class BombEventDispatcher : MonoBehaviour {

		#region Events
		// the `event` keyword communicates that the author intends for multiple objects to do something when DidExplode happens
		// nobody can assign an action to `DidExplode`, they can only add or remove
		// in use cases like this, you should _always_ use the `event` keyword
		public event System.Action<BombEventDispatcher> DidExplode;


		#endregion


		#region Public Methods
		public void Explode() {
			this.DidExplode?.Invoke(this);
		}

		#endregion
	}
}