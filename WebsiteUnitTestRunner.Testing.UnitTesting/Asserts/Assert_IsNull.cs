﻿using System;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    public static partial class Assert
    {
        #region IsNull
        public static void IsNull(object anObject)
        {
            if (anObject != null)
                throw new AssertionFailedException(String.Format("Assertion Failed. Object is not null."));

        }
        public static void IsNull(object anObject, string message)
        {
            if (anObject != null)
                throw new AssertionFailedException(String.Format("Assertion Failed. Object is not null. {0}", message));
        }
        #endregion

    }
}
