using System;
namespace Code_Of_Lab5v2
{
    public class Banks_Exception : Exception
    {
        public Banks_Exception(string message)
            : base(message)
        { }
    }
}