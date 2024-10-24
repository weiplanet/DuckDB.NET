﻿using System;
using System.Runtime.InteropServices;

namespace DuckDB.NET.Native;

public partial class NativeMethods
{
    public static class Value
    {
        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_varchar")]
        public static extern DuckDBValue DuckDBCreateVarchar(SafeUnmanagedMemoryHandle value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_bool")]
        public static extern DuckDBValue DuckDBCreateBool(bool value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_int8")]
        public static extern DuckDBValue DuckDBCreateInt8(sbyte value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_uint8")]
        public static extern DuckDBValue DuckDBCreateUInt8(byte value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_int16")]
        public static extern DuckDBValue DuckDBCreateInt16(short value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_uint16")]
        public static extern DuckDBValue DuckDBCreateUInt16(ushort value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_int32")]
        public static extern DuckDBValue DuckDBCreateInt32(int value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_uint32")]
        public static extern DuckDBValue DuckDBCreateUInt32(uint value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_int64")]
        public static extern DuckDBValue DuckDBCreateInt64(long value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_uint64")]
        public static extern DuckDBValue DuckDBCreateUInt64(ulong value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_hugeint")]
        public static extern DuckDBValue DuckDBCreateHugeInt(DuckDBHugeInt value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_uhugeint")]
        public static extern DuckDBValue DuckDBCreateUHugeInt(DuckDBUHugeInt value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_float")]
        public static extern DuckDBValue DuckDBCreateFloat(float value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_double")]
        public static extern DuckDBValue DuckDBCreateDouble(double value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_date")]
        public static extern DuckDBValue DuckDBCreateDate(DuckDBDate value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_time")]
        public static extern DuckDBValue DuckDBCreateTime(DuckDBTime value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_time_tz")]
        public static extern DuckDBValue DuckDBCreateTimeTz(DuckDBTimeTz value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_timestamp")]
        public static extern DuckDBValue DuckDBCreateTimestamp(DuckDBTimestampStruct value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_interval")]
        public static extern DuckDBValue DuckDBCreateInterval(DuckDBInterval value);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_create_blob")]
        public static extern DuckDBValue DuckDBCreateBlob([In] byte[] value, long length);

        [DllImport(DuckDbLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "duckdb_destroy_value")]
        public static extern void DuckDBDestroyValue(out IntPtr config);
    }
}