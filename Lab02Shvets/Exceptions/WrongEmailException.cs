namespace Lab02Shvets.Exceptions
{
    internal class WrongEmailException : Exception
    {
        public WrongEmailException() { }
        public WrongEmailException(string message) : base(message) { }
    }
}
