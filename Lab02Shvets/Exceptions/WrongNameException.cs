namespace Lab02Shvets.Exceptions
{
    internal class WrongNameException : Exception
    {
        public WrongNameException() { }
        public WrongNameException(string message) : base(message) { }
    }
}
