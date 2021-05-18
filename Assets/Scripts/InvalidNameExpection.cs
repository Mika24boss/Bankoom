using System;

namespace Scenes
{
    public class InvalidNameExpection : ApplicationException
    {
        public InvalidNameExpection(string objectName): base(objectName+" is an invalid object name, please use : (numbers 0-9 or reset) in order to clear this error.")
        {






        }


       
    
}
}