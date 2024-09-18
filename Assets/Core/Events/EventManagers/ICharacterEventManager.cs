using UnityEngine.Events;

namespace Core.Events.EventManagers
{
    public interface ICharacterEventManager
    {
        /// <summary>
        ///     Invokers
        /// </summary>
        /// <param name="health"></param>
        public void TriggerCharacterChangeHealth(float health);

        public void TriggerCharacterDied(string characterName);

        public void TriggerCharacterStateInitialized();


        /// <summary>
        ///     Listeners
        /// </summary>
        /// <param name="listener"></param>
        public void AddListenerToCharacterEvent(UnityAction listener);

        public void RemoveListenerFromCharacterEvent(UnityAction listener);

        public void AddListenerToCharacterEvent(UnityAction<float> listener);

        public void RemoveListenerFromCharacterEvent(UnityAction<float> listener);

        public void AddListenerToCharacterEvent(UnityAction<string> listener);

        public void RemoveListenerFromCharacterEvent(UnityAction<string> listener);
    }
}
