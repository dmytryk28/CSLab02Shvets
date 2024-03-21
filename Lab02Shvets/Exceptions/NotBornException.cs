namespace Lab02Shvets.Exceptions
{
    internal class NotBornException : Exception
    {
        public NotBornException() { }
        public NotBornException(string message) : base(message) { }
    }
}
