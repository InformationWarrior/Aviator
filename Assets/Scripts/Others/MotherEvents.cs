namespace Mother
{
    public abstract class AbstractEvent
    {
        public int DispatchCount { get; private set; }

        public abstract bool HasDuplicateParameterTypes();

        protected void OnDispatch()
        {
            DispatchCount++;
        }
    }
    public class MotherEvent : AbstractEvent
    {
        private System.Action onTrigger;

        public MotherEvent()
        {
        }

        public void Dispatch()
        {
            onTrigger?.Invoke();
            OnDispatch();
        }

        public void AddListener(System.Action handler)
        {
            onTrigger += handler;
        }

        public void RemoveListener(System.Action handler)
        {
            onTrigger -= handler;
        }
        public override bool HasDuplicateParameterTypes()
        {
            return false;
        }
    }

    public class MotherEvent<T> : AbstractEvent
    {
        private System.Action<T> onTrigger;

        public MotherEvent()
        {
        }

        public void Dispatch(T value)
        {
            onTrigger?.Invoke(value);
            OnDispatch();
        }

        public void AddListener(System.Action<T> handler)
        {
            onTrigger += handler;
        }

        public void RemoveListener(System.Action<T> handler)
        {
            onTrigger -= handler;
        }

        public override bool HasDuplicateParameterTypes()
        {
            return false;
        }
    }

    public class MotherEvent<T, U> : AbstractEvent
    {
        private System.Action<T, U> onTrigger;

        public MotherEvent()
        {
        }

        public void Dispatch(T value, U value2)
        {
            onTrigger?.Invoke(value, value2);
            OnDispatch();
        }

        public void AddListener(System.Action<T, U> handler)
        {
            onTrigger += handler;
        }

        public void RemoveListener(System.Action<T, U> handler)
        {
            onTrigger -= handler;
        }

        public override bool HasDuplicateParameterTypes()
        {
            return typeof(T) == typeof(U);
        }
    }

    public class MotherEvent<T, U, I> : AbstractEvent
    {
        private System.Action<T, U, I> onTrigger;

        public MotherEvent()
        {
        }

        public void Dispatch(T value, U value2, I value3)
        {
            onTrigger?.Invoke(value, value2, value3);
            OnDispatch();
        }

        public void AddListener(System.Action<T, U, I> handler)
        {
            onTrigger += handler;
        }

        public void RemoveListener(System.Action<T, U, I> handler)
        {
            onTrigger -= handler;
        }

        public override bool HasDuplicateParameterTypes()
        {
            return typeof(T) == typeof(U) ||
                   typeof(T) == typeof(I) ||
                   typeof(U) == typeof(I);
        }
    }

    public class MotherEvent<T, U, I, V> : AbstractEvent
    {
        private System.Action<T, U, I, V> onTrigger;

        public MotherEvent()
        {
        }

        public void Dispatch(T value, U value2, I value3, V value4)
        {
            onTrigger?.Invoke(value, value2, value3, value4);
            OnDispatch();
        }

        public void AddListener(System.Action<T, U, I, V> handler)
        {
            onTrigger += handler;
        }

        public void RemoveListener(System.Action<T, U, I, V> handler)
        {
            onTrigger -= handler;
        }

        public override bool HasDuplicateParameterTypes()
        {
            return typeof(T) == typeof(U) ||
                   typeof(T) == typeof(I) ||
                   typeof(U) == typeof(I);
        }
    }

    public class MotherEvent<T, U, I, V, W> : AbstractEvent
    {
        private System.Action<T, U, I, V, W> onTrigger;

        public MotherEvent()
        {
        }

        public void Dispatch(T value, U value2, I value3, V value4, W value5)
        {
            onTrigger?.Invoke(value, value2, value3, value4, value5);
            OnDispatch();
        }

        public void AddListener(System.Action<T, U, I, V, W> handler)
        {
            onTrigger += handler;
        }

        public void RemoveListener(System.Action<T, U, I, V, W> handler)
        {
            onTrigger -= handler;
        }

        public override bool HasDuplicateParameterTypes()
        {
            return typeof(T) == typeof(U) ||
                   typeof(T) == typeof(I) ||
                   typeof(U) == typeof(I);
        }
    }
}