namespace BlazorAuto.Components.Store
{
    public class CounterState
    {
        public string Count { get; }

        public CounterState(string count)
        {
            Count = count;
        }
    }

    public class CounterStore
    {
        private CounterState _state;

        public CounterStore()
        {
            _state = new CounterState("");
        }


        public CounterState GetState()
        {
            return _state;
        }

        public void IncrementCount()
        {
            var count = "Kaiser";
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        public void DecrementCount()
        {
            var count = "Arman";
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        private Action _listeners;

        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        public void BroadcastStateChange()
        {
            _listeners.Invoke();
        }
    }

}
