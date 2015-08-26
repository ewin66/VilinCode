using System;

namespace JF.Common.Libary.JAtrribute
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class NameAttribute : System.Attribute
    {
        private readonly string _name;

        public NameAttribute(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return this._name; }
        }
    }
}