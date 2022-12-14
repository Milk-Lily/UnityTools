// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Zeus.Framework.Asset
{

using global::System;
using global::System.Collections.Generic;
using global::ZeusFlatBuffers;

public struct AssetMapBundleFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static AssetMapBundleFB GetRootAsAssetMapBundleFB(ByteBuffer _bb) { return GetRootAsAssetMapBundleFB(_bb, new AssetMapBundleFB()); }
  public static AssetMapBundleFB GetRootAsAssetMapBundleFB(ByteBuffer _bb, AssetMapBundleFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public AssetMapBundleFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Zeus.Framework.Asset.AssetHashMapBundleFB? H2b(int j) { int o = __p.__offset(4); return o != 0 ? (Zeus.Framework.Asset.AssetHashMapBundleFB?)(new Zeus.Framework.Asset.AssetHashMapBundleFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int H2bLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
  public Zeus.Framework.Asset.AssetPathMapBundleFB? P2b(int j) { int o = __p.__offset(6); return o != 0 ? (Zeus.Framework.Asset.AssetPathMapBundleFB?)(new Zeus.Framework.Asset.AssetPathMapBundleFB()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int P2bLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Zeus.Framework.Asset.AssetMapBundleFB> CreateAssetMapBundleFB(FlatBufferBuilder builder,
      VectorOffset h2bOffset = default(VectorOffset),
      VectorOffset p2bOffset = default(VectorOffset)) {
    builder.StartTable(2);
    AssetMapBundleFB.AddP2b(builder, p2bOffset);
    AssetMapBundleFB.AddH2b(builder, h2bOffset);
    return AssetMapBundleFB.EndAssetMapBundleFB(builder);
  }

  public static void StartAssetMapBundleFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddH2b(FlatBufferBuilder builder, VectorOffset h2bOffset) { builder.AddOffset(0, h2bOffset.Value, 0); }
  public static VectorOffset CreateH2bVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.AssetHashMapBundleFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateH2bVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.AssetHashMapBundleFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartH2bVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddP2b(FlatBufferBuilder builder, VectorOffset p2bOffset) { builder.AddOffset(1, p2bOffset.Value, 0); }
  public static VectorOffset CreateP2bVector(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.AssetPathMapBundleFB>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateP2bVectorBlock(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.AssetPathMapBundleFB>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartP2bVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Zeus.Framework.Asset.AssetMapBundleFB> EndAssetMapBundleFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.AssetMapBundleFB>(o);
  }
  public static void FinishAssetMapBundleFBBuffer(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.AssetMapBundleFB> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedAssetMapBundleFBBuffer(FlatBufferBuilder builder, Offset<Zeus.Framework.Asset.AssetMapBundleFB> offset) { builder.FinishSizePrefixed(offset.Value); }
};

public struct AssetHashMapBundleFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static AssetHashMapBundleFB GetRootAsAssetHashMapBundleFB(ByteBuffer _bb) { return GetRootAsAssetHashMapBundleFB(_bb, new AssetHashMapBundleFB()); }
  public static AssetHashMapBundleFB GetRootAsAssetHashMapBundleFB(ByteBuffer _bb, AssetHashMapBundleFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public AssetHashMapBundleFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Hash { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public string Bundle { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBundleBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetBundleBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetBundleArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Zeus.Framework.Asset.AssetHashMapBundleFB> CreateAssetHashMapBundleFB(FlatBufferBuilder builder,
      uint hash = 0,
      StringOffset bundleOffset = default(StringOffset)) {
    builder.StartTable(2);
    AssetHashMapBundleFB.AddBundle(builder, bundleOffset);
    AssetHashMapBundleFB.AddHash(builder, hash);
    return AssetHashMapBundleFB.EndAssetHashMapBundleFB(builder);
  }

  public static void StartAssetHashMapBundleFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddHash(FlatBufferBuilder builder, uint hash) { builder.AddUint(0, hash, 0); }
  public static void AddBundle(FlatBufferBuilder builder, StringOffset bundleOffset) { builder.AddOffset(1, bundleOffset.Value, 0); }
  public static Offset<Zeus.Framework.Asset.AssetHashMapBundleFB> EndAssetHashMapBundleFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.AssetHashMapBundleFB>(o);
  }
};

public struct AssetPathMapBundleFB : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static AssetPathMapBundleFB GetRootAsAssetPathMapBundleFB(ByteBuffer _bb) { return GetRootAsAssetPathMapBundleFB(_bb, new AssetPathMapBundleFB()); }
  public static AssetPathMapBundleFB GetRootAsAssetPathMapBundleFB(ByteBuffer _bb, AssetPathMapBundleFB obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public AssetPathMapBundleFB __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Path { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPathBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetPathBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetPathArray() { return __p.__vector_as_array<byte>(4); }
  public string Bundle { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetBundleBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetBundleBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetBundleArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<Zeus.Framework.Asset.AssetPathMapBundleFB> CreateAssetPathMapBundleFB(FlatBufferBuilder builder,
      StringOffset pathOffset = default(StringOffset),
      StringOffset bundleOffset = default(StringOffset)) {
    builder.StartTable(2);
    AssetPathMapBundleFB.AddBundle(builder, bundleOffset);
    AssetPathMapBundleFB.AddPath(builder, pathOffset);
    return AssetPathMapBundleFB.EndAssetPathMapBundleFB(builder);
  }

  public static void StartAssetPathMapBundleFB(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddPath(FlatBufferBuilder builder, StringOffset pathOffset) { builder.AddOffset(0, pathOffset.Value, 0); }
  public static void AddBundle(FlatBufferBuilder builder, StringOffset bundleOffset) { builder.AddOffset(1, bundleOffset.Value, 0); }
  public static Offset<Zeus.Framework.Asset.AssetPathMapBundleFB> EndAssetPathMapBundleFB(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Zeus.Framework.Asset.AssetPathMapBundleFB>(o);
  }
};


}
