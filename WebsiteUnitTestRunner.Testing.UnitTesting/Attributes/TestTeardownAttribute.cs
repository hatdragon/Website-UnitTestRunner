﻿using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class TestTeardownAttribute : Attribute
    {
        private string _name;
        public string Name
        {
            get { return _name ?? this.GetType().DeclaringMethod.ToString(); }
            set { _name = value; }
        }

        public TestTeardownAttribute()
        {
        }

    }
}
