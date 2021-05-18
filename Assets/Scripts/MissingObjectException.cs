using System;

namespace Scenes
{
    internal class MissingObjectException : Exception
    {
        public MissingObjectException(String objectName, String location): base(objectName+" couldn't be found in: " + location)
        {
            
        }

        public MissingObjectException(String message): base(message)
        {
            
        }
    }
}