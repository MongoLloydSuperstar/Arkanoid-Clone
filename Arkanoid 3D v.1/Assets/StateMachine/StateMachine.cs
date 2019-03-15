namespace StateManaging
{
    public class StateMachine<T>
    {
        public State<T> CurrentState { get; private set; }
        public T owner;

        private bool changeIfSame = false;

        public StateMachine(T _owner)
        {
            owner = _owner;
            CurrentState = null;
        }

        public StateMachine(T _owner, bool _changeIfSame)
        {
            owner = _owner;
            changeIfSame = _changeIfSame;
            CurrentState = null;
        }

        public void ChangeState(State<T> _newState)
        {
            if ((CurrentState == _newState && changeIfSame == true) || CurrentState != _newState) {

                if (CurrentState != null) {
                    CurrentState.ExitState(owner);
                }
                CurrentState = _newState;
                CurrentState.EnterState(owner);
            }
        }

        public void Update()
        {
            if (CurrentState != null) {
                CurrentState.UpdateState(owner);
            }
        }
    }

    public abstract class State<T>
    {
        public abstract void EnterState(T _owner);
        public abstract void ExitState(T _owner);
        public abstract void UpdateState(T _owner);
    }

}
