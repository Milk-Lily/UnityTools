// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Zeus.Framework.Asset
{

using global::System;
using global::System.Collections.Generic;
using global::ZeusFlatBuffers;

public struct SubpackageInfoFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SubpackageInfoFB GetRootAsSubpackageInfoFB(ByteBuffer _bb) { return GetRootAsSubpackageInfoFB(_bb, new SubpackageInfoFB()); }
  public static SubpackageInfoFB GetRootAsSubpackageInfoFB(ByteBuffer _bb, SubpackageInfoFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SubpackageInfoFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Zeus.Framework.Asset.SubpackagePartInfoFB? Parts(int j) { int o = __p.__offset(4); return o != 0 ? (Zeus.Framework.Asset.SubpackagePartInfoFB?)(new Zeus.Framework.Asset.SubpackagePartInfoFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int PartsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
  public string ChunkListName { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetChunkListNameBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetChunkListNameBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetChunkListNameArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Zeus.Framework.Asset.SubpackageInfoFB> CreateSubpackageInfoFB(FlatBufferBuilder builder,
      VectorOffset partsOffset = default(VectorOffset),
      StringOffset chunkListNameOffset = default(StringOffset)) {
    builder.StartTable(2);
    SubpackageInfoFB.AddChunkListName(builder, chunkListNameOffset);
    SubpackageInfoFB.AddParts(builder, partsOffset);
    return SubpackageInfoFB.EndSubpackageInfoFB(builder);
  }

  public static void StartSubpackageInfoFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddParts(FlatBufferBuilder builder, VectorOffset partsOffset) { builder.AddOffset(0, partsOffset.Value, 0); }
  public static VectorOffset CreatePartsVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackagePartInfoFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreatePartsVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackagePartInfoFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartPartsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddChunkListName(FlatBufferBuilder builder, StringOffset chunkListNameOffset) { builder.AddOffset(1, chunkListNameOffset.Value, 0); }
  public static Offset<Zeus.Framework.Asset.SubpackageInfoFB> EndSubpackageInfoFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SubpackageInfoFB>(o);
  }
  public static void FinishSubpackageInfoFBBuffer(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageInfoFB> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedSubpackageInfoFBBuffer(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageInfoFB> offset) { builder.FinishSizePrefixed(offset.Value); }
};

public struct SubpackagePartInfoFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SubpackagePartInfoFB GetRootAsSubpackagePartInfoFB(ByteBuffer _bb) { return GetRootAsSubpackagePartInfoFB(_bb, new SubpackagePartInfoFB()); }
  public static SubpackagePartInfoFB GetRootAsSubpackagePartInfoFB(ByteBuffer _bb, SubpackagePartInfoFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SubpackagePartInfoFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Tag { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetTagBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetTagBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetTagArray() { return __p.__vector_as_array<byte>(4); }
  public Zeus.Framework.Asset.SubpackageChunkInfoFB? Chunks(int j) { int o = __p.__offset(6); return o != 0 ? (Zeus.Framework.Asset.SubpackageChunkInfoFB?)(new Zeus.Framework.Asset.SubpackageChunkInfoFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int ChunksLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Zeus.Framework.Asset.SubpackagePartInfoFB> CreateSubpackagePartInfoFB(FlatBufferBuilder builder,
      StringOffset tagOffset = default(StringOffset),
      VectorOffset chunksOffset = default(VectorOffset)) {
    builder.StartTable(2);
    SubpackagePartInfoFB.AddChunks(builder, chunksOffset);
    SubpackagePartInfoFB.AddTag(builder, tagOffset);
    return SubpackagePartInfoFB.EndSubpackagePartInfoFB(builder);
  }

  public static void StartSubpackagePartInfoFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddTag(FlatBufferBuilder builder, StringOffset tagOffset) { builder.AddOffset(0, tagOffset.Value, 0); }
  public static void AddChunks(FlatBufferBuilder builder, VectorOffset chunksOffset) { builder.AddOffset(1, chunksOffset.Value, 0); }
  public static VectorOffset CreateChunksVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageChunkInfoFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateChunksVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageChunkInfoFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartChunksVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Zeus.Framework.Asset.SubpackagePartInfoFB> EndSubpackagePartInfoFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SubpackagePartInfoFB>(o);
  }
};

public struct SubpackageChunkInfoFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SubpackageChunkInfoFB GetRootAsSubpackageChunkInfoFB(ByteBuffer _bb) { return GetRootAsSubpackageChunkInfoFB(_bb, new SubpackageChunkInfoFB()); }
  public static SubpackageChunkInfoFB GetRootAsSubpackageChunkInfoFB(ByteBuffer _bb, SubpackageChunkInfoFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SubpackageChunkInfoFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(4); }
  public uint Size { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public Zeus.Framework.Asset.SubpackageBundleInfoFB? Bundles(int j) { int o = __p.__offset(8); return o != 0 ? (Zeus.Framework.Asset.SubpackageBundleInfoFB?)(new Zeus.Framework.Asset.SubpackageBundleInfoFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int BundlesLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
  public Zeus.Framework.Asset.SubpackageOtherInfoFB? Others(int j) { int o = __p.__offset(10); return o != 0 ? (Zeus.Framework.Asset.SubpackageOtherInfoFB?)(new Zeus.Framework.Asset.SubpackageOtherInfoFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int OthersLength { get { int o = __p.__offset(10); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Zeus.Framework.Asset.SubpackageChunkInfoFB> CreateSubpackageChunkInfoFB(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      uint size = 0,
      VectorOffset bundlesOffset = default(VectorOffset),
      VectorOffset othersOffset = default(VectorOffset)) {
    builder.StartTable(4);
    SubpackageChunkInfoFB.AddOthers(builder, othersOffset);
    SubpackageChunkInfoFB.AddBundles(builder, bundlesOffset);
    SubpackageChunkInfoFB.AddSize(builder, size);
    SubpackageChunkInfoFB.AddName(builder, nameOffset);
    return SubpackageChunkInfoFB.EndSubpackageChunkInfoFB(builder);
  }

  public static void StartSubpackageChunkInfoFB(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddSize(FlatBufferBuilder builder, uint size) { builder.AddUint(1, size, 0); }
  public static void AddBundles(FlatBufferBuilder builder, VectorOffset bundlesOffset) { builder.AddOffset(2, bundlesOffset.Value, 0); }
  public static VectorOffset CreateBundlesVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageBundleInfoFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateBundlesVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageBundleInfoFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartBundlesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddOthers(FlatBufferBuilder builder, VectorOffset othersOffset) { builder.AddOffset(3, othersOffset.Value, 0); }
  public static VectorOffset CreateOthersVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageOtherInfoFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateOthersVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SubpackageOtherInfoFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartOthersVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Zeus.Framework.Asset.SubpackageChunkInfoFB> EndSubpackageChunkInfoFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SubpackageChunkInfoFB>(o);
  }
};

public struct SubpackageBundleInfoFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SubpackageBundleInfoFB GetRootAsSubpackageBundleInfoFB(ByteBuffer _bb) { return GetRootAsSubpackageBundleInfoFB(_bb, new SubpackageBundleInfoFB()); }
  public static SubpackageBundleInfoFB GetRootAsSubpackageBundleInfoFB(ByteBuffer _bb, SubpackageBundleInfoFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SubpackageBundleInfoFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(4); }
  public int Crc32 { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public uint Size { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public uint Offset { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<Zeus.Framework.Asset.SubpackageBundleInfoFB> CreateSubpackageBundleInfoFB(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      int crc32 = 0,
      uint size = 0,
      uint offset = 0) {
    builder.StartTable(4);
    SubpackageBundleInfoFB.AddOffset(builder, offset);
    SubpackageBundleInfoFB.AddSize(builder, size);
    SubpackageBundleInfoFB.AddCrc32(builder, crc32);
    SubpackageBundleInfoFB.AddName(builder, nameOffset);
    return SubpackageBundleInfoFB.EndSubpackageBundleInfoFB(builder);
  }

  public static void StartSubpackageBundleInfoFB(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddCrc32(FlatBufferBuilder builder, int crc32) { builder.AddInt(1, crc32, 0); }
  public static void AddSize(FlatBufferBuilder builder, uint size) { builder.AddUint(2, size, 0); }
  public static void AddOffset(FlatBufferBuilder builder, uint offset) { builder.AddUint(3, offset, 0); }
  public static Offset<Zeus.Framework.Asset.SubpackageBundleInfoFB> EndSubpackageBundleInfoFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SubpackageBundleInfoFB>(o);
  }
};

public struct SubpackageOtherInfoFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SubpackageOtherInfoFB GetRootAsSubpackageOtherInfoFB(ByteBuffer _bb) { return GetRootAsSubpackageOtherInfoFB(_bb, new SubpackageOtherInfoFB()); }
  public static SubpackageOtherInfoFB GetRootAsSubpackageOtherInfoFB(ByteBuffer _bb, SubpackageOtherInfoFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SubpackageOtherInfoFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Path { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPathBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetPathBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetPathArray() { return __p.__vector_as_array<byte>(4); }

  public static Offset<Zeus.Framework.Asset.SubpackageOtherInfoFB> CreateSubpackageOtherInfoFB(FlatBufferBuilder builder,
      StringOffset pathOffset = default(StringOffset)) {
    builder.StartTable(1);
    SubpackageOtherInfoFB.AddPath(builder, pathOffset);
    return SubpackageOtherInfoFB.EndSubpackageOtherInfoFB(builder);
  }

  public static void StartSubpackageOtherInfoFB(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddPath(FlatBufferBuilder builder, StringOffset pathOffset) { builder.AddOffset(0, pathOffset.Value, 0); }
  public static Offset<Zeus.Framework.Asset.SubpackageOtherInfoFB> EndSubpackageOtherInfoFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SubpackageOtherInfoFB>(o);
  }
};


}
