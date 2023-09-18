namespace Lambda_Core.Exceptions
{
    class LimitExceededException: Exception
    {
        public LimitExceededException(string message) : base(message) { }
    }
}
