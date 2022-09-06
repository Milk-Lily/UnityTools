// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Zeus.Framework.Asset
{

using global::System;
using global::System.Collections.Generic;
using global::ZeusFlatBuffers;

public struct SpriteMapAtlasFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SpriteMapAtlasFB GetRootAsSpriteMapAtlasFB(ByteBuffer _bb) { return GetRootAsSpriteMapAtlasFB(_bb, new SpriteMapAtlasFB()); }
  public static SpriteMapAtlasFB GetRootAsSpriteMapAtlasFB(ByteBuffer _bb, SpriteMapAtlasFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SpriteMapAtlasFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Zeus.Framework.Asset.SpriteHashMapAtlasFB? H2a(int j) { int o = __p.__offset(4); return o != 0 ? (Zeus.Framework.Asset.SpriteHashMapAtlasFB?)(new Zeus.Framework.Asset.SpriteHashMapAtlasFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int H2aLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
  public Zeus.Framework.Asset.SpriteNameMapAtlasFB? N2a(int j) { int o = __p.__offset(6); return o != 0 ? (Zeus.Framework.Asset.SpriteNameMapAtlasFB?)(new Zeus.Framework.Asset.SpriteNameMapAtlasFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int N2aLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Zeus.Framework.Asset.SpriteMapAtlasFB> CreateSpriteMapAtlasFB(FlatBufferBuilder builder,
      VectorOffset h2aOffset = default(VectorOffset),
      VectorOffset n2aOffset = default(VectorOffset)) {
    builder.StartTable(2);
    SpriteMapAtlasFB.AddN2a(builder, n2aOffset);
    SpriteMapAtlasFB.AddH2a(builder, h2aOffset);
    return SpriteMapAtlasFB.EndSpriteMapAtlasFB(builder);
  }

  public static void StartSpriteMapAtlasFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddH2a(FlatBufferBuilder builder, VectorOffset h2aOffset) { builder.AddOffset(0, h2aOffset.Value, 0); }
  public static VectorOffset CreateH2aVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SpriteHashMapAtlasFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateH2aVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SpriteHashMapAtlasFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartH2aVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddN2a(FlatBufferBuilder builder, VectorOffset n2aOffset) { builder.AddOffset(1, n2aOffset.Value, 0); }
  public static VectorOffset CreateN2aVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SpriteNameMapAtlasFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateN2aVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SpriteNameMapAtlasFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartN2aVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Zeus.Framework.Asset.SpriteMapAtlasFB> EndSpriteMapAtlasFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SpriteMapAtlasFB>(o);
  }
  public static void FinishSpriteMapAtlasFBBuffer(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SpriteMapAtlasFB> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedSpriteMapAtlasFBBuffer(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.SpriteMapAtlasFB> offset) { builder.FinishSizePrefixed(offset.Value); }
};

public struct SpriteHashMapAtlasFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SpriteHashMapAtlasFB GetRootAsSpriteHashMapAtlasFB(ByteBuffer _bb) { return GetRootAsSpriteHashMapAtlasFB(_bb, new SpriteHashMapAtlasFB()); }
  public static SpriteHashMapAtlasFB GetRootAsSpriteHashMapAtlasFB(ByteBuffer _bb, SpriteHashMapAtlasFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SpriteHashMapAtlasFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Hash { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public string Atlas { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAtlasBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetAtlasBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetAtlasArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Zeus.Framework.Asset.SpriteHashMapAtlasFB> CreateSpriteHashMapAtlasFB(FlatBufferBuilder builder,
      uint hash = 0,
      StringOffset atlasOffset = default(StringOffset)) {
    builder.StartTable(2);
    SpriteHashMapAtlasFB.AddAtlas(builder, atlasOffset);
    SpriteHashMapAtlasFB.AddHash(builder, hash);
    return SpriteHashMapAtlasFB.EndSpriteHashMapAtlasFB(builder);
  }

  public static void StartSpriteHashMapAtlasFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddHash(FlatBufferBuilder builder, uint hash) { builder.AddUint(0, hash, 0); }
  public static void AddAtlas(FlatBufferBuilder builder, StringOffset atlasOffset) { builder.AddOffset(1, atlasOffset.Value, 0); }
  public static Offset<Zeus.Framework.Asset.SpriteHashMapAtlasFB> EndSpriteHashMapAtlasFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SpriteHashMapAtlasFB>(o);
  }
};

public struct SpriteNameMapAtlasFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static SpriteNameMapAtlasFB GetRootAsSpriteNameMapAtlasFB(ByteBuffer _bb) { return GetRootAsSpriteNameMapAtlasFB(_bb, new SpriteNameMapAtlasFB()); }
  public static SpriteNameMapAtlasFB GetRootAsSpriteNameMapAtlasFB(ByteBuffer _bb, SpriteNameMapAtlasFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public SpriteNameMapAtlasFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(4); }
  public string Atlas { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetAtlasBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetAtlasBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetAtlasArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Zeus.Framework.Asset.SpriteNameMapAtlasFB> CreateSpriteNameMapAtlasFB(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      StringOffset atlasOffset = default(StringOffset)) {
    builder.StartTable(2);
    SpriteNameMapAtlasFB.AddAtlas(builder, atlasOffset);
    SpriteNameMapAtlasFB.AddName(builder, nameOffset);
    return SpriteNameMapAtlasFB.EndSpriteNameMapAtlasFB(builder);
  }

  public static void StartSpriteNameMapAtlasFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddAtlas(FlatBufferBuilder builder, StringOffset atlasOffset) { builder.AddOffset(1, atlasOffset.Value, 0); }
  public static Offset<Zeus.Framework.Asset.SpriteNameMapAtlasFB> EndSpriteNameMapAtlasFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.SpriteNameMapAtlasFB>(o);
  }
};


}