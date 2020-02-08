using System;

namespace UIGenerator
{
    /// <summary>
    /// エンコードの方法
    /// </summary>
    [Serializable]
    public enum EncodingType
    {
        /// <summary>
        /// 既定のエンコードタイプ
        /// 安定しない可能性あり
        /// </summary>
        Default,
        /// <summary>
        /// ASCII
        /// </summary>
        ASCII = 20127,
        /// <summary>
        /// UTF7
        /// </summary>
        UTF7 = 65000,
        /// <summary>
        /// UTF8のBOM無し
        /// </summary>
        UTF8 = -1,
        /// <summary>
        /// UTF8のBOM付き
        /// </summary>
        UTF8WithBOM = 65001,
        /// <summary>
        /// UTF16のリトルエンディアンBOM無し
        /// </summary>
        UTF16LE = -2,
        /// <summary>
        /// UTF16のリトルエンディアンBOM付き
        /// </summary>
        UTF16LEWithBOM = 1200,
        /// <summary>
        /// UTF16のビッグエンディアンBOM無し
        /// </summary>
        UTF16BE = -3,
        /// <summary>
        /// UTF16のビッグエンディアンBOM付き
        /// </summary>
        UTF16BEWithBOM = 1201,
        /// <summary>
        /// UTF32のリトルエンディアンBOM無し
        /// </summary>
        UTF32LE = -4,
        /// <summary>
        /// UTF32のリトルエンディアンBOM付き
        /// </summary>
        UTF32LEWithBOM = 12000,
        /// <summary>
        /// UTF32のビッグエンディアンBOM無し
        /// </summary>
        UTF32BE = -5,
        /// <summary>
        /// UTF32のビッグエンディアンBOM付き
        /// </summary>
        UTF32BEWithBOM = 12001,
        ISCIIAssemese = 57006,
        ISCIIBengali = 57003,
        ISCIIDevanagari = 57002,
        ISCIIGujarathi = 57010,
        ISCIIKannada = 57008,
        ISCIIMalayalam = 57009,
        ISCIIOriya = 57007,
        ISCIIPanjabi = 570011,
        ISCIITamil = 57004,
        ISCIITelugu = 57005,
        ISO_8859_1 = 28591,
        GB18030 = 54936,
        ISO_8859_8I = 38598,
        ISO_8859_8_Visual = 28598,
        ENC50029 = 50029,
        ECKER = 51929,
        EUCCN = 936,
        DuplicateEUCCN = 51936,
        ISO2022JP = 50220,
        ISO2022JPESC = 50221,
        ISO2022JPSISO = 50222,
        ISOKorean = 50225,
        ISOSimplifiedCN = 50227,
        EUCJP = 51932,
        ChineseHZ = 52936,
        CodePageMacGB2312 = 10008,
        CodePageGB2312 = 20936,
        CodeMacKorean = 10003,
        CodeDLLKorean = 20949,
        CodePageNoOEM = 1,
        CodePageNoMac = 2,
        CodePageNoThread = 3,
        CodePageNoSymbol = 42,
        CodePageWindows1252 = 1252
    }
}