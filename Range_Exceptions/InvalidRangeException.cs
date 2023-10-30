namespace Range_Exceptions
{
    public class InvalidRangeException<T> : Exception
    {
        public T Start { get; }
        public T End { get; }

        public InvalidRangeException(string message, T start, T end) : base(message)
        {
            Start = start;
            End = end;
        }
    }
}
