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

#region Usings

using Utilities.IO.ExtensionMethods;
using Xunit;

#endregion

namespace UnitTests.IO.ExtensionMethods
{
    public class String
    {
        [Fact]
        public void RemoveIllegalDirectoryNameCharacters()
        {
            Assert.Equal(@"C:\TestDirectory_Stuff__Hope_ThisWorks", @"C:\TestDirectory""Stuff<>Hope|ThisWorks".RemoveIllegalDirectoryNameCharacters());
        }

        [Fact]
        public void RemoveIllegalFileNameCharacters()
        {
            Assert.Equal(@"TestDirectory_Stuff__Hope_ThisWorks.txt", @"TestDirectory""Stuff<>Hope|ThisWorks.txt".RemoveIllegalFileNameCharacters());
        }
    }
}
