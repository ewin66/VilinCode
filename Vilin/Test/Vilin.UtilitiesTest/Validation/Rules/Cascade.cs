﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using Utilities.Validation.ExtensionMethods;
using Utilities.Validation.Rules;
using Xunit;

namespace UnitTests.Validation.Rules
{
    public class Cascade
    {
        [Fact]
        public void Test()
        {
            ClassB Temp = new ClassB();
            Temp.ItemA = new ClassA();
            Temp.ItemA.ItemA = 1;
            Temp.ItemA.ItemB = DateTime.Now;
            Temp.Validate();
            Temp.ItemA = null;
            Temp.Validate();
        }
    }

    public class ClassB
    {
        [Cascade]
        public ClassA ItemA { get; set; }
    }
}