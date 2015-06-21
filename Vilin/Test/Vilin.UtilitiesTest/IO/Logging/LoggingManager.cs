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
using UnitTests.Fixtures;
using Xunit;

namespace UnitTests.IO.Logging
{
    public class LoggingManager : LoggingManagerFixture
    {
        public LoggingManager()
        {
        }

        [Fact]
        public void AddLog()
        {
            Utilities.IO.Logging.LoggingManager.AddLog<Utilities.IO.Logging.ConsoleLog>();
            Utilities.IO.Logging.ConsoleLog Log = Utilities.IO.Logging.LoggingManager.GetLog<Utilities.IO.Logging.ConsoleLog>();
            Assert.NotNull(Log);
        }

        [Fact]
        public void AddLog2()
        {
            Utilities.IO.Logging.LoggingManager.AddLog<Utilities.IO.Logging.ConsoleLog>("NotDefault");
            Utilities.IO.Logging.ConsoleLog Log = Utilities.IO.Logging.LoggingManager.GetLog<Utilities.IO.Logging.ConsoleLog>("NotDefault");
            Assert.NotNull(Log);
        }

        [Fact]
        public void AddLog3()
        {
            Utilities.IO.Logging.ConsoleLog TempConsoleLog = new Utilities.IO.Logging.ConsoleLog();
            Utilities.IO.Logging.LoggingManager.AddLog(TempConsoleLog);
            Utilities.IO.Logging.ConsoleLog Log = Utilities.IO.Logging.LoggingManager.GetLog<Utilities.IO.Logging.ConsoleLog>();
            Assert.Equal(TempConsoleLog, Log);
        }

        [Fact]
        public void GetLog()
        {
            Utilities.IO.Logging.LoggingManager.Destroy();
            Assert.Throws<ArgumentException>(() => Utilities.IO.Logging.LoggingManager.GetLog<Utilities.IO.Logging.ConsoleLog>());
        }

        [Fact]
        public void GetLog2()
        {
            Utilities.IO.Logging.LoggingManager.AddLog<Utilities.IO.Logging.ConsoleLog>();
            Utilities.IO.Logging.ConsoleLog Log = Utilities.IO.Logging.LoggingManager.GetLog<Utilities.IO.Logging.ConsoleLog>();
            Assert.NotNull(Log);
        }

        public void SetFixture(LoggingManagerFixture data)
        {
        }
    }
}