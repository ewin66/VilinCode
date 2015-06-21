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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities.DataTypes.ExtensionMethods;
using Utilities.SQL.MicroORM.Interfaces;
using Xunit;

namespace UnitTests.SQL
{
    [Collection("DatabaseCollection")]
    public class SQLHelper : IDisposable
    {
        public SQLHelper()
        {
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("Create Database TestDatabase", CommandType.Text, "Data Source=localhost;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("Create Table TestTable(ID INT PRIMARY KEY IDENTITY,StringValue1 NVARCHAR(100),StringValue2 NVARCHAR(MAX),BigIntValue BIGINT,BitValue BIT,DecimalValue DECIMAL(12,6),FloatValue FLOAT,DateTimeValue DATETIME,GUIDValue UNIQUEIDENTIFIER)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteNonQuery();
            }
        }

        [Fact]
        public void BulkCopy()
        {
            Guid TempGuid = Guid.NewGuid();
            List<BulkCopyObject> Objects = new List<BulkCopyObject>();
            for (int x = 0; x < 100; ++x)
            {
                BulkCopyObject TempObject = new BulkCopyObject();
                TempObject.BigIntValue = 12345;
                TempObject.BitValue = true;
                TempObject.DateTimeValue = new DateTime(1999, 12, 31);
                TempObject.DecimalValue = 1234.5678m;
                TempObject.FloatValue = 12345.6534f;
                TempObject.GUIDValue = TempGuid;
                TempObject.ID = x + 1;
                TempObject.StringValue1 = "Test String";
                TempObject.StringValue2 = "Test String";
                Objects.Add(TempObject);
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteBulkCopy(Objects.ToDataTable(), "TestTable");
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                bool Inserted = false;
                while (Helper.Read())
                {
                    Inserted = true;
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                if (!Inserted)
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT COUNT(*) as [ItemCount] FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal(100, Helper.GetParameter<int>("ItemCount", 0));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void BulkCopy2()
        {
            Guid TempGuid = Guid.NewGuid();
            List<BulkCopyObject> Objects = new List<BulkCopyObject>();
            for (int x = 0; x < 100; ++x)
            {
                BulkCopyObject TempObject = new BulkCopyObject();
                TempObject.BigIntValue = 12345;
                TempObject.BitValue = true;
                TempObject.DateTimeValue = new DateTime(1999, 12, 31);
                TempObject.DecimalValue = 1234.5678m;
                TempObject.FloatValue = 12345.6534f;
                TempObject.GUIDValue = TempGuid;
                TempObject.ID = x + 1;
                TempObject.StringValue1 = "Test String";
                TempObject.StringValue2 = "Test String";
                Objects.Add(TempObject);
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteBulkCopy(Objects, "TestTable");
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                bool Inserted = false;
                while (Helper.Read())
                {
                    Inserted = true;
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                if (!Inserted)
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT COUNT(*) as [ItemCount] FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal(100, Helper.GetParameter<int>("ItemCount", 0));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void CachedQuery()
        {
            Utilities.SQL.SQLHelper.ClearCache();
            Guid TempGuid = Guid.NewGuid();
            for (int x = 0; x < 100; ++x)
            {
                using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
                {
                    Assert.Equal(1, Helper.AddParameter<string>("@StringValue1", "Test String")
                        .AddParameter<string>("@StringValue2", "Test String")
                        .AddParameter<long>("@BigIntValue", 12345)
                        .AddParameter<bool>("@BitValue", true)
                        .AddParameter<decimal>("@DecimalValue", 1234.5678m)
                        .AddParameter<float>("@FloatValue", 12345.6534f)
                        .AddParameter<Guid>("@GUIDValue", TempGuid)
                        .AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31))
                        .ExecuteNonQuery());
                }
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader(Cache: true);
                int Count = 0;
                while (Helper.Read())
                {
                    ++Count;
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", TempGuid));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                Assert.Equal(100, Count);
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader(Cache: true);
                int Count = 0;
                while (Helper.Read())
                {
                    ++Count;
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", TempGuid));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                Assert.Equal(100, Count);
            }
        }

        [Fact]
        public void ClearParameters()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test")
                    .AddParameter<string>("@StringValue2", "Test")
                    .AddParameter<long>("@BigIntValue", 123)
                    .AddParameter<bool>("@BitValue", false)
                    .AddParameter<decimal>("@DecimalValue", 1234)
                    .AddParameter<float>("@FloatValue", 12345)
                    .AddParameter<Guid>("@GUIDValue", Guid.NewGuid())
                    .AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 1, 1))
                    .ClearParameters();
                Helper.AddParameter<string>("@StringValue1", "Test String");
                Helper.AddParameter<string>("@StringValue2", "Test String");
                Helper.AddParameter<long>("@BigIntValue", 12345);
                Helper.AddParameter<bool>("@BitValue", true);
                Helper.AddParameter<decimal>("@DecimalValue", 1234.5678m);
                Helper.AddParameter<float>("@FloatValue", 12345.6534f);
                Helper.AddParameter<Guid>("@GUIDValue", TempGuid);
                Helper.AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31));
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void CommandInsert()
        {
            Guid TempGuid = Guid.NewGuid();
            Utilities.SQL.MicroORM.Command TempCommand = new Utilities.SQL.MicroORM.Command("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@0,@1,@2,@3,@4,@5,@6,@7)", CommandType.Text, "@", "Test String", "Test String", 12345L, true, 1234.5678m, 12345.6534f, new DateTime(1999, 12, 31), TempGuid);
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper(TempCommand, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void CommandInsertNullString()
        {
            Guid TempGuid = Guid.NewGuid();
            Utilities.SQL.MicroORM.Command TempCommand = new Utilities.SQL.MicroORM.Command("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@0,@1,@2,@3,@4,@5,@6,@7)", CommandType.Text, "@", "Test String", null, 12345, true, 1234.5678m, 12345.6534f, new DateTime(1999, 12, 31), TempGuid);
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper(TempCommand, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("This is a null string", Helper.GetParameter<string>("StringValue2", "This is a null string"));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void Connect()
        {
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
            }
        }

        [Fact]
        public void Delete()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test String");
                Helper.AddParameter<string>("@StringValue2", "Test String");
                Helper.AddParameter<long>("@BigIntValue", 12345);
                Helper.AddParameter<bool>("@BitValue", true);
                Helper.AddParameter<decimal>("@DecimalValue", 1234.5678m);
                Helper.AddParameter<float>("@FloatValue", 12345.6534f);
                Helper.AddParameter<Guid>("@GUIDValue", TempGuid);
                Helper.AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31));
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("delete from TestTable where @ID=ID", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<int>("@ID", 1);
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.False(true, "Nothing was deleted");
                }
            }
        }

        public void Dispose()
        {
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("", CommandType.Text, "Data Source=localhost;Initial Catalog=master;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.Batch().AddCommand("ALTER DATABASE TestDatabase SET OFFLINE WITH ROLLBACK IMMEDIATE", CommandType.Text)
                    .AddCommand("ALTER DATABASE TestDatabase SET ONLINE", CommandType.Text)
                    .AddCommand("DROP DATABASE TestDatabase", CommandType.Text);
                Helper.ExecuteNonQuery();
            }
        }

        [Fact]
        public void Execute()
        {
            Guid TempGuid = Guid.NewGuid();
            Utilities.SQL.MicroORM.Command TempCommand = new Utilities.SQL.MicroORM.Command("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@0,@1,@2,@3,@4,@5,@6,@7)", CommandType.Text, "@", "Test String", null, 12345, true, 1234.5678m, 12345.6534f, new DateTime(1999, 12, 31), TempGuid);
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper(TempCommand, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                for (int x = 0; x < 100; ++x)
                    Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                bool Inserted = false;
                foreach (dynamic Object in Helper.Execute())
                {
                    Inserted = true;
                    Assert.Equal("Test String", Object.StringValue1);
                    Assert.Equal<string>(null, (string)Object.StringValue2);
                    Assert.Equal(12345, Object.BigIntValue);
                    Assert.Equal(true, Object.BitValue);
                    Assert.Equal(1234.5678m, Object.DecimalValue);
                    Assert.Equal(12345.6534f, Object.FloatValue);
                    Assert.Equal(TempGuid, Object.GUIDValue);
                    Assert.Equal(new DateTime(1999, 12, 31), Object.DateTimeValue);
                }
                if (!Inserted)
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void Insert()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test String")
                    .AddParameter<string>("@StringValue2", "Test String")
                    .AddParameter<long>("@BigIntValue", 12345)
                    .AddParameter<bool>("@BitValue", true)
                    .AddParameter<decimal>("@DecimalValue", 1234.5678m)
                    .AddParameter<float>("@FloatValue", 12345.6534f)
                    .AddParameter<Guid>("@GUIDValue", TempGuid)
                    .AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31))
                    .ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void InsertEmptyString()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "")
                    .AddParameter<string>("@StringValue2", "Test String")
                    .AddParameter<long>("@BigIntValue", 12345)
                    .AddParameter<bool>("@BitValue", true)
                    .AddParameter<decimal>("@DecimalValue", 1234.5678m)
                    .AddParameter<float>("@FloatValue", 12345.6534f)
                    .AddParameter<Guid>("@GUIDValue", TempGuid)
                    .AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31))
                    .ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String1", Helper.GetParameter<string>("StringValue1", "Test String1"));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void LargeBatchInsert()
        {
            Guid TempGuid = Guid.NewGuid();
            Utilities.SQL.MicroORM.Command TempCommand = new Utilities.SQL.MicroORM.Command("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@0,@1,@2,@3,@4,@5,@6,@7)", CommandType.Text, "@", "Test String", "Test String", 12345L, true, 1234.5678m, 12345.6534f, new DateTime(1999, 12, 31), TempGuid);
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper(TempCommand, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                IBatchCommand Batch = Helper.Batch();
                for (int x = 0; x < 1000; ++x)
                {
                    Batch.AddCommands(new Utilities.SQL.MicroORM.Command("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@0,@1,@2,@3,@4,@5,@6,@7)", CommandType.Text, "@", "Test String", "Test String", 12345L, true, 1234.5678m, 12345.6534f, new DateTime(1999, 12, 31), TempGuid));
                }
                Assert.Throws<SqlException>(() => Helper.ExecuteNonQuery());
            }
        }

        [Fact]
        public void MBDBug()
        {
            string ConnectionString = string.Format("Data Source=localhost;Initial Catalog=Master;Integrated Security=SSPI;Pooling=false");
            string CommandString = "SELECT database_id FROM Master.sys.Databases WHERE name=@Name";
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper(CommandString, CommandType.Text, ConnectionString))
            {
                Utilities.SQL.MicroORM.Parameter<string> Parameter = new Utilities.SQL.MicroORM.Parameter<string>("@Name", DbType.String, "TestDatabase", ParameterDirection.Input, "@");
                Helper.AddParameter(Parameter);
                int DbID = Helper.ExecuteScalar<int>();
                Assert.True(DbID > 0);
            }
            Assert.True(Utilities.SQL.SQLServer.SQLServer.DoesDatabaseExist("TestDatabase", ConnectionString));
            Assert.False(Utilities.SQL.SQLServer.SQLServer.DoesDatabaseExist(null, ConnectionString));
        }

        [Fact]
        public void OutputParamter()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test String");
                Helper.AddParameter<string>("@StringValue2", "Test String");
                Helper.AddParameter<long>("@BigIntValue", 12345);
                Helper.AddParameter<bool>("@BitValue", true);
                Helper.AddParameter<decimal>("@DecimalValue", 1234.5678m);
                Helper.AddParameter<float>("@FloatValue", 12345.6534f);
                Helper.AddParameter<Guid>("@GUIDValue", TempGuid);
                Helper.AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31));
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SET @ASD=12345", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<long>("@ASD", Direction: ParameterDirection.Output);
                Helper.ExecuteNonQuery();
                Assert.Equal(12345, Helper.GetParameter<long>("@ASD", 0, ParameterDirection.Output));
            }
        }

        [Fact]
        public void Transaction()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test String");
                Helper.AddParameter<string>("@StringValue2", "Test String");
                Helper.AddParameter<long>("@BigIntValue", 12345);
                Helper.AddParameter<bool>("@BitValue", true);
                Helper.AddParameter<decimal>("@DecimalValue", 1234.5678m);
                Helper.AddParameter<float>("@FloatValue", 12345.6534f);
                Helper.AddParameter<Guid>("@GUIDValue", TempGuid);
                Helper.AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31));
                Helper.ExecuteNonQuery(true);
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT COUNT(*) as [ItemCount] FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal(1, Helper.GetParameter<int>("ItemCount", 0));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        [Fact]
        public void Update()
        {
            Guid TempGuid = Guid.NewGuid();
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("insert into TestTable(StringValue1,StringValue2,BigIntValue,BitValue,DecimalValue,FloatValue,DateTimeValue,GUIDValue) VALUES (@StringValue1,@StringValue2,@BigIntValue,@BitValue,@DecimalValue,@FloatValue,@DateTimeValue,@GUIDValue)", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test");
                Helper.AddParameter<string>("@StringValue2", "Test");
                Helper.AddParameter<long>("@BigIntValue", 123);
                Helper.AddParameter<bool>("@BitValue", false);
                Helper.AddParameter<decimal>("@DecimalValue", 1234);
                Helper.AddParameter<float>("@FloatValue", 12345);
                Helper.AddParameter<Guid>("@GUIDValue", Guid.NewGuid());
                Helper.AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 1, 1));
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("update TestTable set StringValue1=@StringValue1,StringValue2=@StringValue2,BigIntValue=@BigIntValue,BitValue=@BitValue,DecimalValue=@DecimalValue,FloatValue=@FloatValue,DateTimeValue=@DateTimeValue,GUIDValue=@GUIDValue", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.AddParameter<string>("@StringValue1", "Test String");
                Helper.AddParameter<string>("@StringValue2", "Test String");
                Helper.AddParameter<long>("@BigIntValue", 12345);
                Helper.AddParameter<bool>("@BitValue", true);
                Helper.AddParameter<decimal>("@DecimalValue", 1234.5678m);
                Helper.AddParameter<float>("@FloatValue", 12345.6534f);
                Helper.AddParameter<Guid>("@GUIDValue", TempGuid);
                Helper.AddParameter<DateTime>("@DateTimeValue", new DateTime(1999, 12, 31));
                Helper.ExecuteNonQuery();
            }
            using (Utilities.SQL.SQLHelper Helper = new Utilities.SQL.SQLHelper("SELECT * FROM TestTable", CommandType.Text, "Data Source=localhost;Initial Catalog=TestDatabase;Integrated Security=SSPI;Pooling=false"))
            {
                Helper.ExecuteReader();
                if (Helper.Read())
                {
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue1", ""));
                    Assert.Equal("Test String", Helper.GetParameter<string>("StringValue2", ""));
                    Assert.Equal(12345, Helper.GetParameter<long>("BigIntValue", 0));
                    Assert.Equal(true, Helper.GetParameter<bool>("BitValue", false));
                    Assert.Equal(1234.5678m, Helper.GetParameter<decimal>("DecimalValue", 0));
                    Assert.Equal(12345.6534f, Helper.GetParameter<float>("FloatValue", 0));
                    Assert.Equal(TempGuid, Helper.GetParameter<Guid>("GUIDValue", Guid.Empty));
                    Assert.Equal(new DateTime(1999, 12, 31), Helper.GetParameter<DateTime>("DateTimeValue", DateTime.Now));
                }
                else
                {
                    Assert.False(true, "Nothing was inserted");
                }
            }
        }

        public class BulkCopyObject
        {
            public long BigIntValue { get; set; }

            public bool BitValue { get; set; }

            public DateTime DateTimeValue { get; set; }

            public decimal DecimalValue { get; set; }

            public float FloatValue { get; set; }

            public Guid GUIDValue { get; set; }

            public int ID { get; set; }

            public string StringValue1 { get; set; }

            public string StringValue2 { get; set; }
        }
    }
}