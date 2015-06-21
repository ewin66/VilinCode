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

using System.Data;
using Xunit;

namespace UnitTests.SQL.ParameterTypes
{
    public class LikeParameter
    {
        [Fact]
        public void Creation()
        {
            Utilities.SQL.ParameterTypes.LikeParameter TestObject = new Utilities.SQL.ParameterTypes.LikeParameter("ASDF", "ID", 100);
            Assert.Equal("ID", TestObject.ID);
            Assert.Equal("ASDF", TestObject.Value);
            Assert.Equal("@", TestObject.ParameterStarter);
            Assert.Equal("ID LIKE @ID", TestObject.ToString());
            Assert.Equal(100, TestObject.Length);
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("", CommandType.Text, "Data Source=localhost;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter(TestObject);
            }
        }
    }
}