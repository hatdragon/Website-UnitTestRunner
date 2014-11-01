﻿using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class TestFixtureAttribute : Attribute
    {
        public TestFixtureAttribute() { }
        public bool AllowDestructiveTests { get; set; }

    }
}
