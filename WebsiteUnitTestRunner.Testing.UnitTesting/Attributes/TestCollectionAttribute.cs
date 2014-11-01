using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TestCollectionAttribute : Attribute
    {
        private string _name;
        public string Name
        {
            get { return this._name ?? this.GetType().DeclaringMethod.ToString(); }
            set { this._name = value; }
        }

        public bool Ignore { get; set; }

        public string RequiredAttr { get; set; }

        public TestCollectionAttribute() { }

    }
}
