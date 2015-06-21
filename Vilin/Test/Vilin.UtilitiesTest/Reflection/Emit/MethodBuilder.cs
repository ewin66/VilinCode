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
using Utilities.Reflection.Emit.BaseClasses;
using Utilities.Reflection.Emit.Interfaces;
using Xunit;

namespace UnitTests.Reflection.Emit
{
    public class MethodBuilder
    {
        [Fact]
        public void Add()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.Add(Local1, Local2));
        }

        [Fact]
        public void Assign()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Method.Assign(Local1, Local2);
        }

        [Fact]
        public void Box()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.Box(Local1));
        }

        [Fact]
        public void Call()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            IMethodBuilder Method2 = TestType.CreateMethod("TestMethod2");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Method.This.Call(Method2, null);
        }

        [Fact]
        public void Cast()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Method.Cast(Method.This, typeof(object));
        }

        [Fact]
        public void Create()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            Assert.NotNull(Method);
        }

        [Fact]
        public void CreateConstant()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.CreateConstant(12));
        }

        [Fact]
        public void CreateLocal()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Local1);
            Assert.NotNull(Local2);
        }

        [Fact]
        public void Divide()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.Divide(Local1, Local2));
        }

        [Fact]
        public void If()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Utilities.Reflection.Emit.Commands.If If = Method.If(Local1, Utilities.Reflection.Emit.Enums.Comparison.Equal, Local2);
            Method.EndIf(If);
            Assert.NotNull(If);
        }

        [Fact]
        public void Modulo()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.Modulo(Local1, Local2));
        }

        [Fact]
        public void Multiply()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.Multiply(Local1, Local2));
        }

        [Fact]
        public void NewObj()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.NewObj(typeof(DateTime), new object[] { Local1 }));
        }

        [Fact]
        public void Return()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod", ReturnType: typeof(int));
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Method.Return(Local1);
        }

        [Fact]
        public void Subtract()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.Subtract(Local1, Local2));
        }

        [Fact]
        public void Throw()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Method.Throw(Method.NewObj(typeof(Exception)));
        }

        [Fact]
        public void TryCatch()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Utilities.Reflection.Emit.Commands.Try Try = Method.Try();
            Utilities.Reflection.Emit.Commands.Catch Catch = Method.Catch(typeof(Exception));
            Method.EndTry();
            Assert.NotNull(Try);
            Assert.NotNull(Catch);
        }

        [Fact]
        public void UnBox()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Assert.NotNull(Method.UnBox(Method.Box(Local1), typeof(int)));
        }

        [Fact]
        public void While()
        {
            Utilities.Reflection.Emit.Assembly Assembly = new Utilities.Reflection.Emit.Assembly("TestAssembly");
            Utilities.Reflection.Emit.TypeBuilder TestType = Assembly.CreateType("TestType");
            IMethodBuilder Method = TestType.CreateMethod("TestMethod");
            VariableBase Local1 = Method.CreateLocal("Local1", typeof(int));
            VariableBase Local2 = Method.CreateLocal("Local2", typeof(int));
            Utilities.Reflection.Emit.Commands.While While = Method.While(Local1, Utilities.Reflection.Emit.Enums.Comparison.Equal, Local2);
            Method.EndWhile(While);
            Assert.NotNull(While);
        }
    }
}