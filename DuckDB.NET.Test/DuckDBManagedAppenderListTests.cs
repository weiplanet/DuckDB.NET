﻿using System.Collections.Generic;
using System;
using Bogus;
using FluentAssertions;
using Xunit;

namespace DuckDB.NET.Test;

public class DuckDBManagedAppenderListTests(DuckDBDatabaseFixture db) : DuckDBTestBase(db)
{
    [Fact]
    public void ListValuesBool()
    {
        ListValuesInternal("Bool", faker => faker.Random.Bool());
    }

    [Fact]
    public void ListValuesSByte()
    {
        ListValuesInternal("TinyInt", faker => faker.Random.SByte());
    }

    [Fact]
    public void ListValuesInt()
    {
        ListValuesInternal("Integer", faker => faker.Random.Int());
    }

    [Fact]
    public void ListValuesLong()
    {
        ListValuesInternal("BigInt", faker => faker.Random.Long());
    }

    public void ListValuesInternal<T>(string typeName, Func<Faker, T> generator)
    {
        var rows = 2000;
        var table = $"managedAppender{typeName}Lists";

        Command.CommandText = $"CREATE TABLE {table} (a Integer, b {typeName}[], c {typeName}[][]);";
        Command.ExecuteNonQuery();

        var lists = new List<List<T>>();
        var nestedLists = new List<List<List<T>>>();

        for (var i = 0; i < rows; i++)
        {
            lists.Add(GetRandomList(generator, Random.Shared.Next(0, 200)));

            var item = new List<List<T>>();
            nestedLists.Add(item);

            for (var j = 0; j < Random.Shared.Next(0, 10); j++)
            {
                item.Add(GetRandomList(generator, Random.Shared.Next(0, 20)));
            }
        }

        using (var appender = Connection.CreateAppender(table))
        {
            for (var i = 0; i < rows; i++)
            {
                appender.CreateRow().AppendValue(i).AppendValue(lists[i]).AppendValue(nestedLists[i]).EndRow();
            }
        }

        Command.CommandText = $"SELECT * FROM {table} order by 1";
        var reader = Command.ExecuteReader();

        var index = 0;
        while (reader.Read())
        {
            var list = reader.GetFieldValue<List<T>>(1);
            list.Should().BeEquivalentTo(lists[index]);

            var nestedList = reader.GetFieldValue<List<List<T>>>(2);
            nestedList.Should().BeEquivalentTo(nestedLists[index]);

            index++;
        }
    }
}